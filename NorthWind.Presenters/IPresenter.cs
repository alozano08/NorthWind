namespace NorthWind.Presenters
{
    public  interface IPresenter<FormatDateYpe>
    {
        public FormatDateYpe Content { get; }
    }
}