namespace InventorySystem.Models
{
    public interface IOperationStatusService
    {
        bool OperationSuccess { get; set; }
    }

    public class OperationStatusService : IOperationStatusService
    {
        public bool OperationSuccess { get; set; }
    }

}
