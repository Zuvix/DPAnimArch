﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OALProgramControl;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using Assets.Scripts.AnimationControl.OAL;
using AnimArch.Visualization.Diagrams;
using Object = System.Object;

namespace AnimArch.Visualization.Animating
{
    //Controls the entire animation process
    public class Animation : Singleton<Animation>
    {
        private ClassDiagram classDiagram;
        public Color classColor;
        public Color methodColor;
        public Color relationColor;
        public GameObject LineFill;
        private int BarrierSize;
        private int CurrentBarrierFill;
        [HideInInspector] public bool AnimationIsRunning = false;
        [HideInInspector] public bool isPaused = false;
        [HideInInspector] public bool standardPlayMode = true;
        public bool nextStep = false;
        private bool prevStep = false;
        private List<GameObject> Fillers;

        public string startClassName;
        public string startMethodName;

        private void Awake()
        {
            classDiagram = GameObject.Find("ClassDiagram").GetComponent<ClassDiagram>();
            standardPlayMode = true;
        }

        // Main Couroutine for compiling the OAL of Animation script and then starting the visualisation of Animation
        public IEnumerator Animate()
        {
            Fillers = new List<GameObject>();

            if (this.AnimationIsRunning)
            {
                yield break;
            }
            else
            {
                this.AnimationIsRunning = true;
            }

            List<Anim> animations = AnimationData.Instance.getAnimList();
            Anim selectedAnimation = AnimationData.Instance.selectedAnim;
            if (animations != null)
            {
                if (animations.Count > 0 && selectedAnimation.AnimationName.Equals(""))
                    selectedAnimation = animations[0];
            }

            OALProgram Program = OALProgram.Instance;
            List<AnimClass> MethodsCodes = selectedAnimation.GetMethodsCodesList(); //Filip
            string Code = selectedAnimation.Code; //toto potom mozno pojde prec
            Debug.Log("Code: ");
            Debug.Log(Code);

            foreach (AnimClass classItem in MethodsCodes) //Filip
            {
                CDClass Class = Program.ExecutionSpace.getClassByName(classItem.Name);

                foreach (AnimMethod methodItem in classItem.Methods)
                {
                    CDMethod Method = Class.getMethodByName(methodItem.Name);

                    //ak je methodItem.Code nie je prazdny retazec tak parsuj
                    //if (!string.IsNullOrWhiteSpace(methodItem.Code))        //toto asi uz nebude potrebne
                    //{
                    EXEScopeMethod MethodBody = OALParserBridge.Parse(methodItem.Code);
                    Method.ExecutableCode = MethodBody;
                    //}
                    /*else {////
                        Method.ExecutableCode = null;
                    }///*/
                }
            }

            CDClass startClass = Program.ExecutionSpace.getClassByName(startClassName);
            if (startClass == null)
            {
                Debug.LogError(string.Format("Error, Class \"{0}\" not found", startClassName ?? "NULL"));
            }

            CDMethod startMethod = startClass.getMethodByName(startMethodName);
            if (startMethod == null)
            {
                Debug.LogError(string.Format("Error, Method \"{0}\" not found", startMethodName ?? "NULL"));
            }

            //najdeme startMethod z daneho class stringu a method stringu, ak startMethod.ExecutableCode je null tak return null alebo yield break
            EXEScopeMethod MethodExecutableCode = Program.ExecutionSpace.getClassByName(startClassName)
                .getMethodByName(startMethodName).ExecutableCode;
            if (MethodExecutableCode == null)
            {
                Debug.Log("Warning, EXEScopeMethod of selected Method is null");
                yield break;
            }

            OALProgram.Instance.SuperScope = MethodExecutableCode; //StartMethod.ExecutableCode
            //OALProgram.Instance.SuperScope = OALParserBridge.Parse(Code); //Method.ExecutableCode dame namiesto OALParserBridge.Parse(Code) pre metodu ktora bude zacinat

            Debug.Log("Abt to execute program");
            int i = 0;

            bool Success = true;
            while (Success && Program.CommandStack.HasNext())
            {
                EXECommand CurrentCommand = Program.CommandStack.Next();
                bool ExecutionSuccess = CurrentCommand.PerformExecution(Program);

                Debug.Log("Command " + i++.ToString() + ". Success: " + ExecutionSuccess.ToString() +
                          ". Command type: " + CurrentCommand.GetType().Name);

                if (CurrentCommand.GetType().Equals(typeof(EXECommandCall)))
                {
                    BarrierSize = 1;
                    CurrentBarrierFill = 0;

                    StartCoroutine(ResolveCallFunct(((EXECommandCall) CurrentCommand).CreateOALCall()));

                    CreateRelationInObjectDiagram((EXECommandCall)CurrentCommand);

                     // Debug.LogError(start.VariableName + " " + end.VariableName);
                     yield return StartCoroutine(BarrierFillCheck());
                }
                else if (CurrentCommand.GetType().Equals(typeof(EXECommandMultiCall)))
                {
                    EXECommandMultiCall multicallCommand = (EXECommandMultiCall)CurrentCommand;
                    BarrierSize = multicallCommand.CallCommands.Count;
                    CurrentBarrierFill = 0;

                    foreach (EXECommandCall callCommand in multicallCommand.CallCommands)
                    {
                        StartCoroutine(ResolveCallFunct(callCommand.CreateOALCall()));
                    }

                    foreach (EXECommandCall callCommand in multicallCommand.CallCommands)
                    {
                        CreateRelationInObjectDiagram(callCommand);
                    }

                    // Debug.LogError(start.VariableName + " " + end.VariableName);
                    yield return StartCoroutine(BarrierFillCheck());
                }
                else if (CurrentCommand.GetType() == typeof(EXECommandQueryCreate))
                {
                    string ReferencingVariableName = ((EXECommandQueryCreate) CurrentCommand).ReferencingVariableName;
                    string className = ((EXECommandQueryCreate) CurrentCommand).ClassName;
                    long instanciId = CurrentCommand.GetSuperScope()
                        .FindReferencingVariableByName(ReferencingVariableName).ReferencedInstanceId;

                    CDClass VariableClass = OALProgram.Instance.ExecutionSpace.getClassByName(className);

                    CDClassInstance ClassInstance = VariableClass.GetInstanceByID(instanciId);
                    ResolveCreateObject(className, ReferencingVariableName, ClassInstance);
                }
                else if (CurrentCommand.GetType() == typeof(EXECommandAssignment))
                {
                    EXECommandAssignment assignment = (EXECommandAssignment) CurrentCommand;

                    if (assignment.AttributeName != null)
                    {
                        EXEReferencingVariable variable =
                            assignment.GetSuperScope().FindReferencingVariableByName(assignment.VariableName);
                        long instanceId = variable.ReferencedInstanceId;
                        Debug.LogError(instanceId);
                        DiagramPool.Instance.ObjectDiagram.AddAttributeValue(instanceId,
                            assignment.AttributeName, assignment.AssignedExpression.ToCode());
                    }
                }

                Success = Success && ExecutionSuccess;
            }

            /*
            if (Success)
            {
                Debug.Log("We have " + ACS.AnimationSteps.Count() + " anim sequences");
                foreach (List<AnimationCommand> AnimationSequence in ACS.AnimationSteps)
                {
                    BarrierSize = AnimationSequence.Count;
                    Debug.Log("Filling barrier of size " + BarrierSize);
                    CurrentBarrierFill = 0;
                    if (!AnimationSequence.Any())
                    {
                        continue;
                    }
                    if (AnimationSequence[0].IsCall)
                    {
                        foreach (AnimationCommand Command in AnimationSequence)
                        {
                            StartCoroutine(Command.Execute());
                        }
                        yield return StartCoroutine(BarrierFillCheck());
                    }
                    else
                    {
                        foreach (AnimationCommand Command in AnimationSequence)
                        {
                            Command.Execute();
                        }
                    }
                }
            }
            */
            Debug.Log("Over");
            this.AnimationIsRunning = false;
        }

