using System;
using System.Net;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.Properties;

namespace TweakToolkit.WCF.Test
{
    public class ImportMock : IImport
    {
        private string _password;
        private string _userName;

        public CookieContainer CookieContainer { get; set; }

        #region ResultConfiguration

        private const bool LoginStatus = true;
        private const bool LogoutResult = true;

        private static object[] GetLogoutResult()
        {
            var results = new object[] { LogoutResult, "" };
            return results;
        }

        private object[] GetLoginResult()
        {
            var loginResult = _userName.Equals(Settings.Default.Webservice_Username) &&
                          _password.Equals(Settings.Default.Webservice_Password);

            var results = new object[] { loginResult, "" };
            return results;
        }

        private object[] GetWritePriceResult()
        {
            return new object[] { isLoggedIn() };
        }

        #endregion ResultConfiguration

        #region Events

        public event clearDatabaseCompletedEventHandler clearDatabaseCompleted;

        public event deleteAllBarragesCompletedEventHandler deleteAllBarragesCompleted;

        public event deleteAllBasevaluesCompletedEventHandler deleteAllBasevaluesCompleted;

        public event deleteAllDBFilesCompletedEventHandler deleteAllDBFilesCompleted;

        public event deleteAllEmittentenRatingLogosFromDiskCompletedEventHandler deleteAllEmittentenRatingLogosFromDiskCompleted;

        public event deleteAllEmittentenRatingLogosNotInDBCompletedEventHandler deleteAllEmittentenRatingLogosNotInDBCompleted;

        public event deleteAllEmittentenRatingsCompletedEventHandler deleteAllEmittentenRatingsCompleted;

        public event deleteAllEventsCompletedEventHandler deleteAllEventsCompleted;

        public event deleteAllFilesCompletedEventHandler deleteAllFilesCompleted;

        public event deleteAllFilesNotInDBCompletedEventHandler deleteAllFilesNotInDBCompleted;

        public event deleteAllFilesOfProductCompletedEventHandler deleteAllFilesOfProductCompleted;

        public event deleteBarrageOfProductByValorCompletedEventHandler deleteBarrageOfProductByValorCompleted;

        public event deleteBasevaluesOfProductByValorCompletedEventHandler deleteBasevaluesOfProductByValorCompleted;

        public event deleteEmittentenRatingForIDCompletedEventHandler deleteEmittentenRatingForIDCompleted;

        public event deleteEmittentenRatingForNameCompletedEventHandler deleteEmittentenRatingForNameCompleted;

        public event deleteEventsOfProductByValorCompletedEventHandler deleteEventsOfProductByValorCompleted;

        public event deleteFileByIDCompletedEventHandler deleteFileByIDCompleted;

        public event deleteFileByOriginalNameCompletedEventHandler deleteFileByOriginalNameCompleted;

        public event deleteFileByServerNameCompletedEventHandler deleteFileByServerNameCompleted;

        public event deletePricesByValorCompletedEventHandler deletePricesByValorCompleted;

        public event deleteProductByIDCompletedEventHandler deleteProductByIDCompleted;

        public event deleteProductByValorCompletedEventHandler deleteProductByValorCompleted;

        public event GetLoginStatusCompletedEventHandler GetLoginStatusCompleted;

        public event getMaxFileSizeCompletedEventHandler getMaxFileSizeCompleted;

        public event getValidExtensionsCompletedEventHandler getValidExtensionsCompleted;

        public event isLoggedInCompletedEventHandler isLoggedInCompleted;

        public event isValidExtensionCompletedEventHandler isValidExtensionCompleted;

        public event isValidFileSizeCompletedEventHandler isValidFileSizeCompleted;

        public event LoginCompletedEventHandler LoginCompleted;

        public event LogoutCompletedEventHandler LogoutCompleted;

        public event resetSystemCompletedEventHandler resetSystemCompleted;

        public event saveFileCompletedEventHandler saveFileCompleted;

        public event updateEmittentenRatingForIDCompletedEventHandler updateEmittentenRatingForIDCompleted;

