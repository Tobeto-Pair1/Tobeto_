using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        IMapper _mapper;
        public AnnouncementManager(IAnnouncementDal announcementDal,IMapper mapper)
        {
            _announcementDal = announcementDal;
            _mapper = mapper;
        }
        public async Task<CreatedAnnouncementResponse> Add(CreateAnnouncementRequest createAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
            Announcement createdAnnouncement = await _announcementDal.AddAsync(announcement);
            CreatedAnnouncementResponse createdAnnouncementResponse = _mapper.Map<CreatedAnnouncementResponse>(createdAnnouncement);
            return createdAnnouncementResponse;
        }

        public  async Task<DeletedAnnouncementResponse> Delete(DeleteAnnouncementRequest deleteAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(deleteAnnouncementRequest);
            Announcement deletedAnnouncement = await _announcementDal.DeleteAsync(announcement);
            DeletedAnnouncementResponse deletedAnnouncementResponse = _mapper.Map<DeletedAnnouncementResponse>(deletedAnnouncement);
            return deletedAnnouncementResponse;
        }

        public async Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _announcementDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListAnnouncementResponse>>(data);
            return result;
        }

        public async Task<UpdatedAnnouncementResponse> Update(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(updateAnnouncementRequest);
            Announcement updateAnnouncement = await _announcementDal.UpdateAsync(announcement);
            UpdatedAnnouncementResponse updatedAnnouncementResponse = _mapper.Map<UpdatedAnnouncementResponse>(updateAnnouncement);
            return updatedAnnouncementResponse;
        }
    }
}
