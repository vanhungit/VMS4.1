using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TCPProtocolClient
{
    public class LibConvert
    {
        /// <summary>
        /// Hàm chuyển số decimal sang chuỗi nhị phân
        /// </summary>
        /// <param name="Chuoi"></param>
        /// <returns></returns>
        public String Integer_To_Binary(int Chuoi)
        {
            String Trave = "";
            Trave = Convert.ToString(Chuoi, 2);
            return Trave;
        }
        public int GiaMaResultDecimalByIndex(byte[] byData, int Index)
        {
            int Trave = 0;
            if (byData.Length >= Index)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if (i == Index - 1)
                    {
                        Trave = (int.Parse(byData[i].ToString()));
                        break;
                    }

                }
            }
            return Trave;
        }
        public String DaoChuoi(String Chuoi)
        {
            String Trave = "";
            string name = Chuoi;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                Trave += name[i];
            }
            return Trave;
        }
        /// <summary>
        /// Hàm chuyển decimal sang số chuỗi Hex
        /// </summary>
        /// <param name="Chuoi"></param>
        /// <returns></returns>
        public String Integer_To_Hex(long Chuoi)
        {
            String Trave = "";
            Trave = Chuoi > 15 ? Chuoi.ToString("X") : "0" + Chuoi.ToString("X");
            return Trave;
        }
        /// <summary>
        /// Hàm chuyển chuỗi Hex sang số decimal
        /// </summary>
        /// <param name="Chuoi"></param>
        /// <returns></returns>
        public long Hex_To_Integer(String Chuoi)
        {
            long Trave = 0;
            Trave = Convert.ToInt64(Chuoi, 16);
            return Trave;
        }
        /// <summary>
        /// Hàm chuyển chuỗi Hex sang chuỗi nhị phân
        /// </summary>
        /// <param name="Chuoi"></param>
        /// <returns></returns>
        public String Hex_To_Binary(String Chuoi)
        {
            String Trave = "";
            Trave = Convert.ToString(Convert.ToInt64(Chuoi, 16), 2);
            return Trave;
        }
        /// <summary>
        /// Chuyển đổi chuỗi số Hex sang array byte lệnh
        /// </summary>
        /// <param name="StringCommand"></param>
        /// <returns></returns>
        public byte[] ConvertCommandHEX(string StringCommand)
        {
            String CodeReplaceSpace = StringCommand.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            return ConvertHexStringToByteArray(CodeReplaceENTER);
        }
        public byte[] ConvertCommandHEX_FromString(string StringCommand)
        {

            return ConvertHexStringToByteArray(StringCommand);
        }
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
        /// <summary>
        /// Hàm lấy chuối dữ liệu trả về dạng 0A|23|3C|45
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public string GiaMaResult(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 7)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if (i == byData.Length - 1)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }
                    else
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                }
            }
            return Trave;
        }
        /// <summary>
        /// cộng chuỗi data
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public int GiaMaResultSum(byte[] byData)
        {
            int Trave = 0;
            if (byData.Length > 0)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    Trave += (int.Parse(byData[i].ToString()));
                }
            }
            return Trave;
        }
        /// <summary>
        /// Nối chuỗi hex
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public string GiaMaResultSpace(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 0)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if (i == byData.Length - 1)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }
                    else
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + " ";
                    }
                }
            }
            return Trave;
        }
        public string NoiChuoiResultSpaceGiam(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 0)
            {
                for (int i = byData.Length - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }
                    else
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + " ";
                    }
                }
            }
            return Trave;
        }
        public string NoiChuoiResult(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 0)
            {
                for (int i = byData.Length - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }
                    else
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "";
                    }
                }
            }
            return Trave;
        }
        /// <summary>
        /// Hàm trả về số hexa tại vị trí
        /// </summary>
        /// <param name="byData"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public string GiaMaResultByIndex(byte[] byData, int Index)
        {
            string Trave = "";
            if (byData.Length >= Index)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if (i == Index - 1)
                    {
                        Trave = (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                        break;
                    }

                }
            }
            return Trave;
        }
        /// <summary>
        /// Hàm lấy số hexa tư vị trí A đến vị trí B
        /// </summary>
        /// <param name="byData"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public string GiaMaResultByIndex(byte[] byData, int From, int To)
        {
            string Trave = "";
            if (byData.Length >= To)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if (i >= From - 1 && i <= To - 1)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }

                }
            }
            return Trave;
        }
        public string GiaMaResultAsciiByIndex(byte[] byData, int From, int To)
        {
            string Trave = "";
            if (byData.Length >= To)
            {
                for (int i = From - 1; i < To; i++)
                {
                    if (i >= From - 1 && i <= To - 1)
                    {
                        Trave += Encoding.ASCII.GetString(byData,i,1);
                    }

                }
            }
            return Trave;
        }
        public string GiaMaResultByIndexGiam(byte[] byData, int From, int To)
        {
            string Trave = "";
            if (byData.Length >= To)
            {
                for (int i = byData.Length - 1; i >= 0; i--)
                {
                    if (i <= From - 1 && i >= To - 1)
                    {
                        Trave += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                    }

                }
            }
            return Trave;
        }
        /// <summary>
        /// Hàm so sánh giá trị với phần tử tại vị trí
        /// </summary>
        /// <param name="byData"> mảng cần duyệt</param>
        /// <param name="Index">vị trí cần so sánh</param>
        /// <param name="HexaCompare">giá trị cần so sánh</param>
        /// <returns></returns>
        public bool GiaMaResultCheckData(byte[] byData, int Index, string HexaCompare)
        {
            bool Trave = false;
            if (byData.Length >= Index)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    if ((i == Index - 1))
                    {
                        string temp = (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                        if(temp.Trim().Equals(HexaCompare))
                        {
                            Trave = true;
                        }
                        break;
                    }

                }
            }
            return Trave;
        }
        public bool GiaMaResultFindData(byte[] byData, string HexaCompare)
        {
            bool Trave = false;
            if (byData.Length > 0)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    {
                        string temp = (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                        if (temp.Trim().Equals(HexaCompare))
                        {
                            Trave = true;
                            break;
                        }
                    }

                }
            }
            return Trave;
        }
        public int GiaMaResultIndexFindData(byte[] byData, string HexaCompare)
        {
            int Trave = -1;
            if (byData.Length > 0)
            {
                for (int i = 0; i < byData.Length; i++)
                {
                    {
                        string temp = (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X"));
                        if (temp.Trim().Equals(HexaCompare))
                        {
                            Trave = i+1;
                            break;
                        }
                    }

                }
            }
            return Trave;
        }
    }
}
