using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Application.Dto;
using Training.Data.Domain;

namespace Training.Application.Services
{
    public class VideoService : IVideoService
    {
        #region Properties & Members

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region Constructors

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        #endregion

        #region IVideoService Implementation

        public async Task AddVideo(VideoDto dto)
        {
            var videoEntity = new Video
            {
                Id = dto.Id,
                Name = dto.Name,
                DirectedBy = dto.DirectedBy,
                Duration = dto.Duration,
                Genre = dto.Genre,
                CreationDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            await _videoRepository.AddAsync(videoEntity);

            dto.Id = videoEntity.Id;
        }

        public async Task<VideoDto> GetVideo(Guid id)
        {
            var video = await _videoRepository.GetAsync(id);

            return new VideoDto
            {
                Id = video.Id,
                Name = video.Name,
                DirectedBy = video.DirectedBy,
                Duration = video.Duration,
                Genre = video.Genre
            };
        }

        public async Task<IEnumerable<VideoDto>> GetVideos()
        {
            var videos = await _videoRepository.GetAllAsync();

            return videos.Select(x => new VideoDto
            {
                Id = x.Id,
                Name = x.Name,
                DirectedBy = x.DirectedBy,
                Duration = x.Duration,
                Genre = x.Genre
            });
        }

        public async Task RemoveVideo(Guid id)
        {
            var video = await _videoRepository.GetAsync(id);

            await _videoRepository.RemoveAsync(video);
        }

        #endregion
    }
}