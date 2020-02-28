namespace GradConnect.ViewModels
{
    public class TablePartialVM
    {
        public int Id { get; set; }
        public string Controller { get; set; }

        public TablePartialVM()
        {

        }

        public TablePartialVM(int id, string controller)
        {
            Id = id;
            Controller = controller;
        }
    }
}