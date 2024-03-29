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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="NewGrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface INewGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.lines"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLines([NotNull] NewGrammarParser.LinesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] NewGrammarParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.parCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParCommand([NotNull] NewGrammarParser.ParCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.ifCommnad"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfCommnad([NotNull] NewGrammarParser.IfCommnadContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.whileCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileCommand([NotNull] NewGrammarParser.WhileCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.foreachCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeachCommand([NotNull] NewGrammarParser.ForeachCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.continueCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinueCommand([NotNull] NewGrammarParser.ContinueCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.breakCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreakCommand([NotNull] NewGrammarParser.BreakCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.commentCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommentCommand([NotNull] NewGrammarParser.CommentCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryCreate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryCreate([NotNull] NewGrammarParser.ExeCommandQueryCreateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryRelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryRelate([NotNull] NewGrammarParser.ExeCommandQueryRelateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQuerySelect([NotNull] NewGrammarParser.ExeCommandQuerySelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQuerySelectRelatedBy"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQuerySelectRelatedBy([NotNull] NewGrammarParser.ExeCommandQuerySelectRelatedByContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryDelete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryDelete([NotNull] NewGrammarParser.ExeCommandQueryDeleteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandQueryUnrelate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandQueryUnrelate([NotNull] NewGrammarParser.ExeCommandQueryUnrelateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandAssignment([NotNull] NewGrammarParser.ExeCommandAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandCall([NotNull] NewGrammarParser.ExeCommandCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandCreateList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandCreateList([NotNull] NewGrammarParser.ExeCommandCreateListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandAddingToList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandAddingToList([NotNull] NewGrammarParser.ExeCommandAddingToListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandWrite"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandWrite([NotNull] NewGrammarParser.ExeCommandWriteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.exeCommandRead"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExeCommandRead([NotNull] NewGrammarParser.ExeCommandReadContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] NewGrammarParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.instanceHandle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInstanceHandle([NotNull] NewGrammarParser.InstanceHandleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.instanceName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInstanceName([NotNull] NewGrammarParser.InstanceNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.keyLetter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKeyLetter([NotNull] NewGrammarParser.KeyLetterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.whereExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhereExpression([NotNull] NewGrammarParser.WhereExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] NewGrammarParser.StartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.className"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassName([NotNull] NewGrammarParser.ClassNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.variableName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableName([NotNull] NewGrammarParser.VariableNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.methodName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMethodName([NotNull] NewGrammarParser.MethodNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] NewGrammarParser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] NewGrammarParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.relationshipLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationshipLink([NotNull] NewGrammarParser.RelationshipLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="NewGrammarParser.relationshipSpecification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationshipSpecification([NotNull] NewGrammarParser.RelationshipSpecificationContext context);
}
