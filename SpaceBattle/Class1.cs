namespace SpaceBattle;
public class Class1
{
    public double[] coordinates=new double[2]{double.NaN,double.PositiveInfinity};
    public double[] speed= new double[2]{double.PositiveInfinity,double.NaN};
    public void SetCoordinates(double[] coordinates){
        this.coordinates=coordinates;
    }
    public void SetSpeed(double[] speed){
        this.speed=speed;
    }
    public bool CheckCoordinates(double[] CoordinatesOrSpeed){
        foreach(var coord in CoordinatesOrSpeed){
            if(double.IsNaN(coord)||double.IsInfinity(coord)){
                return false;
            }
        }
        return true;
    }
    public double[] ChangeCoordinates(double[] coordinates,double[] speed){
        if (CheckCoordinates(coordinates)&&CheckCoordinates(speed)){
            var newCoordinates=new double[2]{coordinates[0],coordinates[1]};
            newCoordinates[0]+=speed[0];
            newCoordinates[1]+=speed[1];
            return newCoordinates;
        }
        else{
            return new Exception();
        }
    }

}
