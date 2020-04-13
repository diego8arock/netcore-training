using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Application.Dto;

namespace Training.Application.Services
{
    public interface IVideoService
    {
        Task AddVideo(VideoDto dto);
        Task RemoveVideo(Guid id);
        Task<IEnumerable<VideoDto>> GetVideos();
        Task<VideoDto> GetVideo(Guid id);
    }
}