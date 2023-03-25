using UnityEngine;
using AnimArch.Visualization.Animating;

namespace AnimArch.Visualization.Diagrams
{
    public class InterGraphRelation : MonoBehaviour
    {
        public ObjectInDiagram Object;
        public ClassInDiagram Class;
        private Vector3 _prevClassPos;
        private Vector3 _prevObjPos;

        private GameObject _interGraphArrow;
        private Arrow _arrow;

        private LineRenderer _lineRenderer;
        public LineTextureMode textureMode = LineTextureMode.RepeatPerSegment;

        private float distance;
        private float counter;

        public Vector3 p0, p1;
        public float lineDrawSpeed = 6f;
        private bool animating;

        public void Initialize(ObjectInDiagram Object, ClassInDiagram Class)
        {
            this.Object = Object;
            this.Class = Class;
            
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.textureMode = textureMode;
            _lineRenderer.material = Resources.Load<Material>("Materials/DashedLine");

            _interGraphArrow = Instantiate(DiagramPool.Instance.interGraphArrowPrefab);
            _arrow = _interGraphArrow.GetComponent<Arrow>();
            _arrow.GetComponent<Arrow>().Initialize();
            
            _prevClassPos = p0 = Class.VisualObject.GetComponent<RectTransform>().position;
            _prevObjPos = Object.VisualObject.GetComponent<RectTransform>().position;
            
            p1 = Vector3.MoveTowards(_prevClassPos, _prevObjPos, (_prevClassPos - _prevObjPos).magnitude - 6);
            
            distance = Vector3.Distance(p0, p1);
            
            _lineRenderer.SetPosition(0, p0);
            
            
        }

        void Update()
        {
            
            // if (counter < distance)
            // {
            //     counter += .1f / lineDrawSpeed;
            //     float x = Mathf.Lerp(0, distance, counter);
            //     var point0 = p0;
            //     var point1 = p1;
            //
            //     var pointALongLine = x * Vector3.Normalize(point1 - point0) + point0;
            //
            //     _lineRenderer.SetPosition(1, pointALongLine);
            // }
            
            
            if (_prevClassPos != Class.VisualObject.GetComponent<RectTransform>().position
                || _prevObjPos != Object.VisualObject.GetComponent<RectTransform>().position)
            {
                _prevObjPos = Object.VisualObject.GetComponent<RectTransform>().position;
                _lineRenderer.SetPositions
                (
                    new Vector3[]
                    {
                        _prevClassPos = Class.VisualObject.GetComponent<RectTransform>().position,
                        Vector3.MoveTowards(_prevClassPos, _prevObjPos, (_prevClassPos - _prevObjPos).magnitude - 6)
                    }
                );
                Vector3 v = Vector3.MoveTowards(_prevObjPos, _prevClassPos, 18);
                _arrow.UpdatePosition(_prevObjPos, v);
                _lineRenderer.textureMode = textureMode;
            }
        }

        public void Animate(float instanceAnimSpeed)
        {
            // lineDrawSpeed = instanceAnimSpeed;
            // Highlight();
            // animating = true;
        }

        public void Hide()
        {
            _lineRenderer.enabled = false;
            _interGraphArrow.GetComponent<LineRenderer>().enabled = false;
        }

        public void Show()
        {
            _lineRenderer.enabled = true;
            _interGraphArrow.GetComponent<LineRenderer>().enabled = true;
        }

        public void Destroy()
        {
            Destroy(_lineRenderer);
            Destroy(_interGraphArrow);
        }

        public void Highlight()
        {
            _lineRenderer.startColor = Animating.Animation.Instance.relationColor;
            _lineRenderer.endColor = Animating.Animation.Instance.relationColor;
        }

        public void UnHighlight()
        {
            _lineRenderer.startColor = Color.white;
            _lineRenderer.endColor = Color.white;
        }
    }
}