        private void CreateRelationInObjectDiagram(EXECommandCall command)
        {
            ObjectDiagram od = DiagramPool.Instance.ObjectDiagram;
            ObjectInDiagram start = null;
            ObjectInDiagram end = null;
            foreach (var objectInDiagram in od.Objects)
            {
                var className = objectInDiagram.Class.ClassInfo.Name;
                if (className.Equals(command.CallerMethodInfo.ClassName))
                {
                    start = objectInDiagram;
                }
                else if (className.Equals(command.CalledClass))
                {
                    end = objectInDiagram;
                }
            }

            if (start == null || end == null || start == end)
            {
                return;
            }

            od.AddRelation(start, end);
        }

        private void ResolveCreateObject(string className, string varName, CDClassInstance instance)
        {
            ObjectInDiagram addedObject = DiagramPool.Instance.ObjectDiagram.AddObject(className, varName, instance);
        }

        public void IncrementBarrier()
        {
            this.CurrentBarrierFill++;
        }

        public IEnumerator BarrierFillCheck()
        {
            yield return new WaitUntil(() => CurrentBarrierFill >= BarrierSize);
        }

        public void StartAnimation()
        {
            isPaused = false;
            StartCoroutine("Animate");
        }

        //Couroutine that can be used to Highlight class for a given duration of time
        public IEnumerator AnimateClass(string className, float animationLength)
        {
            HighlightClass(className, true);
            yield return new WaitForSeconds(animationLength);
            HighlightClass(className, false);
        }

