namespace _8mpBl.Factory.Interfaces
{
    public interface IRouteApi
    {
        object GetRoutingDetail(string vRoute, string vOperation);
        object GetRoutingDetail(string vSlug);
        object GetNextCode(string vSlug);
    }
}
