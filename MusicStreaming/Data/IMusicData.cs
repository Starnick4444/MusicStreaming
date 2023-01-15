using MusicStreamingServer.Models;

namespace MusicStreamingServer.Data;
internal interface IMusicData
{
    Task DeleteMusic(string title);
    Task<IEnumerable<MusicModel>> GetAllMusic();
    Task<IEnumerable<string>> GetAllTitle();
    Task<MusicModel?> GetMusic(string title);
    Task InsertMusic(MusicModel music);
    Task UpdateMusic(MusicModel music);
}