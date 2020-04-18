using Data.DataServices.IDataServices;

namespace Data.Domain.DataManager
{
    public class DataManager
    {
        public ITextFieldRepository TextFieldServise { get; private set; }
        public IServiceItemRepository ServiceItemService { get; private set; }

        public DataManager(ITextFieldRepository textFieldRepository, IServiceItemRepository serviceItemRepository)
        {
            TextFieldServise = textFieldRepository;
            ServiceItemService = serviceItemRepository;
        }
    }
}
