namespace Entidad
{
    public class EstudiantePre : Estudiante
    {


        public string ProgramaPregrado { get; set; }
        public double PromedioCorte1 { get; set; }
        public double PromedioCorte2 { get; set; }
        public double PromedioCorte3 { get; set; }

        public override string ToString()
        {
            return $"{TipoEstudiante};{NoDocumento};{Nombre};{Apellido};{ProgramaPregrado};{Semestre};{PromedioCorte1};{PromedioCorte2};{PromedioCorte3}";
        }
    }
}
