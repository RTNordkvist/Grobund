using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace Grobund.DatabaseInitializer
{
    internal class Program
    {

        private const string FILE_PATH = "../../../Medlemskartotek.xlsx";

        static void Main(string[] args)
        {
            var associationRepository = new AssociationRepository();
            var memberRepository = new MemberRepository();
            var certificateRepository = new CertificateRepository();
            var tradeRepository = new TradeRepository();

            // CREATE ASSOCIATIONS
            var associations = new List<Association>();

            var associationFabrik = new Association
            {
                Name = "Grobund Fabrik",
                MaxNoOfCertificates = 160,
                CertificatePrice = 50000
            };
            associationRepository.Create(associationFabrik);
            associations.Add(associationFabrik);

            var associationJord = new Association
            {
                Name = "Grobund Jord",
                MaxNoOfCertificates = 160,
                CertificatePrice = 50000
            };
            //associationRepository.Create(associationJord);
            associations.Add(associationJord);

            // READ EXCELSHEET
            FileInfo existingFile = new FileInfo(FILE_PATH);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                var members = new List<Member>();

                //READ MEMBERS
                Console.WriteLine("Adding members");

                ExcelWorksheet memberWorksheet = package.Workbook.Worksheets[1];
                int rowCount = memberWorksheet.Dimension.End.Row;
                for (int row = 2; row <= rowCount; row++)
                {
                    var m_id = memberWorksheet.Cells[row, 1].Value?.ToString().Trim();

                    if (m_id != null)
                    {
                        var createdDate = memberWorksheet.Cells[row, 2].Value?.ToString().Trim();
                        var name = memberWorksheet.Cells[row, 3].Value?.ToString().Trim();
                        var email = memberWorksheet.Cells[row, 4].Value?.ToString().Trim();
                        var mobilephone = memberWorksheet.Cells[row, 5].Value?.ToString().Trim();
                        var telephone = memberWorksheet.Cells[row, 6].Value?.ToString().Trim();
                        var address1 = memberWorksheet.Cells[row, 7].Value?.ToString().Trim();
                        var address2 = memberWorksheet.Cells[row, 8].Value?.ToString().Trim();
                        var postalCode = memberWorksheet.Cells[row, 9].Value?.ToString().Trim();
                        var city = memberWorksheet.Cells[row, 10].Value?.ToString().Trim();
                        var country = memberWorksheet.Cells[row, 11].Value?.ToString().Trim();

                        var member = new Member
                        {
                            MemberNo = m_id,
                            Name = name,
                            Email = email,
                            MobileNumber = mobilephone,
                            PhoneNumber = telephone,
                            Address1 = address1,
                            Address2 = address2,
                            PostalCode = postalCode,
                            City = city,
                            Country = country
                        };

                        try
                        {
                            member.Registered = DateTime.Parse(createdDate);
                        }
                        catch
                        {
                            try
                            {
                                member.Registered = DateTime.FromOADate(Double.Parse(createdDate));
                            }
                            catch
                            {
                                member.Registered = DateTime.MinValue;
                            }
                        }

                        //member.Id = memberRepository.Create(member);
                        members.Add(member);
                    }
                }

                Console.WriteLine($"Done - added {members.Count} members");

                // READ FABRIK BRUGERBEVIS

                Console.WriteLine("Adding certificates");
                var fabrikCertificates = new List<Certificate>();
                //var fabrik = associations.FirstOrDefault(x => x.Name == "Grobund Fabrik");
                var fabrik = associationRepository.GetById(15);

                ExcelWorksheet usercertificateWorksheet = package.Workbook.Worksheets[5];
                int certificateRowCount = usercertificateWorksheet.Dimension.End.Row;
                for (int row = 2; row <= certificateRowCount; row++)
                {
                    var m_id = usercertificateWorksheet.Cells[row, 1].Value?.ToString().Trim();
                    if (m_id != null)
                    {
                        var usercertificate = usercertificateWorksheet.Cells[row, 2].Value?.ToString().Trim();

                        //var owner = members.FirstOrDefault(x => x.MemberNo == m_id);
                        int.TryParse(m_id, out int SearchID);
                        var owner = memberRepository.ReadById(SearchID);

                        var certificate = new Certificate
                        {
                            CertificateNumber = usercertificate,
                            AssociationId = fabrik.Id,
                            OwnerId = owner?.Id,
                            PaidAmount = fabrik.CertificatePrice
                        };
                        certificate.Id = certificateRepository.Create(certificate);
                        fabrikCertificates.Add(certificate);
                    }
                }

                for (int i = 1; i <= fabrik.MaxNoOfCertificates; i++)
                {
                    if (!fabrikCertificates.Any(x => Int32.Parse(x.CertificateNumber) == i))
                    {
                        var certificate = new Certificate
                        {
                            CertificateNumber = i.ToString(),
                            AssociationId = fabrik.Id,
                            PaidAmount = 0
                        };
                        certificate.Id = certificateRepository.Create(certificate);
                        fabrikCertificates.Add(certificate);
                    }
                }

                // READ JORDBEVIS
                var jordCertificates = new List<Certificate>();
                var jord = associationRepository.GetById(16);

                //var factoryCertificates = new List<Certificate>();
                //factoryCertificates = certificateRepository.

                ExcelWorksheet usercertificateJordWorksheet = package.Workbook.Worksheets[6];
                int certificateJordRowCount = usercertificateJordWorksheet.Dimension.End.Row;
                for (int row = 2; row <= certificateJordRowCount; row++)
                {
                    var m_id = usercertificateJordWorksheet.Cells[row, 1].Value?.ToString().Trim();

                    if (m_id != null)
                    {
                        var paid = usercertificateJordWorksheet.Cells[row, 2].Value?.ToString().Trim();

                        int.TryParse(m_id, out int SearchID);
                        var owner = memberRepository.ReadById(SearchID);

                        var certificate = new Certificate
                        {
                            CertificateNumber = fabrikCertificates.FirstOrDefault(x => x.OwnerId == owner.Id).CertificateNumber,
                            AssociationId = jord.Id,
                            OwnerId = owner?.Id,
                            PaidAmount = paid == "25K" ? 25000 : 50000
                        };
                        certificate.Id = certificateRepository.Create(certificate);
                        jordCertificates.Add(certificate);
                    }
                }

                for (int i = 1; i <= jord.MaxNoOfCertificates; i++)
                {
                    if (!jordCertificates.Any(x => Int32.Parse(x.CertificateNumber) == i))
                    {
                        var certificate = new Certificate
                        {
                            CertificateNumber = i.ToString(),
                            AssociationId = jord.Id,
                            PaidAmount = 0
                        };
                        certificate.Id = certificateRepository.Create(certificate);
                        jordCertificates.Add(certificate);
                    }
                }

                Console.WriteLine($"Done - added {fabrikCertificates.Count + jordCertificates.Count} certificates");


                // ADD DEMO DATA FOR TRADES

                Random r = new Random();

                var trades = new List<Trade>();
                var membersArray = members.ToArray();

                var ownedFabriksCertificates = fabrikCertificates.Where(x => x.OwnerId != null).ToList();
                var ownedJordCertificates = jordCertificates.Where(x => x.OwnerId != null).ToList();
                Console.WriteLine("Creating DEMO trades");
                foreach (var certificate in ownedFabriksCertificates)
                {
                    var noOfTrades = r.Next(0, 5);



                    var seller = membersArray[r.Next(membersArray.Length)];
                    var buyer = members.First(x => x.MemberNo == certificate.OwnerId.ToString());
                    var minDate = seller.Registered > buyer.Registered ? seller.Registered : buyer.Registered;
                    var maxDate = DateTime.Now.AddDays(-1);

                    var newTicks = r.NextInt64(minDate.Ticks, maxDate.Ticks);
                    var date = new DateTime(newTicks);


                    int.TryParse(seller.MemberNo, out int sellerId);

                    int.TryParse(buyer.MemberNo, out int buyerId);


                    for (var i = 0; i <= noOfTrades; i++)
                    {
                        var tradefabrik = new Trade()
                        {
                            CertificateId = certificate.Id,
                            SellerId = sellerId,
                            BuyerId = buyerId,
                            Date = date
                        };

                        trades.Add(tradefabrik);

                        var jordBevis = ownedJordCertificates.FirstOrDefault(x => x.CertificateNumber == certificate.CertificateNumber);
                        if (jordBevis != null)
                        {
                            var tradejord = new Trade()
                            {
                                CertificateId = jordBevis.Id,
                                SellerId = sellerId,
                                BuyerId = buyerId,
                                Date = date
                            };
                            trades.Add(tradejord);
                        }

                        buyerId = sellerId;
                        int.TryParse(membersArray[r.Next(membersArray.Length)].MemberNo, out int sellerIdTemp);
                        sellerId = sellerIdTemp;
                        date = new DateTime(r.NextInt64(minDate.Ticks, date.Ticks));
                    }
                }

                foreach(var trade in trades)
                {
                    trade.Id = tradeRepository.Create(trade);
                }
                Console.WriteLine($"Done - created {trades.Count} trades");

            }
        }
    }
}