using Gytts.Home.PropertyManagement.DataAccessLayer.Entities;

namespace Gytts.Home.PropertyManagement.DataAccessLayer.Data;

public interface IPropertyData
{
    Task DeleteProperty(int id);
    Task<IEnumerable<PropertyEntity>> GetProperties();
    Task<PropertyEntity?> GetProperty(int id);
    Task InsertProperty(PropertyEntity property);
    Task UpdateProperty(PropertyEntity property);
}