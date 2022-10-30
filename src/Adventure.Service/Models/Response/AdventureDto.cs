namespace Adventure.Service.Models.Response
{
    public class AdventureDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public AdventureSelectionDto Selections { get; set; } = null!;
    }

    public static class AdventureExtension
    {
        public static AdventureDto ToDto(this Domain.DomainModels.AdventureModels.Adventure obj)
        {
            return new AdventureDto()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }
        public static AdventureDto ToDetailDto(this Domain.DomainModels.AdventureModels.Adventure obj)
        {
            return new AdventureDto()
            {
                Id = obj.Id,
                Name = obj.Name,
                Selections = obj.SelectionTree.ToSelectionDto()
            };
        }
    }
}
