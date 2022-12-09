using Raylib_cs;
using System.Numerics;

namespace Helloworld{
class Colors{

    protected List<Color> colorNames = new List<Color>();

    public Colors(){
        colorNames.Add(Color.RED);
        colorNames.Add(Color.ORANGE);
        colorNames.Add(Color.YELLOW);
        colorNames.Add(Color.GREEN);
        colorNames.Add(Color.BLUE);
        colorNames.Add(Color.PURPLE);
        colorNames.Add(Color.WHITE);
    }
    public Color randomColor(){
        Random random = new Random();
        int index = random.Next(0,6);
        Color color = colorNames[index];
        return color;

    }
}
class ColoredObject: Colors  {
    public Color Color { get; set; }

    public ColoredObject (){
        Color = this.randomColor();
    }

}



class FallingObject: ColoredObject{

    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    public int pointvalue {get; set; }= 0;

    public virtual bool CheckCollision(Rectangle rect){
        return false;
    }

    virtual public void Draw(){

    }
    public void Move() {
        Vector2 NewPosition = this.Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        this.Position = NewPosition;
    }
    }

class Gem: FallingObject{

    public int Size {get; set;} 

    public override bool CheckCollision(Rectangle rect){
        return Raylib.CheckCollisionRecs(rect,CollisonGem());
    }
    public Gem(int size){
        Size = size;
        pointvalue = -1;
    }
    public Rectangle CollisonGem(){
        return new Rectangle((int)Position.X, (int)Position.Y, Size, Size);
    }
    

    override public void Draw() {
        Raylib.DrawRectangleRec(CollisonGem(), Color);
    }
}

class Rock: FallingObject{
    public int Radius { get; set; }

    public Rock( int radius){
        Radius = radius;
        pointvalue = 1;
    }
    public override bool CheckCollision(Rectangle rect){
        return Raylib.CheckCollisionCircleRec(Position,Radius,rect);
    }
    override public void Draw() {
        Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);
    }

}

class Player{
    public Rectangle PlayerPosition {get;set;} = new Rectangle(400, 460,20,20);

        public void movement(){
            var newplayerposition = PlayerPosition;
            var PlayerMovementSpeed = 10;

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    newplayerposition.x += PlayerMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    newplayerposition.x -= PlayerMovementSpeed;
                }
                if (newplayerposition.x < 0){
                    newplayerposition.x = 0;
                }
                if (newplayerposition.x > 780){
                    newplayerposition.x = 780;
                }
                PlayerPosition = newplayerposition;
                Raylib.DrawRectangleRec(PlayerPosition, Color.MAROON);
            }   
        }

class Projectile: FallingObject{
    public int Size {get;set;}

    public override bool CheckCollision(Rectangle rect){
        return Raylib.CheckCollisionRecs(rect,CollisonProjectile());
    }
    public Projectile(int size){
        Size = size;
    }
    public Rectangle CollisonProjectile(){
        return new Rectangle((int)Position.X, (int)Position.Y, Size, Size);
    }
    override public void Draw() {
        Raylib.DrawRectangleRec(CollisonProjectile(), Color.GOLD);
    }

}
class Score{

    public int pointtotal {get; set;} = 0;
    public void scorekeeping(){
    Raylib.DrawText($"{pointtotal}",20,20,20,Color.WHITE);
    }
}    
}