        //Couroutine that can be used to Highlight method for a given duration of time
        public IEnumerator AnimateMethod(string className, string methodName, float animationLength)
        {
            HighlightMethod(className, methodName, true);
            yield return new WaitForSeconds(animationLength);
            HighlightMethod(className, methodName, false);
        }

        //Couroutine that can be used to Highlight edge for a given duration of time
        public IEnumerator AnimateEdge(string relationshipName, float animationLength)
        {
            HighlightEdge(relationshipName, true);
            yield return new WaitForSeconds(animationLength);
            HighlightEdge(relationshipName, false);
        }

        public IEnumerator AnimateFill(OALCall Call)
        {
            //Debug.Log("Filip, hrana: " + Call.RelationshipName); //Filip
            GameObject edge = classDiagram.FindEdge(Call.RelationshipName);
            if (edge != null)
            {
                if (edge.CompareTag("Generalization") || edge.CompareTag("Implements") ||
                    edge.CompareTag("Realisation"))
                {
                    HighlightEdge(Call.RelationshipName, true);
                    yield return new WaitForSeconds(AnimationData.Instance.AnimSpeed / 2);
                }
                else
                {
                    GameObject newFiller = Instantiate(LineFill);
                    Fillers.Add(newFiller);
                    newFiller.transform.position = classDiagram.graph.transform.GetChild(0).transform.position;
                    newFiller.transform.SetParent(classDiagram.graph.transform);
                    newFiller.transform.localScale = new Vector3(1, 1, 1);
                    LineFiller lf = newFiller.GetComponent<LineFiller>();
                    bool flip = false;
                    if (classDiagram
                        .FindOwnerOfRelation( /*Call.CallerClassName, Call.CalledClassName*/Call.RelationshipName)
                        .Equals(Call.CalledClassName))
                    {
                        flip = true;
                    }

                    yield return lf.StartCoroutine(lf.AnimateFlow(edge.GetComponent<UILineRenderer>().Points, flip));
                }
            }
        }

        //Method used to Highlight/Unhighlight single class by name, depending on bool value of argument 
        public void HighlightClass(string className, bool isToBeHighlighted)
        {
            GameObject node = classDiagram.FindNode(className);
            BackgroundHighlighter bh = null;
            if (node != null)
            {
                bh = node.GetComponent<BackgroundHighlighter>();
            }
            else
            {
                Debug.Log("Node " + className + " not found");
            }

            if (bh != null)
            {
                if (isToBeHighlighted)
                {
                    bh.HighlightBackground();
                    //Debug.Log("Filip, classa: " + className); //Filip
                }
                else
                {
                    bh.UnhighlightBackground();
                }
            }
            else
            {
                Debug.Log("Highlighter component not found");
            }
        }

        //Method used to Highlight/Unhighlight single method by name, depending on bool value of argument 
        public void HighlightMethod(string className, string methodName, bool isToBeHighlighted)
        {
            GameObject node = classDiagram.FindNode(className);
            TextHighlighter th = null;
            if (node != null)
            {
                th = node.GetComponent<TextHighlighter>();
            }
            else
            {
                Debug.Log("Node " + className + " not found");
            }

            if (th != null)
            {
                if (isToBeHighlighted)
                {
                    th.HighlightLine(methodName);
                    //Debug.Log("Filip, metoda: " + methodName); //Filip
                }
                else
                {
                    th.UnHighlightLine(methodName);
                }
            }
            else
            {
                Debug.Log("TextHighligher component not found");
            }
        }

        //Method used to Highlight/Unhighlight single edge by name, depending on bool value of argument 
        public void HighlightEdge(string relationshipName, bool isToBeHighlighted)
        {
            GameObject edge = classDiagram.FindEdge(relationshipName);
            if (edge != null)
            {
                if (isToBeHighlighted)
                {
                    edge.GetComponent<UEdge>().ChangeColor(relationColor);
                    edge.GetComponent<UILineRenderer>().LineThickness = 8;
                }
                else
                {
                    edge.GetComponent<UEdge>().ChangeColor(Color.white);
                    edge.GetComponent<UILineRenderer>().LineThickness = 5;
                }
            }
            else
            {
                Debug.Log(relationshipName + " NULL Edge ");
            }
        }

