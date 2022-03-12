public class Clock : PickUps
{
    public bool addTime; //true dodaje, false odejmuje czas
    public int time = 5;

    public override void Picked()
    {
        if (addTime)
        {
            GameManager.gameManager.AddTime(time);
            
        }

        else
        {
            GameManager.gameManager.AddTime(time * (-1));
            
        }
        Destroy(this.gameObject);

    }
}
