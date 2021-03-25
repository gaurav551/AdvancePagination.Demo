using System;
using AdvancePagination.Demo.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace AdvancePagination.Demo.Services
{
    public interface IUriService
    {
       Uri GetPageUri(PaginationFilter filter, string route);  
    }
    public class UriService : IUriService
    {
private readonly string _baseUri;
    public UriService(string baseUri)
    {
        _baseUri = baseUri;
    }
    public Uri GetPageUri(PaginationFilter filter, string route)
    {
        var _enpointUri = new Uri(string.Concat(_baseUri, route));
        var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
        modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
        return new Uri(modifiedUri);
    }
    }
}