        //Couroutine used to Resolve one OALCall consisting of Caller class, caller method, edge, called class, called method
        // Same coroutine is called for play or step mode
        public IEnumerator ResolveCallFunct(OALCall Call)
        {
            int step = 0;
            float speedPerAnim = AnimationData.Instance.AnimSpeed;
            float timeModifier = 1f;
            while (step < 7)
            {
                if (isPaused)
                {
                    yield return new WaitForFixedUpdate();
                }
                else
                {
                    switch (step)
                    {
                        case 0:
                            HighlightClass(Call.CallerClassName, true);
                            break;
                        case 1:
                            HighlightMethod(Call.CallerClassName, Call.CallerMethodName, true);
                            break;
                        case 2:
                            yield return StartCoroutine(AnimateFill(Call));
                            timeModifier = 0f;
                            break;
                        case 3:
                            HighlightEdge(Call.RelationshipName, true);
                            timeModifier = 0.5f;
                            break;
                        case 4:
                            HighlightClass(Call.CalledClassName, true);
                            timeModifier = 1f;
                            break;
                        case 5:
                            HighlightMethod(Call.CalledClassName, Call.CalledMethodName, true);
                            timeModifier = 1.25f;
                            break;
                        case 6:
                            HighlightClass(Call.CallerClassName, false);
                            HighlightMethod(Call.CallerClassName, Call.CallerMethodName, false);
                            HighlightClass(Call.CalledClassName, false);
                            HighlightMethod(Call.CalledClassName, Call.CalledMethodName, false);
                            HighlightEdge(Call.RelationshipName, false);
                            timeModifier = 1f;
                            break;
                    }

                    step++;
                    if (standardPlayMode)
                    {
                        yield return new WaitForSeconds(AnimationData.Instance.AnimSpeed * timeModifier);
                    }
                    //Else means we are working with step animation
                    else
                    {
                        if (step == 2) step = 3;
                        nextStep = false;
                        prevStep = false;
                        yield return new WaitUntil(() => nextStep);
                        if (prevStep == true)
                        {
                            if (step > 0) step--;
                            if (step == 2) step = 1;
                            switch (step)
                            {
                                case 0:
                                    HighlightClass(Call.CallerClassName, false);
                                    break;
                                case 1:
                                    HighlightMethod(Call.CallerClassName, Call.CallerMethodName, false);
                                    break;
                                case 3:
                                    HighlightEdge(Call.RelationshipName, false);
                                    break;
                                case 4:
                                    HighlightClass(Call.CalledClassName, false);
                                    break;
                                case 5:
                                    HighlightMethod(Call.CalledClassName, Call.CalledMethodName, false);
                                    break;
                            }

                            if (step > -1) step--;
                            if (step == 2) step = 1;
                            switch (step)
                            {
                                case 0:
                                    HighlightClass(Call.CallerClassName, false);
                                    break;
                                case 1:
                                    HighlightMethod(Call.CallerClassName, Call.CallerMethodName, false);
                                    break;
                                case 3:
                                    HighlightEdge(Call.RelationshipName, false);
                                    break;
                                case 4:
                                    HighlightClass(Call.CalledClassName, false);
                                    break;
                                case 5:
                                    HighlightMethod(Call.CalledClassName, Call.CalledMethodName, false);
                                    break;
                            }
                        }

                        yield return new WaitForFixedUpdate();
                        nextStep = false;
                        prevStep = false;
                    }
                }
            }

            IncrementBarrier();
        }

        public string GetColorCode(string type)
        {
            if (type == "class")
            {
                return ColorUtility.ToHtmlStringRGB(classColor);
            }

            if (type == "method")
            {
                return ColorUtility.ToHtmlStringRGB(methodColor);
            }

            if (type == "relation")
            {
                return ColorUtility.ToHtmlStringRGB(relationColor);
            }

            return "";
        }

        //Method used to stop all animations and unhighlight all objects
        public void UnhighlightAll()
        {
            isPaused = false;
            StopAllCoroutines();
            if (DiagramPool.Instance.ClassDiagram.GetClassList() != null)
                foreach (Class c in DiagramPool.Instance.ClassDiagram.GetClassList())
                {
                    HighlightClass(c.Name, false);
                    if (c.Methods != null)
                        foreach (Method m in c.Methods)
                        {
                            HighlightMethod(c.Name, m.Name, false);
                        }
                }

            if (DiagramPool.Instance.ClassDiagram.GetRelationList() != null)
                foreach (Relation r in DiagramPool.Instance.ClassDiagram.GetRelationList())
                {
                    HighlightEdge(r.OALName, false);
                }

            AnimationIsRunning = false;
        }

        public void Pause()
        {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }

        public void NextStep()
        {
            if (AnimationIsRunning == false)
                StartAnimation();
            else
                nextStep = true;
        }

        public void PrevStep()
        {
            nextStep = true;
            prevStep = true;
        }
    }
}