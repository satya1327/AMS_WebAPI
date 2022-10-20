using Approval_Api.ServiceModel.DTO;
using Approval_Api.DataModel_.entities;
using AutoMapper;
using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.ServiceModel.DTO.Request;

namespace Approval_Api.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Request, RequestDetailsDTO>().ReverseMap();
            CreateMap<Request, RequestDataDTO>().ReverseMap();
            CreateMap<Employee, UserRequestDTO>().ReverseMap();
            CreateMap<Employee, AuthenticateRequestDTO>().ReverseMap();
            CreateMap<Employee, AuthenticateResponseDTO>().ReverseMap();
            
            CreateMap<Upload, UploadFileDTO>().ReverseMap();
        }
    }
}

