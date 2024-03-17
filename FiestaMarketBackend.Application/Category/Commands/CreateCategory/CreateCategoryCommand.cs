using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommand : IRequest
    {
        //public CreateCategoryCommand(string name, Guid parentCategoryId)
        //{
        //    Name = name;
        //    ParentCategoryID = parentCategoryId;
        //}

        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}
