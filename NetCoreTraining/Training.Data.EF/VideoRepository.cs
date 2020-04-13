using System;
using Training.Data.Domain;

namespace Training.Data.EF
{
    public class VideoRepository : Repository<Video, Guid>, IVideoRepository
    {
        public VideoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}