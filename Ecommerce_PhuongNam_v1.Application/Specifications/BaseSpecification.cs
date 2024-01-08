﻿using System.Linq.Expressions;
using Ecommerce_PhuongNam_v1.Application.Specifications.Interfaces;
using Microsoft.Data.SqlClient;

namespace Ecommerce_PhuongNam_v1.Application.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    /// <summary>
    /// Create Criteria in query
    /// </summary>
    /// <param name="criteria">Criteria</param>
    /// <param name="checkStatus">Default is True, If True then query add condition is active, else query not check condition status</param>
    protected BaseSpecification(Expression<Func<T, bool>> criteria = null, bool checkStatus = true)
    {
        Criteria = criteria;
        CheckStatus = checkStatus;
    }
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    public List<Func<IQueryable<T>, IQueryable<T>>> IncludeConditions { get; } = new List<Func<IQueryable<T>, IQueryable<T>>>();
    public bool CheckStatus { get; set; }
    public List<string> IncludeStrings { get; } = new List<string>();
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDescending { get; private set; }
    public Expression<Func<T, object>> GroupBy { get; private set; }
    public String SqlQuery { get; private set; }
    private readonly List<SqlParameter> _parameters = new List<SqlParameter>();

    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; } = false;

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString, Func<IQueryable<T>, IQueryable<T>> condition = null)
    {
        IncludeStrings.Add(includeString);
        if (condition != null)
        {
            IncludeConditions.Add(condition);
        }
    }
    
    public virtual IQueryable<T> ApplyIncludeConditions(IQueryable<T> query)
    {
        foreach (var condition in IncludeConditions)
        {
            query = condition(query);
        }

        return query;
    }

    public virtual void AddSqlQuery (string sqlQuery)
    {
        SqlQuery = sqlQuery;
    }

    public virtual IEnumerable<SqlParameter> GetParameters()
    {
        return _parameters;
    }

    protected virtual void ApplyPaging(int skip, int take)
    {
        Skip = (skip - 1)*take;
        Take = take;
        IsPagingEnabled = true;
    }

    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }

    protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
    {
        GroupBy = groupByExpression;
    }

    protected void AddParameter(string parameterName, object value)
    {
        var sqlParameter = new SqlParameter(parameterName: parameterName, value: value);
        _parameters.Add(sqlParameter);
    }
    
}