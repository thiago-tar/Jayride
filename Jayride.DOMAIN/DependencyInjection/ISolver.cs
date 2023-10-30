namespace Jayride.Domain.DependencyInjection
{
    public interface ISolver
    {
        T Resolve<T>();
    }
}