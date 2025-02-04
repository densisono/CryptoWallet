//------------------------------------------------------------------------------
// Clase Wallets generada automáticamente con CrearClaseSQL
// de la tabla 'Wallets' de la base 'CryptoWallets'
// Fecha: 24/Jan/2025 00:32:57
//
// ©Guillermo Som (elGuille), 2004-2025
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
// Por si se utiliza Microsoft.Data en lugar de System.Data.
using Microsoft.Data.SqlClient;
//
public class Wallets{
    // Las variables privadas
    // TODO: Revisar los tipos de los campos
    private System.String m_Name;
    private System.String m_Abbreviation;
    private System.String m_Description;
    private System.String m_Platform;
    private System.String m_Notes;
    private System.String m_WalletName;
    //
    /// <summary>
    ///  Este método se usará para ajustar los anchos de las propiedades
    /// </summary>
    private string ajustarAncho(string cadena, int ancho){
        System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' 'c, ancho));
        // devolver la cadena quitando los espacios en blanco
        // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        return (cadena + sb.ToString()).Substring(0, ancho).Trim();
    }

    //------------------------------------------------------------------
    // Las propiedades públicas
    // TODO: Revisar los tipos de las propiedades
    //------------------------------------------------------------------
    public override System.Int32 CryptoID{
        get; set; }
    public System.String Name{
        get{
            return ajustarAncho(m_Name,100);
        }
        set{
            m_Name = value;
        }
    }
    public System.String Abbreviation{
        get{
            return ajustarAncho(m_Abbreviation,10);
        }
        set{
            m_Abbreviation = value;
        }
    }
    public System.String Description{
        get{
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(m_Description,2147483647);
            return  m_Description;
        }
        set{
            m_Description = value;
        }
    }
    public System.DateTime CreatedAt{
        get; set; }
    public System.DateTime UpdatedAt{
        get; set; }
    public System.DateTime DeletedAt{
        get; set; }
    public override System.Int32 AppID{
        get; set; }
    public System.String Platform{
        get{
            return ajustarAncho(m_Platform,50);
        }
        set{
            m_Platform = value;
        }
    }
    public System.String Notes{
        get{
            // Seguramente sería mejor sin ajustar el ancho...
            //return ajustarAncho(m_Notes,2147483647);
            return  m_ ! es;
        }
        set{
            m_Notes = value;
        }
    }
    public override System.Int32 WalletID{
        get; set; }
    public System.String WalletName{
        get{
            return ajustarAncho(m_WalletName,100);
        }
        set{
            m_WalletName = value;
        }
    }
    public System.Int32 ApplicationID{
        get; set; }

    /// <summary>
    ///  Propiedad predeterminada (indizador) Permite acceder mediante un índice numérico
    /// </summary>
    public string this[int index]{
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde con la columna de la tabla)
        get{
            if(index == 0){
                return this.CryptoID.ToString();
            }else if(index == 1){
                return this.Name.ToString();
            }else if(index == 2){
                return this.Abbreviation.ToString();
            }else if(index == 3){
                return this.Description.ToString();
            }else if(index == 4){
                return this.CreatedAt.ToString();
            }else if(index == 5){
                return this.UpdatedAt.ToString();
            }else if(index == 6){
                return this.DeletedAt.ToString();
            }else if(index == 7){
                return this.AppID.ToString();
            }else if(index == 8){
                return this.Platform.ToString();
            }else if(index == 9){
                return this. ! es.ToString();
            }else if(index == 10){
                return this.WalletID.ToString();
            }else if(index == 11){
                return this.WalletName.ToString();
            }else if(index == 12){
                return this.ApplicationID.ToString();
            }
            // Para que no de error el compilador de C# y
            // se devuelva el valor <NULO> en caso de que no exista ese campo.
            return "<NULO>";
        }
        set{
            if(index == 0){
                this.CryptoID = ConversorTipos.Int32Data(value);
            }else if(index == 1){
                this.Name = value;
            }else if(index == 2){
                this.Abbreviation = value;
            }else if(index == 3){
                this.Description = value;
            }else if(index == 4){
                this.CreatedAt = ConversorTipos.DateTimeData(value);
            }else if(index == 5){
                this.UpdatedAt = ConversorTipos.DateTimeData(value);
            }else if(index == 6){
                this.DeletedAt = ConversorTipos.DateTimeData(value);
            }else if(index == 7){
                this.AppID = ConversorTipos.Int32Data(value);
            }else if(index == 8){
                this.Platform = value;
            }else if(index == 9){
                this.Notes = value;
            }else if(index == 10){
                this.WalletID = ConversorTipos.Int32Data(value);
            }else if(index == 11){
                this.WalletName = value;
            }else if(index == 12){
                this.ApplicationID = ConversorTipos.Int32Data(value);
            }
        }
    }
    /// <summary>
    ///  Propiedad predeterminada (indizador) Permite acceder mediante el nombre de una columna
    /// </summary>
    public string this[string index]{
        // Devuelve el contenido del campo indicado en index
        // (el índice corresponde al nombre de la columna)
        get{
            if(index == "CryptoID"){
                return this.CryptoID.ToString();
            }else if(index == "Name"){
                return this.Name.ToString();
            }else if(index == "Abbreviation"){
                return this.Abbreviation.ToString();
            }else if(index == "Description"){
                return this.Description.ToString();
            }else if(index == "CreatedAt"){
                return this.CreatedAt.ToString();
            }else if(index == "UpdatedAt"){
                return this.UpdatedAt.ToString();
            }else if(index == "DeletedAt"){
                return this.DeletedAt.ToString();
            }else if(index == "AppID"){
                return this.AppID.ToString();
            }else if(index == "Platform"){
                return this.Platform.ToString();
            }else if(index == " ! es"){
                return this. ! es.ToString();
            }else if(index == "WalletID"){
                return this.WalletID.ToString();
            }else if(index == "WalletName"){
                return this.WalletName.ToString();
            }else if(index == "ApplicationID"){
                return this.ApplicationID.ToString();
            }
            // Para que no de error el compilador de C# y
            // se devuelva el valor <NULO> en caso de que no exista ese campo.
            return "<NULO>";
        }
        set{
            if(index == "CryptoID"){
                this.CryptoID = ConversorTipos.Int32Data(value);
            }else if(index == "Name"){
                this.Name = value;
            }else if(index == "Abbreviation"){
                this.Abbreviation = value;
            }else if(index == "Description"){
                this.Description = value;
            }else if(index == "CreatedAt"){
                this.CreatedAt = ConversorTipos.DateTimeData(value);
            }else if(index == "UpdatedAt"){
                this.UpdatedAt = ConversorTipos.DateTimeData(value);
            }else if(index == "DeletedAt"){
                this.DeletedAt = ConversorTipos.DateTimeData(value);
            }else if(index == "AppID"){
                this.AppID = ConversorTipos.Int32Data(value);
            }else if(index == "Platform"){
                this.Platform = value;
            }else if(index == " ! es"){
                this.Notes = value;
            }else if(index == "WalletID"){
                this.WalletID = ConversorTipos.Int32Data(value);
            }else if(index == "WalletName"){
                this.WalletName = value;
            }else if(index == "ApplicationID"){
                this.ApplicationID = ConversorTipos.Int32Data(value);
            }
        }
    }

    //-------------------------------------------------------------------------
    // Campos y métodos compartidos (estáticos) para gestionar la base de datos
    //-------------------------------------------------------------------------

    /// <summary>
    ///  La cadena de conexión a la base de datos.
    ///  Definida Public para poder asignar otro valor
    ///  por si se usan diferentes bases de datos.
    /// </summary>

    public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
    ///<summary> La cadena de selección</summary>
    public static string CadenaSelect = "SELECT * FROM Wallets";

    public Wallets(){
    }
    public Wallets(string conex){
        CadenaConexion = conex;
    }

    //------------------
    // Métodos públicos
    //------------------

    /// <summary>
    ///  Devuelve una tabla con los datos indicados en la cadena de selección
    /// </summary>

    public static DataTable Tabla(){
        return Tabla(CadenaSelect);
    }
    public static DataTable Tabla(string sel){
        // devuelve una tabla con los datos de la tabla Wallets
        SqlDataAdapter da;
        DataTable dt = new DataTable("Wallets");

        try{
            da = new SqlDataAdapter(sel, CadenaConexion);
            da.Fill(dt);
        }catch{
            return  null ;
        }

        return dt;
    }

    /// <summary>
    ///  Busca en la tabla los datos indicados en el parámetro.
    ///  El parámetro contendrá lo que se usará después del WHERE.
    ///  Si no se encuentra lo buscado, se devuelve un valor nulo.
    /// </summary>
    public static Wallets Buscar(string sWhere){
        Wallets o_Wallets =  null ;
        string sel = "SELECT * FROM Wallets WHERE " + sWhere;
        using (SqlConnection con = new SqlConnection(CadenaConexion)){
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = sel;
            try{
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    o_Wallets = Reader2Tipo(reader);
                    if(o_Wallets.ID > 0){
                        break;
                    }
                }
                reader.Close();
                con.Close();
            }catch(Exception ex){
                return  null ;

            finally{
              // Comprobar si la conexión sigue abierta. (14/may/23)
              if(  !  (con  ==   null )){
                  con.Close();
              }
            }
        }

        return o_Wallets;
    }

    /// <summary>
    ///  Actualizar: Actualiza los datos en la tabla usando la instancia actual
    ///  Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    ///  Para comprobar si el objeto en memoria coincide con uno existente,
    ///  se comprueba si el WalletID existe en la tabla.
    ///  TODO: Si en lugar de WalletID usas otro campo, indicalo en la cadena SELECT
    ///  También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    /// </summary>
    public override string Actualizar(){
        // TODO: Poner aquí la selección a realizar para acceder a este registro
        //       yo uso el WalletID que es el identificador único de cada registro
        string sel = "SELECT * FROM Wallets WHERE WalletID = " + this.WalletID.ToString();
        return Actualizar(sel);
    }

    /// <summary>
    ///  Actualiza los datos de la instancia actual.
    ///  En caso de error, devolverá la cadena de error empezando por ERROR:.
    /// </summary>
    /// <summary>
    ///  Si la instancia no hace referencia a un registro existente, se creará uno nuevo.
    /// </summary>
    public override string Actualizar(string sel){
        // Actualiza los datos indicados
        // El parámetro, que es una cadena de selección, indicará el criterio de actualización

        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Wallets");

        cnn = new SqlConnection(CadenaConexion);
        //da = new SqlDataAdapter(CadenaSelect, cnn);
        da = new SqlDataAdapter(sel, cnn);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.UpdateCommand = cb.GetUpdateCommand();

        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        //string sCommand;
        ////
        //// El comando UPDATE
        //// TODO: Comprobar cual es el campo de índice principal (sin duplicados)
        ////       Yo compruebo que sea un campo llamado WalletID, pero en tu caso puede ser otro
        ////       Ese campo, (en mi caso WalletID) será el que hay que poner al final junto al WHERE.
        //sCommand = "UPDATE Wallets SET CryptoID = @CryptoID, Name = @Name, Abbreviation = @Abbreviation, Description = @Description, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt, DeletedAt = @DeletedAt, AppID = @AppID, Platform = @Platform,  ! es = @ ! es, WalletName = @WalletName, ApplicationID = @ApplicationID  WHERE (WalletID = @WalletID)";
        //da.UpdateCommand = new SqlCommand(sCommand, cnn);
        //da.UpdateCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
        //da.UpdateCommand.Parameters.AddWithValue("@Name", Name);
        //da.UpdateCommand.Parameters.AddWithValue("@Abbreviation", Abbreviation);
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
        ////da.UpdateCommand.Parameters.AddWithValue("@Description", Description);
        //da.UpdateCommand.Parameters.AddWithValue("@Description", Description);
        //da.UpdateCommand.Parameters.AddWithValue("@CreatedAt", CreatedAt);
        //da.UpdateCommand.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
        //da.UpdateCommand.Parameters.AddWithValue("@DeletedAt", DeletedAt);
        //da.UpdateCommand.Parameters.AddWithValue("@AppID", AppID);
        //da.UpdateCommand.Parameters.AddWithValue("@Platform", Platform);
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
        ////da.UpdateCommand.Parameters.AddWithValue("@ ! es",  ! es);
        //da.UpdateCommand.Parameters.AddWithValue("@ ! es",  ! es);
        //da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);
        //da.UpdateCommand.Parameters.AddWithValue("@WalletName", WalletName);
        //da.UpdateCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }

        if(dt.Rows.Count == 0){
            // crear uno nuevo
            return Crear();
        }else{
            Wallets2Row(this, dt.Rows[0]);
        }

        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Actualizado correctamente";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }

    /// <summary>
    ///  Crear un nuevo registro
    ///  En caso de error, devolverá la cadena de error empezando por ERROR:.
    /// </summary>
    public override string Crear(){
        SqlConnection cnn;
        SqlDataAdapter da;
        DataTable dt = new DataTable("Wallets");

        cnn = new SqlConnection(CadenaConexion);
        da = new SqlDataAdapter(CadenaSelect, cnn);
        //da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        //-------------------------------------------
        // Esta no es la más óptima, pero funcionará
        //-------------------------------------------
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.InsertCommand = cb.GetInsertCommand();

        //--------------------------------------------------------------------
        // Esta está más optimizada pero debes comprobar que funciona bien...
        //--------------------------------------------------------------------
        //string sCommand;
        ////
        //// El comando INSERT
        //// TODO: No incluir el campo de clave primaria incremental
        ////       Yo compruebo que sea un campo llamado WalletID, pero en tu caso puede ser otro
        //sCommand = "INSERT INTO Wallets (Name, Abbreviation, Description, CreatedAt, UpdatedAt, DeletedAt, Platform,  ! es, WalletName, ApplicationID)  VALUES(@Name, @Abbreviation, @Description, @CreatedAt, @UpdatedAt, @DeletedAt, @Platform, @ ! es, @WalletName, @ApplicationID) ";
        //da.InsertCommand = new SqlCommand(sCommand, cnn);
        //da.InsertCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
        //da.InsertCommand.Parameters.AddWithValue("@Name", Name);
        //da.InsertCommand.Parameters.AddWithValue("@Abbreviation", Abbreviation);
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
        ////da.InsertCommand.Parameters.AddWithValue("@Description", Description);
        //da.InsertCommand.Parameters.AddWithValue("@Description", Description);
        //da.InsertCommand.Parameters.AddWithValue("@CreatedAt", CreatedAt);
        //da.InsertCommand.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
        //da.InsertCommand.Parameters.AddWithValue("@DeletedAt", DeletedAt);
        //da.InsertCommand.Parameters.AddWithValue("@AppID", AppID);
        //da.InsertCommand.Parameters.AddWithValue("@Platform", Platform);
        //// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
        ////da.InsertCommand.Parameters.AddWithValue("@ ! es",  ! es);
        //da.InsertCommand.Parameters.AddWithValue("@ ! es",  ! es);
        //da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);
        //da.InsertCommand.Parameters.AddWithValue("@WalletName", WalletName);
        //da.InsertCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);


        try{
            da.Fill(dt);
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }

        nuevoWallets(dt, this);

        try{
            da.Update(dt);
            dt.AcceptChanges();
            return "Se ha creado un nuevo Wallets";
        }catch(Exception ex){
            return "ERROR: " + ex.Message;
        }
    }

    /// <summary>
    ///  Borrar el registro con el mismo ID que tenga la clase.
    ///  NOTA: En caso de que quieras usar otro criterio
    ///  para comprobar cuál es el registro actual, cambia la comparación.
    /// </summary>
    public override string Borrar(){
        // TODO: Poner aquí la selección a realizar para acceder a este registro
        //       yo uso el WalletID que es el identificador único de cada registro
        string where = "WalletID = " + this.WalletID.ToString();

        return Borrar(where);
    }

    /// <summary>
    ///  Borrar el registro o los registros indicados en la cadena WHERE.
    ///  La cadena indicada se usará después de la cláusula WHERE de TSQL.
    ///  Ejemplo, si la cadena es: Nombre = 'Pepe' AND Telefono = '666777999'
    ///  Ejecutará: WHERE Nombre = 'Pepe' AND Telefono = '666777999'
    ///  Y borrará todos los registros de esta tabla que coincidan.
    /// </summary>
    public override string Borrar(string where){
        string msg = "";

        string sCon = CadenaConexion;
        string sel = "DELETE FROM Wallets WHERE " + where;

        using (SqlConnection con = new SqlConnection(sCon)){
            SqlTransaction tran =  null ;

            try{
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                //cmd.CommandText = "BorrarWallets";
                cmd.CommandText = sel;

                con.Open();
                tran = con.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                // Si llega aquí es que todo fue bien,
                // por tanto, llamamos al método Commit.
                tran.Commit();

                msg = "Eliminado correctamente los registros con : " + where + ".";

            }catch(Exception ex){
                msg = "ERROR al eliminar los registros con : " + where + "." + ex.Message;

              try{
                tran.Rollback();
              }catch(Exception ex2){
               msg = $"ERROR RollBack: {ex2.Message})";
              }

            finally{
              if(  !  (con  ==   null )){
                  con.Close();
              }
            }

        }

        return msg;
    }

    /// <summary>
    ///  Devuelve una colección de Wallets según la cadena select.
    /// </summary>
    public static List(Of Wallets) TablaCol(string sel){
        List(Of Wallets) col = new List(Of Wallets);

        using (SqlConnection con = new SqlConnection(CadenaConexion)){
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = sel;
            try{
                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                    Wallets r = Reader2Tipo(reader);
                    col.Add(r);
                }
                reader.Close();
                con.Close();
            }catch(Exception ex){
                return col;

            finally{
              // Comprobar si la conexión sigue abierta. (14/may/23)
              if(  !  (con  ==   null )){
                  con.Close();
              }
            }
        }

        return col;
    }

    /// <summary>
    ///  Asigna los datos desde un SqlDataReader.
    /// </summary>
    public static Wallets Reader2Tipo(SqlDataReader r){
        Wallets o_Wallets = new Wallets();

        o_Wallets.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
        o_Wallets.Name = r["Name"].ToString();
        o_Wallets.Abbreviation = r["Abbreviation"].ToString();
        o_Wallets.Description = r["Description"].ToString();
        o_Wallets.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
        o_Wallets.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
        o_Wallets.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
        o_Wallets.AppID = ConversorTipos.Int32Data(r["AppID"].ToString());
        o_Wallets.Platform = r["Platform"].ToString();
        o_Wallets.Notes = r[" ! es"].ToString();
        o_Wallets.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
        o_Wallets.WalletName = r["WalletName"].ToString();
        o_Wallets.ApplicationID = ConversorTipos.Int32Data(r["ApplicationID"].ToString());

        return o_Wallets;
    }

}
