using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelolaDataSiswa
{
    class Program
    {
        static string[] namaSiswa = new string[100];
        static string[] kelasSiswa = new string[100];
        static int[] absenSiswa = new int[100];
        static double[] nilaiSiswa = new double[100];

        static int jumlahData = 0;

        static void Main(string[] args)
        {
            int pilihan;
            bool keluar = false;

            Console.WriteLine("\n===== PROGRAM PENGELOLA DATA SISWA KELAS 10 =====");

            do
            {
                Console.WriteLine("\n=== MENU UTAMA ===");
                Console.WriteLine("1. Tambah Data Siswa Kelas 10");
                Console.WriteLine("2. Tampilkan Semua Data Siswa Kelas 10");
                Console.WriteLine("3. Hitung Rata-rata Nilai Siswa Kelas 10");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilih menu (1-4) : ");

                string inputPilihan = Console.ReadLine();

                if (!int.TryParse(inputPilihan, out pilihan))
                {
                    Console.WriteLine("\n⛔ Input tidak valid. Harap masukkan angka 1-4.");
                    continue;
                }

                if (pilihan == 1)
                {
                    TambahDataSiswa();
                }
                else if (pilihan == 2)
                {
                    TampilkanDataSiswa();
                }
                else if (pilihan == 3)
                {
                    HitungRataRata();
                }
                else if (pilihan == 4)
                {
                    Console.WriteLine("\n😘 Terima kasih telah menggunakan program ini. Sampai jumpa!\n");
                    keluar = true;
                }
                else
                {
                    Console.WriteLine("\n⛔ Pilihan tidak valid. Harap pilih menu 1-4.");
                }

            } while (!keluar);
        }

        static void TambahDataSiswa()
        {
            bool tambahLagi = true;

            do
            {
                Console.WriteLine("\n=== TAMBAH DATA SISWA ===");

                if (jumlahData >= 100)
                {
                    Console.WriteLine("🙏 Maaf, kapasitas data siswa sudah penuh (maksimal 100).");
                    Console.WriteLine("⛔ Tidak dapat menambahkan data lagi.\n");

                    tambahLagi = false;
                    continue;
                }

                Console.Write("Masukkan Nama Siswa : ");
                string nama = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nama))
                {
                    Console.WriteLine("\n⛔ Nama siswa tidak boleh kosong.\n");
                    goto TanyakanTambahLagi;
                }

                Console.Write("Masukkan Kelas Siswa : ");
                string kelas = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(kelas))
                {
                    Console.WriteLine("\n⛔ Kelas tidak boleh kosong.\n");
                    goto TanyakanTambahLagi;
                }

                Console.Write("Masukkan Nomor Absen Siswa : ");
                string inputAbsen = Console.ReadLine();

                if (!int.TryParse(inputAbsen, out int absen) || absen <= 0)
                {
                    Console.WriteLine("\n⛔ Nomor absen harus berupa angka positif.\n");
                    goto TanyakanTambahLagi;
                }

                Console.Write("Masukkan Nilai Siswa : ");
                string inputNilai = Console.ReadLine();

                if (!double.TryParse(inputNilai, out double nilai) || nilai < 0 || nilai > 100)
                {
                    Console.WriteLine("\n⛔ Nilai harus berupa angka antara 0 dan 100.\n");
                    goto TanyakanTambahLagi;
                }

                namaSiswa[jumlahData] = nama;
                kelasSiswa[jumlahData] = kelas;
                absenSiswa[jumlahData] = absen;
                nilaiSiswa[jumlahData] = nilai;

                jumlahData++;

                Console.WriteLine("\n✅ Data siswa berhasil ditambahkan!\n");

            TanyakanTambahLagi:
                if (jumlahData < 100)
                {
                    Console.Write("Tambah data lagi? (Y/N) : ");
                    string jawaban = Console.ReadLine()?.Trim().ToUpper();

                    if (jawaban == "N")
                    {
                        tambahLagi = false;
                    }
                    else if (jawaban != "Y")
                    {
                        Console.WriteLine("\n⛔ Input tidak valid. Harap masukkan 'Y' atau 'N'.");
                    }
                }
                else
                {
                    tambahLagi = false;
                }

            } while (tambahLagi);
        }

        static void TampilkanDataSiswa()
        {
            Console.WriteLine("\n=== DAFTAR DATA SISWA ===");

            if (jumlahData == 0)
            {
                Console.WriteLine("⛔ Belum ada data siswa yang dimasukkan.");
                return;
            }

            for (int i = 0; i < jumlahData; i++)
            {
                Console.WriteLine($"Siswa ke-{i + 1} :");
                Console.WriteLine($"  Nama   : {namaSiswa[i]}");
                Console.WriteLine($"  Kelas  : {kelasSiswa[i]}");
                Console.WriteLine($"  Absen  : {absenSiswa[i]}");
                Console.WriteLine($"  Nilai  : {nilaiSiswa[i]:F2}");
                Console.WriteLine("------------------------------");
            }
        }

        static void HitungRataRata()
        {
            Console.WriteLine("\n=== RATA-RATA NILAI SISWA ===");

            if (jumlahData == 0)
            {
                Console.WriteLine("⛔ Belum ada data siswa yang dimasukkan.");
                Console.WriteLine("Tidak dapat menghitung rata-rata.");
                return;
            }

            double totalNilai = 0;
            int indeks = 0;

            while (indeks < jumlahData)
            {
                totalNilai += nilaiSiswa[indeks];
                indeks++;
            }

            double rataRata = totalNilai / jumlahData;

            Console.WriteLine($"Jumlah Siswa : {jumlahData}");
            Console.WriteLine($"Total Nilai Keseluruhan : {totalNilai:F2}");
            Console.WriteLine($"Rata-rata Nilai : {rataRata:F2}");
        }
    }
}

// MOCH RAIHAN FADILLAH / 21 / X RPL D