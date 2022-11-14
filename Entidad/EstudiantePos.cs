namespace Entidad
{
    public class EstudiantePos : Estudiante
    {


        public string ProgramaPosgrado { get; set; }
        public double PromedioSemestre { get; set; }
        public override string ToString()
        {
            return $"{TipoEstudiante};{NoDocumento};{Nombre};{Apellido};{ProgramaPosgrado};{Semestre};{PromedioSemestre}";
        }
    }
}
