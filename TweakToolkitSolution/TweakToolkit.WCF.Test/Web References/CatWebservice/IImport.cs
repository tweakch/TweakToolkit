using System;
using System.Net;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace TweakToolkit.WCF.Test.CatWebservice
{
    public interface IImport
    {
        CookieContainer CookieContainer { get; set; }

        /// <remarks />
        event clearDatabaseCompletedEventHandler clearDatabaseCompleted;

        /// <remarks />
        event deleteAllBarragesCompletedEventHandler deleteAllBarragesCompleted;

        /// <remarks />
        event deleteAllBasevaluesCompletedEventHandler deleteAllBasevaluesCompleted;

        /// <remarks />
        event deleteAllDBFilesCompletedEventHandler deleteAllDBFilesCompleted;

        /// <remarks />
        event deleteAllEmittentenRatingLogosFromDiskCompletedEventHandler
            deleteAllEmittentenRatingLogosFromDiskCompleted;

        /// <remarks />
        event deleteAllEmittentenRatingLogosNotInDBCompletedEventHandler deleteAllEmittentenRatingLogosNotInDBCompleted;

        /// <remarks />
        event deleteAllEmittentenRatingsCompletedEventHandler deleteAllEmittentenRatingsCompleted;

        /// <remarks />
        event deleteAllEventsCompletedEventHandler deleteAllEventsCompleted;

        /// <remarks />
        event deleteAllFilesCompletedEventHandler deleteAllFilesCompleted;

        /// <remarks />
        event deleteAllFilesNotInDBCompletedEventHandler deleteAllFilesNotInDBCompleted;

        /// <remarks />
        event deleteAllFilesOfProductCompletedEventHandler deleteAllFilesOfProductCompleted;

        /// <remarks />
        event deleteBarrageOfProductByValorCompletedEventHandler deleteBarrageOfProductByValorCompleted;

        /// <remarks />
        event deleteBasevaluesOfProductByValorCompletedEventHandler deleteBasevaluesOfProductByValorCompleted;

        /// <remarks />
        event deleteEmittentenRatingForIDCompletedEventHandler deleteEmittentenRatingForIDCompleted;

        /// <remarks />
        event deleteEmittentenRatingForNameCompletedEventHandler deleteEmittentenRatingForNameCompleted;

        /// <remarks />
        event deleteEventsOfProductByValorCompletedEventHandler deleteEventsOfProductByValorCompleted;

        /// <remarks />
        event deleteFileByIDCompletedEventHandler deleteFileByIDCompleted;

        /// <remarks />
        event deleteFileByOriginalNameCompletedEventHandler deleteFileByOriginalNameCompleted;

        /// <remarks />
        event deleteFileByServerNameCompletedEventHandler deleteFileByServerNameCompleted;

        /// <remarks />
        event deletePricesByValorCompletedEventHandler deletePricesByValorCompleted;

        /// <remarks />
        event deleteProductByIDCompletedEventHandler deleteProductByIDCompleted;

        /// <remarks />
        event deleteProductByValorCompletedEventHandler deleteProductByValorCompleted;

        /// <remarks />
        event GetLoginStatusCompletedEventHandler GetLoginStatusCompleted;

        /// <remarks />
        event getMaxFileSizeCompletedEventHandler getMaxFileSizeCompleted;

        /// <remarks />
        event getValidExtensionsCompletedEventHandler getValidExtensionsCompleted;

        /// <remarks />
        event isLoggedInCompletedEventHandler isLoggedInCompleted;

        /// <remarks />
        event isValidExtensionCompletedEventHandler isValidExtensionCompleted;

        /// <remarks />
        event isValidFileSizeCompletedEventHandler isValidFileSizeCompleted;

        /// <remarks />
        event LoginCompletedEventHandler LoginCompleted;

        /// <remarks />
        event LogoutCompletedEventHandler LogoutCompleted;

        /// <remarks />
        event resetSystemCompletedEventHandler resetSystemCompleted;

        /// <remarks />
        event saveFileCompletedEventHandler saveFileCompleted;

        /// <remarks />
        event updateEmittentenRatingForIDCompletedEventHandler updateEmittentenRatingForIDCompleted;

        /// <remarks />
        event writeBarrageCompletedEventHandler writeBarrageCompleted;

        /// <remarks />
        event writeBasevalueCompletedEventHandler writeBasevalueCompleted;

        /// <remarks />
        event writeEmittentenRatingWithLogoCompletedEventHandler writeEmittentenRatingWithLogoCompleted;

        /// <remarks />
        event writeEventCompletedEventHandler writeEventCompleted;

        /// <remarks />
        event writePriceCompletedEventHandler writePriceCompleted;

        /// <remarks />
        event writeProductCompletedEventHandler writeProductCompleted;

        /// <remarks />
        event writeProductV2CompletedEventHandler writeProductV2Completed;

        /// <remarks />
         void CancelAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/clearDatabase",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] clearDatabase(bool doDeleteFilesFromDisk);

        /// <remarks />
        void clearDatabaseAsync(bool doDeleteFilesFromDisk);

        /// <remarks />
        void clearDatabaseAsync(bool doDeleteFilesFromDisk, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllBarrages",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllBarrages();

        /// <remarks />
        void deleteAllBarragesAsync();

        /// <remarks />
        void deleteAllBarragesAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllBasevalues",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllBasevalues();

        /// <remarks />
        void deleteAllBasevaluesAsync();

        /// <remarks />
        void deleteAllBasevaluesAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllDBFiles",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllDBFiles();

        /// <remarks />
        void deleteAllDBFilesAsync();

        /// <remarks />
        void deleteAllDBFilesAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllEmittentenRatingLogosFromDisk",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllEmittentenRatingLogosFromDisk(bool clearDBReference);

        /// <remarks />
        void deleteAllEmittentenRatingLogosFromDiskAsync(bool clearDBReference);

        /// <remarks />
        void deleteAllEmittentenRatingLogosFromDiskAsync(bool clearDBReference, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllEmittentenRatingLogosNotInDB",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllEmittentenRatingLogosNotInDB();

        /// <remarks />
        void deleteAllEmittentenRatingLogosNotInDBAsync();

        /// <remarks />
        void deleteAllEmittentenRatingLogosNotInDBAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllEmittentenRatings",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllEmittentenRatings(bool deleteLogosFromDisk);

        /// <remarks />
        void deleteAllEmittentenRatingsAsync(bool deleteLogosFromDisk);

        /// <remarks />
        void deleteAllEmittentenRatingsAsync(bool deleteLogosFromDisk, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllEvents",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllEvents();

        /// <remarks />
        void deleteAllEventsAsync();

        /// <remarks />
        void deleteAllEventsAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllFiles",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllFiles();

        /// <remarks />
        void deleteAllFilesAsync();

        /// <remarks />
        void deleteAllFilesAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllFilesNotInDB",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllFilesNotInDB();

        /// <remarks />
        void deleteAllFilesNotInDBAsync();

        /// <remarks />
        void deleteAllFilesNotInDBAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteAllFilesOfProduct",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteAllFilesOfProduct(int Valor);

        /// <remarks />
        void deleteAllFilesOfProductAsync(int Valor);

        /// <remarks />
        void deleteAllFilesOfProductAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteBarrageOfProductByValor",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteBarrageOfProductByValor(int Valor);

        /// <remarks />
        void deleteBarrageOfProductByValorAsync(int Valor);

        /// <remarks />
        void deleteBarrageOfProductByValorAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteBasevaluesOfProductByValor",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteBasevaluesOfProductByValor(int Valor);

        /// <remarks />
        void deleteBasevaluesOfProductByValorAsync(int Valor);

        /// <remarks />
        void deleteBasevaluesOfProductByValorAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteEmittentenRatingForID",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteEmittentenRatingForID(int emittentenId, bool deleteLogoFromDisk);

        /// <remarks />
        void deleteEmittentenRatingForIDAsync(int emittentenId, bool deleteLogoFromDisk);

        /// <remarks />
        void deleteEmittentenRatingForIDAsync(int emittentenId, bool deleteLogoFromDisk, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteEmittentenRatingForName",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteEmittentenRatingForName(string nameBank, bool deleteLogoFromDisk);

        /// <remarks />
        void deleteEmittentenRatingForNameAsync(string nameBank, bool deleteLogoFromDisk);

        /// <remarks />
        void deleteEmittentenRatingForNameAsync(string nameBank, bool deleteLogoFromDisk, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteEventsOfProductByValor",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteEventsOfProductByValor(int Valor);

        /// <remarks />
        void deleteEventsOfProductByValorAsync(int Valor);

        /// <remarks />
        void deleteEventsOfProductByValorAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteFileByID",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteFileByID(int ID);

        /// <remarks />
        void deleteFileByIDAsync(int ID);

        /// <remarks />
        void deleteFileByIDAsync(int ID, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteFileByOriginalName",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteFileByOriginalName(string FileName);

        /// <remarks />
        void deleteFileByOriginalNameAsync(string FileName);

        /// <remarks />
        void deleteFileByOriginalNameAsync(string FileName, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteFileByServerName",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteFileByServerName(string FileName);

        /// <remarks />
        void deleteFileByServerNameAsync(string FileName);

        /// <remarks />
        void deleteFileByServerNameAsync(string FileName, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deletePricesByValor",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deletePricesByValor(int Valor);

        /// <remarks />
        void deletePricesByValorAsync(int Valor);

        /// <remarks />
        void deletePricesByValorAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteProductByID",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteProductByID(int ID);

        /// <remarks />
        void deleteProductByIDAsync(int ID);

        /// <remarks />
        void deleteProductByIDAsync(int ID, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/deleteProductByValor",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] deleteProductByValor(int Valor);

        /// <remarks />
        void deleteProductByValorAsync(int Valor);

        /// <remarks />
        void deleteProductByValorAsync(int Valor, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/GetLoginStatus",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        string GetLoginStatus();

        /// <remarks />
        void GetLoginStatusAsync();

        /// <remarks />
        void GetLoginStatusAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/getMaxFileSize",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        long getMaxFileSize();

        /// <remarks />
        void getMaxFileSizeAsync();

        /// <remarks />
        void getMaxFileSizeAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/getValidExtensions",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        string[] getValidExtensions();

        /// <remarks />
        void getValidExtensionsAsync();

        /// <remarks />
        void getValidExtensionsAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/isLoggedIn",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        bool isLoggedIn();

        /// <remarks />
        void isLoggedInAsync();

        /// <remarks />
        void isLoggedInAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/isValidExtension",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        bool isValidExtension(string Filename);

        /// <remarks />
        void isValidExtensionAsync(string Filename);

        /// <remarks />
        void isValidExtensionAsync(string Filename, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/isValidFileSize",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        bool isValidFileSize(long fileSize);

        /// <remarks />
        void isValidFileSizeAsync(long fileSize);

        /// <remarks />
        void isValidFileSizeAsync(long fileSize, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/Login",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        bool Login(string UserName, string Password);

        /// <remarks />
        void LoginAsync(string UserName, string Password);

        /// <remarks />
        void LoginAsync(string UserName, string Password, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/Logout",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        bool Logout();

        /// <remarks />
        void LogoutAsync();

        /// <remarks />
        void LogoutAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/resetSystem",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] resetSystem();

        /// <remarks />
        void resetSystemAsync();

        /// <remarks />
        void resetSystemAsync(object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/saveFile",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] saveFile(int Valor, string Bezeichnung, string Dateiname, int SortOrder,
                          [XmlElement(DataType = "base64Binary")] byte[] byteFile);

        /// <remarks />
        void saveFileAsync(int Valor, string Bezeichnung, string Dateiname, int SortOrder, byte[] byteFile);

        /// <remarks />
        void saveFileAsync(int Valor, string Bezeichnung, string Dateiname, int SortOrder, byte[] byteFile,
                           object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/updateEmittentenRatingForID",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] updateEmittentenRatingForID(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                             DateTime dateSp, DateTime dateMoody, DateTime dateFitch);

        /// <remarks />
        void updateEmittentenRatingForIDAsync(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                              DateTime dateSp, DateTime dateMoody, DateTime dateFitch);

        /// <remarks />
        void updateEmittentenRatingForIDAsync(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                              DateTime dateSp, DateTime dateMoody, DateTime dateFitch, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeBarrage",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeBarrage(int valor, string name, decimal barriere, string ausloeser, string beobachtung,
                              string settlement, string name_eng, string ausloeser_eng, string beobachtung_eng,
                              string settlement_eng);

        /// <remarks />
        void writeBarrageAsync(int valor, string name, decimal barriere, string ausloeser, string beobachtung,
                               string settlement, string name_eng, string ausloeser_eng, string beobachtung_eng,
                               string settlement_eng);

        /// <remarks />
        void writeBarrageAsync(int valor, string name, decimal barriere, string ausloeser, string beobachtung,
                               string settlement, string name_eng, string ausloeser_eng, string beobachtung_eng,
                               string settlement_eng, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeBasevalue",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeBasevalue(int valor, string name);

        /// <remarks />
        void writeBasevalueAsync(int valor, string name);

        /// <remarks />
        void writeBasevalueAsync(int valor, string name, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeEmittentenRatingWithLogo",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeEmittentenRatingWithLogo(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                               string ratingFitch, DateTime dateSp, DateTime dateMoody,
                                               DateTime dateFitch, string kommentar, string kommentar_eng,
                                               string webseite, string logoFileName,
                                               [XmlElement(DataType = "base64Binary")] byte[] byteLogo);

        /// <remarks />
        void writeEmittentenRatingWithLogoAsync(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                                string ratingFitch, DateTime dateSp, DateTime dateMoody,
                                                DateTime dateFitch, string kommentar, string kommentar_eng,
                                                string webseite, string logoFileName, byte[] byteLogo);

        /// <remarks />
        void writeEmittentenRatingWithLogoAsync(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                                string ratingFitch, DateTime dateSp, DateTime dateMoody,
                                                DateTime dateFitch, string kommentar, string kommentar_eng,
                                                string webseite, string logoFileName, byte[] byteLogo, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeEvent",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeEvent(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                            string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                            string event_typ_eng, string periode_name_eng, string beschreibung_eng);

        /// <remarks />
        void writeEventAsync(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                             string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                             string event_typ_eng, string periode_name_eng, string beschreibung_eng);

        /// <remarks />
        void writeEventAsync(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                             string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                             string event_typ_eng, string periode_name_eng, string beschreibung_eng, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writePrice",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writePrice(int Valor, DateTime Datetime, double Bid, double Ask);

        /// <remarks />
        void writePriceAsync(int Valor, DateTime Datetime, double Bid, double Ask);

        /// <remarks />
        void writePriceAsync(int Valor, DateTime Datetime, double Bid, double Ask, object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeProduct",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeProduct(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id);

        /// <remarks />
        void writeProductAsync(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id);

        /// <remarks />
        void writeProductAsync(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id,
            object userState);

        /// <remarks />
        [SoapDocumentMethod("http://www.cat-financial-files.ch/writeProductV2",
            RequestNamespace = "http://www.cat-financial-files.ch",
            ResponseNamespace = "http://www.cat-financial-files.ch", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        object[] writeProductV2(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id,
            string emissionstyp,
            string symbol,
            string klHandelbEinheit,
            string struktur1_zusatz_text,
            string struktur1_zusatz_wert,
            string struktur2_zusatz_text,
            string struktur2_zusatz_wert,
            string struktur3_zusatz_text,
            string struktur3_zusatz_wert,
            string name_eng,
            string waehrungsrisiko_eng,
            string anlageklasse_eng,
            string produkte_kat_eng,
            string produkte_typ_eng,
            string preisangabe_eng,
            string cp_garant_eng,
            string cp_bedingt_eng,
            string cp_floater_eng,
            string call_daten_eng,
            string fruehz_rueckz_eng,
            string coupon_garantiert_eng,
            string coupon_bedingt_eng,
            string text_bed_coupon_eng,
            string floater_eng,
            string text_floater_eng,
            string min_coupon_eng,
            string max_coupon_eng,
            string text_coupon_eng,
            string text_fruez_rueckz_eng,
            string cap_eng,
            string max_rueckzahlung_eng,
            string text_max_rueckz_eng,
            string schutz_eng,
            string min_rueckzahlung_eng,
            string partizipation_eng,
            string partizipation_text_eng,
            string discount_eng,
            string max_rendite_eng,
            string bonus_level_eng,
            string struktur1_zusatz_text_eng,
            string struktur1_zusatz_wert_eng,
            string struktur2_zusatz_text_eng,
            string struktur2_zusatz_wert_eng,
            string struktur3_zusatz_text_eng,
            string struktur3_zusatz_wert_eng,
            bool hasEnglish);

        /// <remarks />
        void writeProductV2Async(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id,
            string emissionstyp,
            string symbol,
            string klHandelbEinheit,
            string struktur1_zusatz_text,
            string struktur1_zusatz_wert,
            string struktur2_zusatz_text,
            string struktur2_zusatz_wert,
            string struktur3_zusatz_text,
            string struktur3_zusatz_wert,
            string name_eng,
            string waehrungsrisiko_eng,
            string anlageklasse_eng,
            string produkte_kat_eng,
            string produkte_typ_eng,
            string preisangabe_eng,
            string cp_garant_eng,
            string cp_bedingt_eng,
            string cp_floater_eng,
            string call_daten_eng,
            string fruehz_rueckz_eng,
            string coupon_garantiert_eng,
            string coupon_bedingt_eng,
            string text_bed_coupon_eng,
            string floater_eng,
            string text_floater_eng,
            string min_coupon_eng,
            string max_coupon_eng,
            string text_coupon_eng,
            string text_fruez_rueckz_eng,
            string cap_eng,
            string max_rueckzahlung_eng,
            string text_max_rueckz_eng,
            string schutz_eng,
            string min_rueckzahlung_eng,
            string partizipation_eng,
            string partizipation_text_eng,
            string discount_eng,
            string max_rendite_eng,
            string bonus_level_eng,
            string struktur1_zusatz_text_eng,
            string struktur1_zusatz_wert_eng,
            string struktur2_zusatz_text_eng,
            string struktur2_zusatz_wert_eng,
            string struktur3_zusatz_text_eng,
            string struktur3_zusatz_wert_eng,
            bool hasEnglish);

        /// <remarks />
        void writeProductV2Async(
            int valor,
            string name,
            string waehrung,
            string waehrungsrisiko,
            string preisangabe_dirty,
            string garant,
            string lead_manager,
            string emittent,
            string anlageklasse,
            string produkte_kat,
            string produkte_typ,
            string isin,
            string boersenplatz,
            string preisangabe,
            DateTime valuta,
            string emissionspreis,
            string nominal,
            DateTime rueckzahlung,
            DateTime anfangsfixierung,
            DateTime schlussfixierung,
            string coupon_garantiert,
            string cp_garant,
            string coupon_bedingt,
            string text_bed_coupon,
            string cp_bedingt,
            string floater,
            string cp_floater,
            string text_floater,
            string min_coupon,
            string max_coupon,
            string text_coupon,
            string call_daten,
            string fruehz_rueckz,
            string text_fruez_rueckz,
            string cap,
            string max_rueckzahlung,
            string text_max_rueckz,
            string schutz,
            string schutztyp,
            string min_rueckzahlung,
            string partizipation,
            string partizipation_text,
            string discount,
            string max_rendite,
            string bonus_level,
            string emittent_kurz,
            string produkt_status,
            int produkte_kat_id,
            int podukte_typ_id,
            string emissionstyp,
            string symbol,
            string klHandelbEinheit,
            string struktur1_zusatz_text,
            string struktur1_zusatz_wert,
            string struktur2_zusatz_text,
            string struktur2_zusatz_wert,
            string struktur3_zusatz_text,
            string struktur3_zusatz_wert,
            string name_eng,
            string waehrungsrisiko_eng,
            string anlageklasse_eng,
            string produkte_kat_eng,
            string produkte_typ_eng,
            string preisangabe_eng,
            string cp_garant_eng,
            string cp_bedingt_eng,
            string cp_floater_eng,
            string call_daten_eng,
            string fruehz_rueckz_eng,
            string coupon_garantiert_eng,
            string coupon_bedingt_eng,
            string text_bed_coupon_eng,
            string floater_eng,
            string text_floater_eng,
            string min_coupon_eng,
            string max_coupon_eng,
            string text_coupon_eng,
            string text_fruez_rueckz_eng,
            string cap_eng,
            string max_rueckzahlung_eng,
            string text_max_rueckz_eng,
            string schutz_eng,
            string min_rueckzahlung_eng,
            string partizipation_eng,
            string partizipation_text_eng,
            string discount_eng,
            string max_rendite_eng,
            string bonus_level_eng,
            string struktur1_zusatz_text_eng,
            string struktur1_zusatz_wert_eng,
            string struktur2_zusatz_text_eng,
            string struktur2_zusatz_wert_eng,
            string struktur3_zusatz_text_eng,
            string struktur3_zusatz_wert_eng,
            bool hasEnglish,
            object userState);
    }
}