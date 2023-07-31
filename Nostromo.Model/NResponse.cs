namespace Nostromo.Model
{
    public enum MESSSAGE_TYPE { SUCCESS, INFORMATION, WARNING, ERROR }

    public class NResponse
    {
        public MESSSAGE_TYPE MsgType { get; set; }

        public string MsgText { get; set; }

        public object? MsgData { get; set; }

        #region Constructors
        public NResponse()
        {
            MsgType = MESSSAGE_TYPE.INFORMATION;
            MsgText = string.Empty;
            MsgData = null;
        }
        #endregion
    }
}
