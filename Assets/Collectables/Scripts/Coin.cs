namespace Rara.Collectables
{
    public class Coin : BaseCollectable<Coin>
    {
        public override void Collect()
        {
            _transform.gameObject.SetActive(false);
            base.Collect();
        }
    }
}
