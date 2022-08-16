using System;

namespace ApiDescriptions.Grpc
{
    public class MissedPositionsInProps : Exception
    {
        public MissedPositionsInProps() : base("Missed Positions In Props")
        {
            
        }
        public MissedPositionsInProps(string message) : base($"Missed Positions In Props: {message}")
        {
            
        }
        
    }
}