using Gytts.Home.PropertyManagement.DataAccessLayer.DataAccess;
using Gytts.Home.PropertyManagement.DataAccessLayer.Entities;

namespace Gytts.Home.PropertyManagement.DataAccessLayer.Data;

public class PropertyData : IPropertyData
{
    private readonly ISqlDataAccess _db;

    public PropertyData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PropertyEntity>> GetProperties() =>
        _db.LoadData<PropertyEntity, dynamic>("dbo.spProperty_GetAll", new { });

    public async Task<PropertyEntity?> GetProperty(int id)
    {
        var results = await _db.LoadData<PropertyEntity, dynamic>(
            "dbo.spProperty_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertProperty(PropertyEntity property) =>
        _db.SaveData("dbo.spProperty_Insert", new { property.Name, property.Address });

    public Task UpdateProperty(PropertyEntity property) =>
        _db.SaveData("dbo.spProperty_Update", property);

    public Task DeleteProperty(int id) =>
        _db.SaveData("dbo.spProperty_Delete", new { Id = id });
}
