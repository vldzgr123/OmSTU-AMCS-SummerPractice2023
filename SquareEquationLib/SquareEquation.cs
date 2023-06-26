﻿namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] ans=new double[2];
        double eps=Math.Pow(10,-9);
        if (Math.Abs(a)<eps){
            throw new System.ArgumentException();
        }
        if (double.IsNaN(a) || double.IsPositive(a)|| double.IsNaN(b) || double.IsPositive(b) || double.IsNaN(c) || double.IsPositive(c)){
            throw new System.ArgumentException();
        }
        double d=b*b-4*a*c;
        if (d<0 && !(Math.Abs(d)<eps) ){
            ans=new double[0];
        }
        if (d < eps){
            ans=new double[1];
            ans[0]=-(b+Math.Sign(b)+Math.Sqrt(d))/2;
        }
        if (d>0 && !(Math.Abs(d)<eps)){
            ans[0]=-(b+Math.Sign(b)*Math.Sqrt(d))/2;
            ans[1]=c/ans[0];
        }
        return ans;
    }
}
