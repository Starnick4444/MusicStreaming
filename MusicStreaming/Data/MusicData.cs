using MusicStreamingServer.DbAccess;
using MusicStreamingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingServer.Data;
internal class MusicData : IMusicData
{
    private readonly ISqlDataAccess _db;

    public MusicData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<MusicModel>> GetAllMusic() => _db.LoadData<MusicModel, dynamic>("dbo.spMusic_GetAll", new { });

    public async Task<MusicModel?> GetMusic(string title)
    {
        var result = await _db.LoadData<MusicModel, dynamic>("dbo.spMusic_Get", new { Title = title });
        return result.FirstOrDefault();
    }

    public async Task<int> InsertMusic(MusicModel music)
    {
        var result = await _db.LoadData<int, MusicModel>("dbo.spMusic_Insert", music);
        return result.FirstOrDefault();
    }

    public Task UpdateMusic(MusicModel music) => _db.SaveData("dbo.spMusic_Update", music);

    public Task DeleteMusic(string title) => _db.SaveData("dbo.spMusic_Delete", new { Title = title });

    public Task<IEnumerable<string>> GetAllTitle() => _db.LoadData<string, dynamic>("dbo.spMusic_GetAllTitle", new { });
}
