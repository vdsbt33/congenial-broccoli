using Core.Interface.Model.Product;

namespace Core.Interface.Dal
{
    public interface IBase
    {
        IProductInfo Get( int id );
        bool Insert( IProductInfo product );
        bool Delete( IProductInfo product );
        bool Update( IProductInfo product );
    }
}
