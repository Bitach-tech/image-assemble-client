namespace Features.Global.Services.Updaters.Runtime.Abstract
{
    public interface IPostFixedUpdatable
    {
        void OnPostFixedUpdate(float delta);
    }
}