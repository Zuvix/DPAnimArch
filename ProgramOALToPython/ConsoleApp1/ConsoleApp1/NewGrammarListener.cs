//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from NewGrammar.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="NewGrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface INewGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.lines"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLines([NotNull] NewGrammarParser.LinesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.lines"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLines([NotNull] NewGrammarParser.LinesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] NewGrammarParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] NewGrammarParser.LineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.parCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParCommand([NotNull] NewGrammarParser.ParCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.parCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParCommand([NotNull] NewGrammarParser.ParCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.ifCommnad"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfCommnad([NotNull] NewGrammarParser.IfCommnadContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.ifCommnad"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfCommnad([NotNull] NewGrammarParser.IfCommnadContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.whileCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileCommand([NotNull] NewGrammarParser.WhileCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.whileCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileCommand([NotNull] NewGrammarParser.WhileCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.foreachCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForeachCommand([NotNull] NewGrammarParser.ForeachCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.foreachCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForeachCommand([NotNull] NewGrammarParser.ForeachCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.continueCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContinueCommand([NotNull] NewGrammarParser.ContinueCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.continueCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContinueCommand([NotNull] NewGrammarParser.ContinueCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.breakCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBreakCommand([NotNull] NewGrammarParser.BreakCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.breakCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBreakCommand([NotNull] NewGrammarParser.BreakCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.commentCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommentCommand([NotNull] NewGrammarParser.CommentCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.commentCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommentCommand([NotNull] NewGrammarParser.CommentCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryCreate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQueryCreate([NotNull] NewGrammarParser.ExeCommandQueryCreateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryCreate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQueryCreate([NotNull] NewGrammarParser.ExeCommandQueryCreateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryRelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQueryRelate([NotNull] NewGrammarParser.ExeCommandQueryRelateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryRelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQueryRelate([NotNull] NewGrammarParser.ExeCommandQueryRelateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQuerySelect([NotNull] NewGrammarParser.ExeCommandQuerySelectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQuerySelect([NotNull] NewGrammarParser.ExeCommandQuerySelectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelectRelatedBy"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQuerySelectRelatedBy([NotNull] NewGrammarParser.ExeCommandQuerySelectRelatedByContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelectRelatedBy"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQuerySelectRelatedBy([NotNull] NewGrammarParser.ExeCommandQuerySelectRelatedByContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryDelete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQueryDelete([NotNull] NewGrammarParser.ExeCommandQueryDeleteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryDelete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQueryDelete([NotNull] NewGrammarParser.ExeCommandQueryDeleteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryUnrelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandQueryUnrelate([NotNull] NewGrammarParser.ExeCommandQueryUnrelateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryUnrelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandQueryUnrelate([NotNull] NewGrammarParser.ExeCommandQueryUnrelateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandAssignment([NotNull] NewGrammarParser.ExeCommandAssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandAssignment([NotNull] NewGrammarParser.ExeCommandAssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandCall([NotNull] NewGrammarParser.ExeCommandCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandCall([NotNull] NewGrammarParser.ExeCommandCallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandCreateList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandCreateList([NotNull] NewGrammarParser.ExeCommandCreateListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandCreateList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandCreateList([NotNull] NewGrammarParser.ExeCommandCreateListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandAddingToList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandAddingToList([NotNull] NewGrammarParser.ExeCommandAddingToListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandAddingToList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandAddingToList([NotNull] NewGrammarParser.ExeCommandAddingToListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandWrite"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandWrite([NotNull] NewGrammarParser.ExeCommandWriteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandWrite"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandWrite([NotNull] NewGrammarParser.ExeCommandWriteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.exeCommandRead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExeCommandRead([NotNull] NewGrammarParser.ExeCommandReadContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.exeCommandRead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExeCommandRead([NotNull] NewGrammarParser.ExeCommandReadContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] NewGrammarParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] NewGrammarParser.ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.instanceHandle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstanceHandle([NotNull] NewGrammarParser.InstanceHandleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.instanceHandle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstanceHandle([NotNull] NewGrammarParser.InstanceHandleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.instanceName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstanceName([NotNull] NewGrammarParser.InstanceNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.instanceName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstanceName([NotNull] NewGrammarParser.InstanceNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.keyLetter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKeyLetter([NotNull] NewGrammarParser.KeyLetterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.keyLetter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKeyLetter([NotNull] NewGrammarParser.KeyLetterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.whereExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhereExpression([NotNull] NewGrammarParser.WhereExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.whereExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhereExpression([NotNull] NewGrammarParser.WhereExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] NewGrammarParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] NewGrammarParser.StartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.className"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassName([NotNull] NewGrammarParser.ClassNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.className"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassName([NotNull] NewGrammarParser.ClassNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.variableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableName([NotNull] NewGrammarParser.VariableNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.variableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableName([NotNull] NewGrammarParser.VariableNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.methodName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMethodName([NotNull] NewGrammarParser.MethodNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.methodName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMethodName([NotNull] NewGrammarParser.MethodNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttribute([NotNull] NewGrammarParser.AttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttribute([NotNull] NewGrammarParser.AttributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] NewGrammarParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] NewGrammarParser.StringContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.relationshipLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationshipLink([NotNull] NewGrammarParser.RelationshipLinkContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.relationshipLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationshipLink([NotNull] NewGrammarParser.RelationshipLinkContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="NewGrammarParser.relationshipSpecification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationshipSpecification([NotNull] NewGrammarParser.RelationshipSpecificationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="NewGrammarParser.relationshipSpecification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationshipSpecification([NotNull] NewGrammarParser.RelationshipSpecificationContext context);
}
