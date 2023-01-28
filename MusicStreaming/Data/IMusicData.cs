using MusicStreamingServer.Models;

namespace MusicStreamingServer.Data;
internal interface IMusicData
{
    Task DeleteMusic(string title);
    Task<IEnumerable<MusicModel>> GetAllMusic();
    Task<IEnumerable<string>> GetAllTitle();
    Task<MusicModel?> GetMusic(string title);
    Task UpdateMusic(MusicModel music);
    Task<int> InsertMusic(MusicModel music);
}