        public event writeBarrageCompletedEventHandler writeBarrageCompleted;

        public event writeBasevalueCompletedEventHandler writeBasevalueCompleted;

        public event writeEmittentenRatingWithLogoCompletedEventHandler writeEmittentenRatingWithLogoCompleted;

        public event writeEventCompletedEventHandler writeEventCompleted;

        public event writePriceCompletedEventHandler writePriceCompleted;

        public event writeProductCompletedEventHandler writeProductCompleted;

        public event writeProductV2CompletedEventHandler writeProductV2Completed;

        protected virtual void OnLoginCompleted(LoginCompletedEventArgs e)
        {
            var handler = LoginCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnLogoutCompleted(LogoutCompletedEventArgs e)
        {
            var handler = LogoutCompleted;
            if (handler != null) handler(this, e);
        }

        #endregion Events

        #region Barriers

        public object[] deleteAllBarrages()
        {
            throw new NotImplementedException();
        }

        public void deleteAllBarragesAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllBarragesAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteBarrageOfProductByValor(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteBarrageOfProductByValorAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteBarrageOfProductByValorAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeBarrage(int valor, string name, decimal barriere, string ausloeser, string beobachtung, string settlement,
                                     string name_eng, string ausloeser_eng, string beobachtung_eng, string settlement_eng)
        {
            throw new NotImplementedException();
        }

        public void writeBarrageAsync(int valor, string name, decimal barriere, string ausloeser, string beobachtung, string settlement,
                                      string name_eng, string ausloeser_eng, string beobachtung_eng, string settlement_eng)
        {
            throw new NotImplementedException();
        }

        public void writeBarrageAsync(int valor, string name, decimal barriere, string ausloeser, string beobachtung, string settlement,
                                      string name_eng, string ausloeser_eng, string beobachtung_eng, string settlement_eng,
                                      object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Barriers

        #region BaseValues

        public object[] deleteAllBasevalues()
        {
            throw new NotImplementedException();
        }

        public void deleteAllBasevaluesAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllBasevaluesAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteBasevaluesOfProductByValor(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteBasevaluesOfProductByValorAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteBasevaluesOfProductByValorAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeBasevalue(int valor, string name)
        {
            throw new NotImplementedException();
        }

        public void writeBasevalueAsync(int valor, string name)
        {
            throw new NotImplementedException();
        }

        public void writeBasevalueAsync(int valor, string name, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion BaseValues

        #region Database

        public object[] clearDatabase(bool doDeleteFilesFromDisk)
        {
            throw new NotImplementedException();
        }

        public void clearDatabaseAsync(bool doDeleteFilesFromDisk)
        {
            throw new NotImplementedException();
        }

        public void clearDatabaseAsync(bool doDeleteFilesFromDisk, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Database

        #region Product

        public object[] deleteProductByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void deleteProductByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public void deleteProductByIDAsync(int ID, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteProductByValor(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteProductByValorAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteProductByValorAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeProduct(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                     string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                     string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                     string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                     DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                     string text_bed_coupon, string cp_bedingt, string floater, string cp_floater, string text_floater,
                                     string min_coupon, string max_coupon, string text_coupon, string call_daten, string fruehz_rueckz,
                                     string text_fruez_rueckz, string cap, string max_rueckzahlung, string text_max_rueckz,
                                     string schutz, string schutztyp, string min_rueckzahlung, string partizipation,
                                     string partizipation_text, string discount, string max_rendite, string bonus_level,
                                     string emittent_kurz, string produkt_status, int produkte_kat_id, int podukte_typ_id)
        {
            throw new NotImplementedException();
        }

        public void writeProductAsync(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                      string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                      string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                      string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                      DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                      string text_bed_coupon, string cp_bedingt, string floater, string cp_floater, string text_floater,
                                      string min_coupon, string max_coupon, string text_coupon, string call_daten, string fruehz_rueckz,
                                      string text_fruez_rueckz, string cap, string max_rueckzahlung, string text_max_rueckz,
                                      string schutz, string schutztyp, string min_rueckzahlung, string partizipation,
                                      string partizipation_text, string discount, string max_rendite, string bonus_level,
                                      string emittent_kurz, string produkt_status, int produkte_kat_id, int podukte_typ_id)
        {
            throw new NotImplementedException();
        }

        public void writeProductAsync(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                      string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                      string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                      string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                      DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                      string text_bed_coupon, string cp_bedingt, string floater, string cp_floater, string text_floater,
                                      string min_coupon, string max_coupon, string text_coupon, string call_daten, string fruehz_rueckz,
                                      string text_fruez_rueckz, string cap, string max_rueckzahlung, string text_max_rueckz,
                                      string schutz, string schutztyp, string min_rueckzahlung, string partizipation,
                                      string partizipation_text, string discount, string max_rendite, string bonus_level,
                                      string emittent_kurz, string produkt_status, int produkte_kat_id, int podukte_typ_id,
                                      object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeProductV2(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                       string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                       string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                       string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                       DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                       string text_bed_coupon, string cp_bedingt, string floater, string cp_floater,
                                       string text_floater, string min_coupon, string max_coupon, string text_coupon, string call_daten,
                                       string fruehz_rueckz, string text_fruez_rueckz, string cap, string max_rueckzahlung,
                                       string text_max_rueckz, string schutz, string schutztyp, string min_rueckzahlung,
                                       string partizipation, string partizipation_text, string discount, string max_rendite,
                                       string bonus_level, string emittent_kurz, string produkt_status, int produkte_kat_id,
                                       int podukte_typ_id, string emissionstyp, string symbol, string klHandelbEinheit,
                                       string struktur1_zusatz_text, string struktur1_zusatz_wert, string struktur2_zusatz_text,
                                       string struktur2_zusatz_wert, string struktur3_zusatz_text, string struktur3_zusatz_wert,
                                       string name_eng, string waehrungsrisiko_eng, string anlageklasse_eng, string produkte_kat_eng,
                                       string produkte_typ_eng, string preisangabe_eng, string cp_garant_eng, string cp_bedingt_eng,
                                       string cp_floater_eng, string call_daten_eng, string fruehz_rueckz_eng,
                                       string coupon_garantiert_eng, string coupon_bedingt_eng, string text_bed_coupon_eng,
                                       string floater_eng, string text_floater_eng, string min_coupon_eng, string max_coupon_eng,
                                       string text_coupon_eng, string text_fruez_rueckz_eng, string cap_eng,
                                       string max_rueckzahlung_eng, string text_max_rueckz_eng, string schutz_eng,
                                       string min_rueckzahlung_eng, string partizipation_eng, string partizipation_text_eng,
                                       string discount_eng, string max_rendite_eng, string bonus_level_eng,
                                       string struktur1_zusatz_text_eng, string struktur1_zusatz_wert_eng,
                                       string struktur2_zusatz_text_eng, string struktur2_zusatz_wert_eng,
                                       string struktur3_zusatz_text_eng, string struktur3_zusatz_wert_eng, bool hasEnglish)
        {
            throw new NotImplementedException();
        }

        public void writeProductV2Async(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                        string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                        string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                        string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                        DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                        string text_bed_coupon, string cp_bedingt, string floater, string cp_floater,
                                        string text_floater, string min_coupon, string max_coupon, string text_coupon,
                                        string call_daten, string fruehz_rueckz, string text_fruez_rueckz, string cap,
                                        string max_rueckzahlung, string text_max_rueckz, string schutz, string schutztyp,
                                        string min_rueckzahlung, string partizipation, string partizipation_text, string discount,
                                        string max_rendite, string bonus_level, string emittent_kurz, string produkt_status,
                                        int produkte_kat_id, int podukte_typ_id, string emissionstyp, string symbol,
                                        string klHandelbEinheit, string struktur1_zusatz_text, string struktur1_zusatz_wert,
                                        string struktur2_zusatz_text, string struktur2_zusatz_wert, string struktur3_zusatz_text,
                                        string struktur3_zusatz_wert, string name_eng, string waehrungsrisiko_eng,
                                        string anlageklasse_eng, string produkte_kat_eng, string produkte_typ_eng,
                                        string preisangabe_eng, string cp_garant_eng, string cp_bedingt_eng, string cp_floater_eng,
                                        string call_daten_eng, string fruehz_rueckz_eng, string coupon_garantiert_eng,
                                        string coupon_bedingt_eng, string text_bed_coupon_eng, string floater_eng,
                                        string text_floater_eng, string min_coupon_eng, string max_coupon_eng, string text_coupon_eng,
                                        string text_fruez_rueckz_eng, string cap_eng, string max_rueckzahlung_eng,
                                        string text_max_rueckz_eng, string schutz_eng, string min_rueckzahlung_eng,
                                        string partizipation_eng, string partizipation_text_eng, string discount_eng,
                                        string max_rendite_eng, string bonus_level_eng, string struktur1_zusatz_text_eng,
                                        string struktur1_zusatz_wert_eng, string struktur2_zusatz_text_eng,
                                        string struktur2_zusatz_wert_eng, string struktur3_zusatz_text_eng,
                                        string struktur3_zusatz_wert_eng, bool hasEnglish)
        {
            throw new NotImplementedException();
        }

        public void writeProductV2Async(int valor, string name, string waehrung, string waehrungsrisiko, string preisangabe_dirty,
                                        string garant, string lead_manager, string emittent, string anlageklasse, string produkte_kat,
                                        string produkte_typ, string isin, string boersenplatz, string preisangabe, DateTime valuta,
                                        string emissionspreis, string nominal, DateTime rueckzahlung, DateTime anfangsfixierung,
                                        DateTime schlussfixierung, string coupon_garantiert, string cp_garant, string coupon_bedingt,
                                        string text_bed_coupon, string cp_bedingt, string floater, string cp_floater,
                                        string text_floater, string min_coupon, string max_coupon, string text_coupon,
                                        string call_daten, string fruehz_rueckz, string text_fruez_rueckz, string cap,
                                        string max_rueckzahlung, string text_max_rueckz, string schutz, string schutztyp,
                                        string min_rueckzahlung, string partizipation, string partizipation_text, string discount,
                                        string max_rendite, string bonus_level, string emittent_kurz, string produkt_status,
                                        int produkte_kat_id, int podukte_typ_id, string emissionstyp, string symbol,
                                        string klHandelbEinheit, string struktur1_zusatz_text, string struktur1_zusatz_wert,
                                        string struktur2_zusatz_text, string struktur2_zusatz_wert, string struktur3_zusatz_text,
                                        string struktur3_zusatz_wert, string name_eng, string waehrungsrisiko_eng,
                                        string anlageklasse_eng, string produkte_kat_eng, string produkte_typ_eng,
                                        string preisangabe_eng, string cp_garant_eng, string cp_bedingt_eng, string cp_floater_eng,
                                        string call_daten_eng, string fruehz_rueckz_eng, string coupon_garantiert_eng,
                                        string coupon_bedingt_eng, string text_bed_coupon_eng, string floater_eng,
                                        string text_floater_eng, string min_coupon_eng, string max_coupon_eng, string text_coupon_eng,
                                        string text_fruez_rueckz_eng, string cap_eng, string max_rueckzahlung_eng,
                                        string text_max_rueckz_eng, string schutz_eng, string min_rueckzahlung_eng,
                                        string partizipation_eng, string partizipation_text_eng, string discount_eng,
                                        string max_rendite_eng, string bonus_level_eng, string struktur1_zusatz_text_eng,
                                        string struktur1_zusatz_wert_eng, string struktur2_zusatz_text_eng,
                                        string struktur2_zusatz_wert_eng, string struktur3_zusatz_text_eng,
                                        string struktur3_zusatz_wert_eng, bool hasEnglish, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Product

        #region Events

        public object[] deleteAllEvents()
        {
            throw new NotImplementedException();
        }

        public void deleteAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllEventsAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteEventsOfProductByValor(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteEventsOfProductByValorAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteEventsOfProductByValorAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeEvent(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                                   string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                                   string event_typ_eng, string periode_name_eng, string beschreibung_eng)
        {
            throw new NotImplementedException();
        }

        public void writeEventAsync(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                                    string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                                    string event_typ_eng, string periode_name_eng, string beschreibung_eng)
        {
            throw new NotImplementedException();
        }

        public void writeEventAsync(int valor, DateTime beobachtungs_datum, string event_typ, DateTime event_valuta_datum,
                                    string periode_name, DateTime periode_start, DateTime periode_ende, string beschreibung,
                                    string event_typ_eng, string periode_name_eng, string beschreibung_eng, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Events

        #region Prices

        public object[] deletePricesByValor(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deletePricesByValorAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deletePricesByValorAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writePrice(int Valor, DateTime Datetime, double Bid, double Ask)
        {
            return GetWritePriceResult();
        }

        public void writePriceAsync(int Valor, DateTime Datetime, double Bid, double Ask)
        {
            throw new NotImplementedException();
        }

        public void writePriceAsync(int Valor, DateTime Datetime, double Bid, double Ask, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Prices

        #region Files

        public object[] deleteAllDBFiles()
        {
            throw new NotImplementedException();
        }

        public void deleteAllDBFilesAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllDBFilesAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteAllFiles()
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteAllFilesNotInDB()
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesNotInDBAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesNotInDBAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteAllFilesOfProduct(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesOfProductAsync(int Valor)
        {
            throw new NotImplementedException();
        }

        public void deleteAllFilesOfProductAsync(int Valor, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteFileByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByIDAsync(int ID, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteFileByOriginalName(string FileName)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByOriginalNameAsync(string FileName)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByOriginalNameAsync(string FileName, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteFileByServerName(string FileName)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByServerNameAsync(string FileName)
        {
            throw new NotImplementedException();
        }

        public void deleteFileByServerNameAsync(string FileName, object userState)
        {
            throw new NotImplementedException();
        }

        public long getMaxFileSize()
        {
            throw new NotImplementedException();
        }

        public void getMaxFileSizeAsync()
        {
            throw new NotImplementedException();
        }

        public void getMaxFileSizeAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public string[] getValidExtensions()
        {
            throw new NotImplementedException();
        }

        public void getValidExtensionsAsync()
        {
            throw new NotImplementedException();
        }

        public void getValidExtensionsAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public bool isValidExtension(string Filename)
        {
            throw new NotImplementedException();
        }

        public void isValidExtensionAsync(string Filename)
        {
            throw new NotImplementedException();
        }

        public void isValidExtensionAsync(string Filename, object userState)
        {
            throw new NotImplementedException();
        }

        public bool isValidFileSize(long fileSize)
        {
            throw new NotImplementedException();
        }

        public void isValidFileSizeAsync(long fileSize)
        {
            throw new NotImplementedException();
        }

        public void isValidFileSizeAsync(long fileSize, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] saveFile(int Valor, string Bezeichnung, string Dateiname, int SortOrder, byte[] byteFile)
        {
            throw new NotImplementedException();
        }

        public void saveFileAsync(int Valor, string Bezeichnung, string Dateiname, int SortOrder, byte[] byteFile)
        {
            throw new NotImplementedException();
        }

        public void saveFileAsync(int Valor, string Bezeichnung, string Dateiname, int SortOrder, byte[] byteFile, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion Files

        #region IssuerRatings

        public object[] deleteAllEmittentenRatingLogosFromDisk(bool clearDBReference)
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingLogosFromDiskAsync(bool clearDBReference)
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingLogosFromDiskAsync(bool clearDBReference, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteAllEmittentenRatingLogosNotInDB()
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingLogosNotInDBAsync()
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingLogosNotInDBAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteAllEmittentenRatings(bool deleteLogosFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingsAsync(bool deleteLogosFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteAllEmittentenRatingsAsync(bool deleteLogosFromDisk, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteEmittentenRatingForID(int emittentenId, bool deleteLogoFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteEmittentenRatingForIDAsync(int emittentenId, bool deleteLogoFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteEmittentenRatingForIDAsync(int emittentenId, bool deleteLogoFromDisk, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] deleteEmittentenRatingForName(string nameBank, bool deleteLogoFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteEmittentenRatingForNameAsync(string nameBank, bool deleteLogoFromDisk)
        {
            throw new NotImplementedException();
        }

        public void deleteEmittentenRatingForNameAsync(string nameBank, bool deleteLogoFromDisk, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] updateEmittentenRatingForID(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                                    DateTime dateSp, DateTime dateMoody, DateTime dateFitch)
        {
            throw new NotImplementedException();
        }

        public void updateEmittentenRatingForIDAsync(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                                     DateTime dateSp, DateTime dateMoody, DateTime dateFitch)
        {
            throw new NotImplementedException();
        }

        public void updateEmittentenRatingForIDAsync(int emittentenId, string ratingSp, string ratingMoody, string ratingFitch,
                                                     DateTime dateSp, DateTime dateMoody, DateTime dateFitch, object userState)
        {
            throw new NotImplementedException();
        }

        public object[] writeEmittentenRatingWithLogo(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                                      string ratingFitch, DateTime dateSp, DateTime dateMoody, DateTime dateFitch,
                                                      string kommentar, string kommentar_eng, string webseite, string logoFileName,
                                                      byte[] byteLogo)
        {
            throw new NotImplementedException();
        }

        public void writeEmittentenRatingWithLogoAsync(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                                       string ratingFitch, DateTime dateSp, DateTime dateMoody, DateTime dateFitch,
                                                       string kommentar, string kommentar_eng, string webseite, string logoFileName,
                                                       byte[] byteLogo)
        {
            throw new NotImplementedException();
        }

        public void writeEmittentenRatingWithLogoAsync(int emittentenId, string nameBank, string ratingSp, string ratingMoody,
                                                       string ratingFitch, DateTime dateSp, DateTime dateMoody, DateTime dateFitch,
                                                       string kommentar, string kommentar_eng, string webseite, string logoFileName,
                                                       byte[] byteLogo, object userState)
        {
            throw new NotImplementedException();
        }

        #endregion IssuerRatings

        #region Service

        public void CancelAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public string GetLoginStatus()
        {
            throw new NotImplementedException();
        }

        public void GetLoginStatusAsync()
        {
            throw new NotImplementedException();
        }

        public void GetLoginStatusAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public bool isLoggedIn()
        {
            return (bool)GetLoginResult()[0];
        }

        public void isLoggedInAsync()
        {
            throw new NotImplementedException();
        }

        public void isLoggedInAsync(object userState)
        {
            throw new NotImplementedException();
        }

        public bool Login(string UserName, string Password)
        {
            SetCredentials(UserName, Password);
            return (bool)GetLoginResult()[0];
        }

        public void LoginAsync(string UserName, string Password)
        {
            SetCredentials(UserName, Password);
            OnLoginCompleted(new LoginCompletedEventArgs(GetLoginResult(), null, false, null));
        }

        public void LoginAsync(string UserName, string Password, object userState)
        {
            SetCredentials(UserName, Password);
            OnLoginCompleted(new LoginCompletedEventArgs(GetLoginResult(), null, false, userState));
        }

        public bool Logout()
        {
            return (bool)GetLogoutResult()[0];
        }

        public void LogoutAsync()
        {
            OnLogoutCompleted(new LogoutCompletedEventArgs(GetLogoutResult(), null, false, null));
        }

        public void LogoutAsync(object userState)
        {
            OnLogoutCompleted(new LogoutCompletedEventArgs(GetLogoutResult(), null, false, userState));
        }

        public object[] resetSystem()
        {
            throw new NotImplementedException();
        }

        public void resetSystemAsync()
        {
            throw new NotImplementedException();
        }

        public void resetSystemAsync(object userState)
        {
            throw new NotImplementedException();
        }

        private void SetCredentials(string UserName, string Password)
        {
            _userName = UserName;
            _password = Password;
        }

        #endregion Service
    }
}