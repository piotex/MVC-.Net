using OwlLibrary.Classes.Models.Basic;

namespace OwlLibrary.Interfaces
{
    public interface Interface_Action<T_Record> where T_Record : Model_TableRecord, new()
    {
        int DoAction(ref Model_Query<T_Record> tableModel) ;
    }
}
