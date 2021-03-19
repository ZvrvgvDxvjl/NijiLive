using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Net;
using System.IO;
using System.Threading;
using NijiLive.classes;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Windows.Media;
namespace NijiLive
{
    public partial class MainWindow : Window
    {
        private List<Channel> channels = new List<Channel>();
        //controls how many request can be send at the same time, 30 per default
        private static readonly int MAX_NR_TASKS = 30;
        public MainWindow()
        {
            InitializeComponent();
            ProgressBarLiveCheck.Minimum = 0;
            //disabling them in the code to be able to still see them in the xaml preview
            CheckBoxAddToCurrent.Visibility = Visibility.Hidden;
            LabelFilter.Visibility = Visibility.Hidden;
            LabelAgency.Visibility = Visibility.Hidden;
            LabelRegion.Visibility = Visibility.Hidden;
            CheckBoxHoloLive.Visibility = Visibility.Hidden;
            CheckBoxNijisanji.Visibility = Visibility.Hidden;
            CheckBoxIndependant.Visibility = Visibility.Hidden;
            CheckBoxAgenciesOther.Visibility = Visibility.Hidden;
            CheckBoxJP.Visibility = Visibility.Hidden;
            CheckBoxEN.Visibility = Visibility.Hidden;
            CheckBoxID.Visibility = Visibility.Hidden;
            CheckBoxRegionOther.Visibility = Visibility.Hidden;
            ButtonRemoveChannel.Visibility = Visibility.Hidden;
            ButtonEditChannel.Visibility = Visibility.Hidden;
            ButtonCheckLive.Visibility = Visibility.Hidden;
            ButtonSaveList.Visibility = Visibility.Hidden;
            //commented out due to loading/saving implementation, left here to be able to quickly create a default channel list
            #region hardcoded default list
            /*
            string hololive = "Hololive";
            string nijisanji = "Nijisanji";
            string jp = "JP";
            string id = "ID";
            string en = "EN";
            string india = "IN";
            string kr = "KR";
            string zeroth = "0th";
            string first = "1st";
            string second = "2nd";
            string gamers = "Gamers";
            string third = "3rd";
            string fourth = "4th";
            string fifth = "5th";
            string twenty19 = "2019";
            string twenty20 = "2020";
            //Holo Gen 0
            channels.Add(new Channel("https://www.youtube.com/channel/UCp6993wxpyDPHUpavwDFqgg", "Sora", hololive, jp, zeroth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCDqI2jOz0weumE8s7paEk6g", "Roboco", hololive, jp, zeroth));
            channels.Add(new Channel("https://www.youtube.com/channel/UC-hM6YJuNYVAmUWxeIr9FeA", "Miko", hololive, jp, zeroth));
            channels.Add(new Channel("https://www.youtube.com/channel/UC5CwaMl1eIgY8h02uZw7u8A", "Suisei", hololive, jp, zeroth));
            channels.Add(new Channel("https://www.youtube.com/channel/UC0TXe_LYZ4scaW2XMyi5_kw", "AZKi", hololive, jp, zeroth));
            //Holo Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCD8HOxPs4Xvsm8H0ZxXGiBw", "Mel", hololive, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCdn5BQ06XqgXoAxIhbqw5Rg", "Fubuki", hololive, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCQ0UDLQCjY0rmuxCDE38FGg", "Matsuri", hololive, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCFTLzh12_nrtzqBPsTCqenA", "Akirose", hololive, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UC1CfXB_kRs3C-zaeTG3oGyg", "Haachama", hololive, jp, first));
            //Holo Gen 2
            channels.Add(new Channel("https://www.youtube.com/channel/UC1opHUrw8rvnsadT-iGp7Cg", "Aqua", hololive, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCXTpFs_3PqI41qX2d9tL2Rw", "Shion", hololive, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC7fk0CB07ly8oSl0aqKkqFg", "Ayame", hololive, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC1suqwovbL1kzsoaZgFZLKg", "Choco", hololive, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCvzGlP9oQwU--Y0r9id_jnA", "Subaru", hololive, jp, second));
            //Holo Gamers
            channels.Add(new Channel("https://www.youtube.com/channel/UCp-5t9SrOQwXMU7iIjQfARg", "Mio", hololive, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UCvaTdHTWBGv3MKj3KVqJVCw", "Okayu", hololive, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UChAnqc_AY5_I3Px5dig3X1Q", "Korone", hololive, jp, gamers));
            //Holo Gen 3
            channels.Add(new Channel("https://www.youtube.com/channel/UC1DCedRgGHBdm81E1llLhOQ", "Pekora", hololive, jp, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCl_gCybOJRIgOXw6Qb4qJzQ", "Rushia", hololive, jp, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCvInZx9h3jC2JzsIzoOebWg", "Flare", hololive, jp, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCdyqAaZDKHXg4Ahi7VENThQ", "Noel", hololive, jp, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCCzUftO8KOVkV4wQG1vkUvg", "Marine", hololive, jp, third));
            //Holo Gen 4
            channels.Add(new Channel("https://www.youtube.com/channel/UCZlDXzGoo7d44bwdNObFacg", "Kanata", hololive, jp, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCS9uQI-jC3DE0L4IpXyvr6w", "Coco", hololive, jp, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCqm3BQLlJfvkTsX_hvm0UmA", "Watame", hololive, jp, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UC1uv2Oq6kNxgATlCiez59hw", "Towa", hololive, jp, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCa9Y57gfeY0Zro_noHRVrnw", "Luna", hololive, jp, fourth));
            //Holo Gen 5
            channels.Add(new Channel("https://www.youtube.com/channel/UCFKOVgVbGmX65RxO3EtH3iw", "Lamy", hololive, jp, fifth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCAWSyEs_Io8MtpY3m-zqILA", "Nene", hololive, jp, fifth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCUKD-uaobj9jiqB-VXt71mA", "Botan", hololive, jp, fifth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCK9V2B22uJYu3N7eR_BT9QA", "Polka", hololive, jp, fifth));
            //Holo ID Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCOyYb1c43VlX9rc_lT6NKQw", "Risu", hololive, id, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCP0BspO_AMEe3aQqqpo89Dg", "Moona", hololive, id, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCAoy6rzhSf4ydcYjJw3WoVg", "Iofi", hololive, id, first));
            //Holo ID Gen 2
            channels.Add(new Channel("https://www.youtube.com/channel/UCYz_5n-uDuChHtLo7My1HnQ", "Ollie", hololive, id, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC727SQYUvx5pDDGQpTICNWg", "Anya", hololive, id, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UChgTyjG-pdNvxxhdsXfHQ5Q", "Reine", hololive, id, second));
            //Holo EN Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCL_qhgtOy0dy1Agp8vkySQg", "Mori", hololive, en, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCHsx4Hqa-1ORjQTh9TYDhww", "Kiara", hololive, en, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCMwGHR0BTZuLsmjY_NT5Pwg", "Ina", hololive, en, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCoSrY_IQQVpmIRZ9Xf-y93g", "Gura", hololive, en, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCyl1z3jo3XHR1riLFKG5UAg", "Amelia", hololive, en, first));
            //Niji Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCD-miitqNY3nyukJ4Fnf4_A", "Tsukino Mito", nijisanji, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCLO9QDxVL4bnvRRsz6K4bsQ", "Yuki Chihiro", nijisanji, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCYKP16oMX9KKPbrNgo_Kgag", "Elu", nijisanji, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCsg-YqdqQ-KFF0LNk23BY4A", "Higuchi Kaede", nijisanji, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UC6oDys1BGgBsIC3WhG1BovQ", "Shizuka Rin", nijisanji, jp, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCvmppcdYf4HOv-tFQhHHJMA", "Moira", nijisanji, jp, first));
            //Niji Gen 2
            channels.Add(new Channel("https://www.youtube.com/channel/UCt0clH12Xk1-Ej5PXKGfdPA", "Alice", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC_GCs6GARLxEHxy1w40d6VQ", "Mugi", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCtpB6Bvhs1Um93ziEDACQ8g", "Kazaki", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCwokZsOK_uEre70XayaFnzA", "Suzuka Utako", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCmUjjW5zF1MMOhYUwwwQv9Q", "Ushimi Ichigo", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC48jH1ul-6HOrcSSfoR02fQ", "Yuhi Riri", nijisanji, jp, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCBiqkFJljoxAj10SoP2w2Cg", "Fumino Tamaki", nijisanji, jp, second));
            //Niji Gamers
            channels.Add(new Channel("https://www.youtube.com/channel/UCBi8YaVyZpiKWN3_Z0dCTfQ", "Akabane Youko", nijisanji, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UCoztvTULBYd3WmStqYeoHcA", "Sasaki Saku", nijisanji, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UC0g1AE0DOjBYnLhkgoRWN1w", "Honma Himawari", nijisanji, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UC9EjSJ8pvxtvPdxLOElv73w", "Makaino Ririmu", nijisanji, jp, gamers));
            channels.Add(new Channel("https://www.youtube.com/channel/UC_4tXjqecqox5Uc05ncxpxg", "Shiina Yuika", nijisanji, jp, gamers));
            //Niji Ex-Seed
            channels.Add(new Channel("https://www.youtube.com/channel/UC53UDnhAAYwvNO7j_2Ju1cQ", "Dola", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UC6TfqY40Xt1Y0J-N18c85qQ", "Azuchi Momo", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UC1zFJrfEKvCixhsjNSb1toQ", "Sister Claire", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCRV9d6YCYIMUszK-83TwxVA", "Todoroki Kyoko", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCRWOdwLRsenx2jLaiCAIU4A", "Amemori Sayo", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCV5ZZlLjk5MKGg3L0n0vbzw", "Takamiya Rion", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCiSRx1a2k-0tOg-fs6gAolQ", "Asuka Hina", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCPvGypSgfDkVe7JG2KygK7A", "Rindou Mikoto", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCo7TRj3cS-f_1D9ZDmuTsjw", "Machita Chima", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCfQVs_KuXeNAlGa3fb8rlnQ", "Sakura Ritsuki", nijisanji, jp, string.Empty));
            channels.Add(new Channel("https://www.youtube.com/channel/UCvzVB-EYuHFXHZrObB8a_Og", "Yaguruma Rine", nijisanji, jp, string.Empty));
            //Niji 2019
            channels.Add(new Channel("https://www.youtube.com/channel/UCveZ9Ic1VtcXbsyaBgxPMvg", "Warabeda Meiji", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCeShTCVgZyq2lsBW9QwIJcw", "Gundo Mirei", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCCVwhI5trmaSxfcze_Ovzfw", "Yuzuki Roa", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCg63a3lk6PNeWhVvMRM_mrQ", "Onomachi Haruka", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCufQu4q65z63IgE4cfKs1BQ", "Kataribe Tsumugu", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCHK5wkevfaGrPr7j3g56Jmw", "Seto Miyako", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCXRlIK3Cw_TJIQC5kSJJQMg", "Inui Toko", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCHVXbQzkl3rDfsXWo8xi2qw", "Ange Katrina", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCZ1xuCK1kNmn5RzPYIZop3w", "Lize Helesta", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC0WwEfE-jOM2rzjpdfhTzZA", "Aizono Manami", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC_a1ZYZ8ZTXpjg9xUY9sj8w", "Suzuhara Lulu", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCHX7YpFG8rVwhsHCx34xt7w", "Yukishiro Mahiro", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCtnO2N4kPTXmyvedjGWdx3Q", "Levi Elipha", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCfipDDn7wY-C-SoUChgxCQQ", "Hayama Marin", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCUc8GZfFxtmk7ZwSO7ccQ0g", "Nui Sociere", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCGYAYLDE7TZiiC8U6teciDQ", "Hakase Fuyuki", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCL34fAoFim9oHLbVzMKFavQ", "Yorumi Rena", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCdpUojq0KWZCN9bxXnZwz5w", "Ars Almal", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCnRQYHTnRLSF0cLJwMnedCg", "Aiba Uiha", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCkIimWZ9gBJRamKF0rmPU8w", "Amamiya Kokoro", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCpNH2Zk2gw3JBjWAKSyZcQQ", "Eli Conifer", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCIG9rDtgR45VCZmYnd-4DUw", "Ratna Petit", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC2OacIzd2UxGHRGhdHl1Rhw", "Hayase Sou", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC8C1LLhBhf_E2IBPLSDJXlQ", "Sukoya Kana", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCwrjITPwG4q71HzihV2C7Nw", "Fumi", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC9V3Y3_uzU5e-usObb6IE1w", "Hoshikawa Sara", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCllKI7VjyANuS1RXatizfLQ", "Yamagami Karuta", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCerkculBD7YLc_vOGrF7tKg", "Matsukai Mao", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCl1oLKcAq93p-pwKfDGhiYQ", "Emma August", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCb6ObE-XGCctO3WrjRZC-cw", "Luis Cammy", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCuvk5PilcvDECU7dDZhQiEw", "Shirayuki Tomoe", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UC-o-E6I3IC2q8sAoAuM6Umg", "Naraka", nijisanji, jp, twenty19));
            channels.Add(new Channel("https://www.youtube.com/channel/UCRcLAVTbmx2-iNcXSsupdNA", "Kurusu Natsume", nijisanji, jp, twenty19));
            //Niji 2020
            channels.Add(new Channel("https://www.youtube.com/channel/UCuep1JCrMvSxOGgGhBfJuYw", "Furen E Lustario", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCwcyyxn6h9ex4sMXGtpQE_g", "Melissa Kinrenka", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UC_82HBGtvwN1hcGeOGHzUBQ", "Sorahoshi Kirame", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCe_p3YEuYJb8Np0Ip9dk-FQ", "Asahina Akane", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCL_O_HXgLJx3Auteer0n0pA", "Suo Sango", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCebT4Aq-3XWb5je1S1FvR_A", "Todo Kohaku", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCRqBKoKuX30ruKAq05pCeRQ", "Kitakoji Hisui", nijisanji, jp, twenty20));
            channels.Add(new Channel("https://www.youtube.com/channel/UCkngxfPbmGyGl_RIq4FA3MQ", "Nishizono Chigusa", nijisanji, jp, twenty20));
            //Niji ID Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCpJtk0myFr5WnyfsmnInP-w", "Hana Macchia", nijisanji, id, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UCA3WE2WRSpoIvtnoVGq4VAw", "ZEA Cornelia", nijisanji, id, first));
            //Niji ID Gen 2
            channels.Add(new Channel("https://www.youtube.com/channel/UCrR7JxkbeLY82e8gsj_I0pQ", "Amicia Michella", nijisanji, id, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCOmjciHZ8Au3iKMElKXCF_g", "Miyu Ottavia", nijisanji, id, second));
            //Niji ID Gen 3
            channels.Add(new Channel("https://www.youtube.com/channel/UCk5r533QVMgJUdWwqegH2TA", "Azura Cecillia", nijisanji, id, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCyRkQSuhJILuGOuXk10voPg", "Layla Alstroemeria", nijisanji, id, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCoWH3sDpeXG1aXmOxveX4KA", "Nara Haramaung", nijisanji, id, third));
            //Niji ID Gen 4
            channels.Add(new Channel("https://www.youtube.com/channel/UCjFu-9GHnabzSFRAYm1B9Dw", "Etna Crimson", nijisanji, id, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UC5qSx7KzdRwbsO1QmJc4d-w", "Siska Leontyne", nijisanji, id, fourth));
            //Niji ID Gen 5
            channels.Add(new Channel("https://www.youtube.com/channel/UCijNnZ-6m8g85UGaRAWuw7g", "Nagisa Arcinia", nijisanji, id, fifth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCMzVa7B8UEdrvUGsPmSgyjA", "Derem Kado", nijisanji, id, fifth));
            //Niji India
            channels.Add(new Channel("https://www.youtube.com/channel/UC_aB_-PHLFHiP61djM0oOiQ", "Aadya", nijisanji, india, first));
            channels.Add(new Channel("https://www.youtube.com/channel/UC6oW4FXETgEGOFTxWmI2h5Q", "Noor", nijisanji, india, first));
            //Niji KR Gen 1
            channels.Add(new Channel("https://www.youtube.com/channel/UCjGE11ZnF0JSR8egVAwh-3A", "Yuya Shin", nijisanji, kr, first));
            //Niji KR Gen 2
            channels.Add(new Channel("https://www.youtube.com/channel/UCSlv7Z-4q7_7NRkzJB10A5Q", "Siu Lee", nijisanji, kr, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UC5ek2GWKvUKFgnKSHuuCFrw", "Nagi So", nijisanji, kr, second));
            channels.Add(new Channel("https://www.youtube.com/channel/UCmWqYB6y8gSfPONWGspuOWQ", "Ara Chae", nijisanji, kr, second));
            //Niji KR Gen 3
            channels.Add(new Channel("https://www.youtube.com/channel/UC7hffDQLKIEG-_zoAQkMIvg", "Ray Akira", nijisanji, kr, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UCClwIqTUn5LDpFucHyaAhHg", "Roha Lee", nijisanji, kr, third));
            channels.Add(new Channel("https://www.youtube.com/channel/UC1ZV7KBscK0EMoJKFu1DnDg", "Bora Nun", nijisanji, kr, third));
            //Niji KR Gen 4
            channels.Add(new Channel("https://www.youtube.com/channel/UCnzZmBOSrQf2wDBbnsDajVw", "Jiyu Oh", nijisanji, kr, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UCCHH0nWYXFZmtDS_4tvMxHQ", "Nari Yang", nijisanji, kr, fourth));
            channels.Add(new Channel("https://www.youtube.com/channel/UClS6k3w1sPwlVFqK3-yID5A", "Hari Ryu", nijisanji, kr, fourth));
            RefreshChannelList(channels);
            */
            #endregion
        }
        private async void ButtonCheckLive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfChannelsStreaming = 0;
                int perc = 0;
                var progress = new Progress<int>(value => ProgressBarLiveCheck.Value = value);
                List<Channel> currentChannels = FilterChannelList(channels);
                ProgressBarLiveCheck.Maximum = currentChannels.Count;
                ProgressBarLiveCheck.Visibility = Visibility.Visible;
                LabelMessage.Content = "Checking what channels are live, this will take approximately 1-2sec per channel.";
                //limits how many HTML requests are send at the same time
                SemaphoreSlim ss = new SemaphoreSlim(MAX_NR_TASKS);
                List<Task> trackedTasks = new List<Task>();
                await Task.Factory.StartNew(() =>
                {
                    foreach (Channel c in currentChannels)
                    {
                        ss.WaitAsync();
                        trackedTasks.Add(Task.Factory.StartNew(() =>
                        {
                            c.Live = CheckLive(c.URL + "/live");
                            perc++;
                            ((IProgress<int>)progress).Report(perc);
                            ss.Release();
                        }, TaskCreationOptions.AttachedToParent));
                    }
                }).ContinueWith(task =>
                {
                    //UI getting updated once all the HTML requests are fully processed
                    numberOfChannelsStreaming = currentChannels.Count(x => x.Live == true);
                    RefreshChannelList(currentChannels.OrderByDescending(x => x.Live).ToList());
                    ProgressBarLiveCheck.Value = 0;
                    ProgressBarLiveCheck.Visibility = Visibility.Hidden;
                    LabelMessage.Content = "Number of channels currently live: " + numberOfChannelsStreaming;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error requesting HTML pages.";
            }
        }
        private bool CheckLive(string URL)
        {
            bool retVal = false;
            //Creates HTML Request.
            var request = WebRequest.Create(URL);
            //Language needs to be english to be able to tell waiting rooms from streams with the below method.
            request.Headers["Accept-Language"] = "en";
            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                //If youtube updates its HTML pages and the programm stops working this is the line that has to be updated.
                //waiting room: {"text":" waiting"}]},"isLive":true}}
                //stream: {"text":" watching now"}]},"isLive":true}}
                retVal = reader.ReadToEnd().Contains(@"now""}]},""isLive"":true");
            }
            return retVal;
        }
        private void ButtonSaveList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt",
                    InitialDirectory = Directory.GetCurrentDirectory() + @"\ChannelLists",
                };
                if (sfd.ShowDialog() == true)
                {
                    //Formatting.Intended makes it easier to edit outside of the programm
                    File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(FilterChannelList(channels), Formatting.Indented));
                    LabelMessage.Content = "Successfully saved channel list.";
                }
                else
                {
                    LabelMessage.Content = "Canceled saving file.";
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to save the file.";
            }
        }
        private void ButtonLoadList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Text files (*.txt)|*.txt",
                    InitialDirectory = Directory.GetCurrentDirectory() + @"\ChannelLists",
                    Multiselect = false
                };
                if(ofd.ShowDialog() == true)
                {
                    if ((bool)CheckBoxAddToCurrent.IsChecked)
                    {
                        int numberOfAlreadyExistingChannels = 0;
                        List<Channel> newChannels = new List<Channel>();
                        newChannels = JsonConvert.DeserializeObject<List<Channel>>(File.ReadAllText(ofd.FileName));
                        foreach(Channel c in newChannels)
                        {
                            if (!NameExistsInList(c.Name) && !URLExistsInList(c.URL))
                            {
                                channels.Add(c);
                            }
                            else
                            {
                                numberOfAlreadyExistingChannels++;
                            }
                        }
                        RefreshChannelList(FilterChannelList(channels));
                        if (numberOfAlreadyExistingChannels > 0)
                        {
                            LabelMessage.Content = "Added channels to current list (" + numberOfAlreadyExistingChannels +
                                " duplicates ignored).";
                        }
                        else
                        {
                            LabelMessage.Content = "Added channels to current list (no duplicates).";
                        }
                    }
                    else
                    {
                        channels = JsonConvert.DeserializeObject<List<Channel>>(File.ReadAllText(ofd.FileName));
                        RefreshChannelList(FilterChannelList(channels));
                        LabelMessage.Content = "Successfully loaded channel list.";
                    }
                }
                else
                {
                    LabelMessage.Content = "Canceled loading file.";
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to load the file.";
            }
        }
        private void RefreshChannelList(List<Channel> list)
        {
            ListBoxChannelList.Items.Clear();
            if (channels.Count > 0)
            {
                RefreshOptionalUI(true);
            }
            else
            {
                RefreshOptionalUI(false);
            }
            foreach(Channel c in list)
            {
                if(c.Live)
                {

                    //as some code relies on toString() of the list box items and the default toString()
                    //of ListBoxItem is Type+Content a custom class that overrides that toString() has to be used
                    CustomListBoxItem cItem = new CustomListBoxItem
                    {
                        Content = c.ToString() + " is LIVE",
                        //makes it so LIVE channels are higlighted red
                        Background = new SolidColorBrush(Colors.Red) { Opacity = 0.1 }
                    };
                    ListBoxChannelList.Items.Add(cItem);
                }
                else 
                {
                    ListBoxChannelList.Items.Add(c.ToString());
                }
            }
        }
        private void RefreshOptionalUI(bool param)
        {
            if (param)
            {
                CheckBoxAddToCurrent.Visibility = Visibility.Visible;
                LabelFilter.Visibility = Visibility.Visible;
                LabelAgency.Visibility = Visibility.Visible;
                LabelRegion.Visibility = Visibility.Visible;
                CheckBoxHoloLive.Visibility = Visibility.Visible;
                CheckBoxNijisanji.Visibility = Visibility.Visible;
                CheckBoxIndependant.Visibility = Visibility.Visible;
                CheckBoxAgenciesOther.Visibility = Visibility.Visible;
                CheckBoxJP.Visibility = Visibility.Visible;
                CheckBoxEN.Visibility = Visibility.Visible;
                CheckBoxID.Visibility = Visibility.Visible;
                CheckBoxRegionOther.Visibility = Visibility.Visible;
                ButtonRemoveChannel.Visibility = Visibility.Visible;
                ButtonEditChannel.Visibility = Visibility.Visible;
                ButtonCheckLive.Visibility = Visibility.Visible;
                ButtonSaveList.Visibility = Visibility.Visible;
            }
            else
            {
                CheckBoxAddToCurrent.Visibility = Visibility.Hidden;
                LabelFilter.Visibility = Visibility.Hidden;
                LabelAgency.Visibility = Visibility.Hidden;
                LabelRegion.Visibility = Visibility.Hidden;
                CheckBoxHoloLive.Visibility = Visibility.Hidden;
                CheckBoxNijisanji.Visibility = Visibility.Hidden;
                CheckBoxIndependant.Visibility = Visibility.Hidden;
                CheckBoxAgenciesOther.Visibility = Visibility.Hidden;
                CheckBoxJP.Visibility = Visibility.Hidden;
                CheckBoxEN.Visibility = Visibility.Hidden;
                CheckBoxID.Visibility = Visibility.Hidden;
                CheckBoxRegionOther.Visibility = Visibility.Hidden;
                ButtonRemoveChannel.Visibility = Visibility.Hidden;
                ButtonEditChannel.Visibility = Visibility.Hidden;
                ButtonCheckLive.Visibility = Visibility.Hidden;
                ButtonSaveList.Visibility = Visibility.Hidden;
            }
        }
        private List<Channel> FilterChannelList(List<Channel> list)
        {
            List<Channel> retVal = new List<Channel>();
            //no agency + no region
            if(!(bool)CheckBoxHoloLive.IsChecked && !(bool)CheckBoxNijisanji.IsChecked && !(bool)CheckBoxIndependant.IsChecked && 
                !(bool)CheckBoxAgenciesOther.IsChecked && !(bool)CheckBoxJP.IsChecked && !(bool)CheckBoxEN.IsChecked &&
                !(bool)CheckBoxID.IsChecked && !(bool)CheckBoxRegionOther.IsChecked)
            {
                retVal = list;
            }
            //no agency but region selected
            if ((!(bool)CheckBoxHoloLive.IsChecked && !(bool)CheckBoxNijisanji.IsChecked && !(bool)CheckBoxIndependant.IsChecked &&
                !(bool)CheckBoxAgenciesOther.IsChecked) &&
                ((bool)CheckBoxJP.IsChecked || (bool)CheckBoxEN.IsChecked || (bool)CheckBoxID.IsChecked || 
                (bool)CheckBoxRegionOther.IsChecked))
            {
                foreach(Channel c in list)
                {
                    switch (c.Region)
                    {
                        case "JP":
                            if ((bool)CheckBoxJP.IsChecked)
                            {
                                retVal.Add(c);
                            }
                            break;
                        case "EN":
                            if ((bool)CheckBoxEN.IsChecked)
                            {
                                retVal.Add(c);
                            }
                            break;
                        case "ID":
                            if ((bool)CheckBoxID.IsChecked)
                            {
                                retVal.Add(c);
                            }
                            break;
                        default:
                            if ((bool)CheckBoxRegionOther.IsChecked)
                            {
                                retVal.Add(c);
                            }
                            break;
                    }
                }
            }
            //Holo
            if((bool)CheckBoxHoloLive.IsChecked)
            {
                foreach (Channel c in list)
                {
                    if (c.Agency.ToLower().Equals("hololive"))
                    {
                        if((bool)CheckBoxJP.IsChecked || (bool)CheckBoxEN.IsChecked || (bool)CheckBoxID.IsChecked ||
                            (bool)CheckBoxRegionOther.IsChecked)
                        {
                            switch (c.Region)
                            {
                                case "JP":
                                    if ((bool)CheckBoxJP.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "EN":
                                    if ((bool)CheckBoxEN.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "ID":
                                    if ((bool)CheckBoxID.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                default:
                                    if ((bool)CheckBoxRegionOther.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            retVal.Add(c);
                        }
                    }
                }
            }
            //Niji
            if ((bool)CheckBoxNijisanji.IsChecked)
            {
                foreach (Channel c in list)
                {
                    if (c.Agency.ToLower().Equals("nijisanji"))
                    {
                        if ((bool)CheckBoxJP.IsChecked || (bool)CheckBoxEN.IsChecked || (bool)CheckBoxID.IsChecked ||
                            (bool)CheckBoxRegionOther.IsChecked)
                        {
                            switch (c.Region)
                            {
                                case "JP":
                                    if ((bool)CheckBoxJP.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "EN":
                                    if ((bool)CheckBoxEN.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "ID":
                                    if ((bool)CheckBoxID.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                default:
                                    if ((bool)CheckBoxRegionOther.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            retVal.Add(c);
                        }
                    }
                }
            }
            //Independant
            if ((bool)CheckBoxIndependant.IsChecked)
            {
                foreach (Channel c in list)
                {
                    if (c.Agency.ToLower().Equals("independant"))
                    {
                        if ((bool)CheckBoxJP.IsChecked || (bool)CheckBoxEN.IsChecked || (bool)CheckBoxID.IsChecked ||
                            (bool)CheckBoxRegionOther.IsChecked)
                        {
                            switch (c.Region)
                            {
                                case "JP":
                                    if ((bool)CheckBoxJP.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "EN":
                                    if ((bool)CheckBoxEN.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "ID":
                                    if ((bool)CheckBoxID.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                default:
                                    if ((bool)CheckBoxRegionOther.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            retVal.Add(c);
                        }
                    }
                }
            }
            //Other
            if ((bool)CheckBoxAgenciesOther.IsChecked)
            {
                foreach (Channel c in list)
                {
                    if (!c.Agency.ToLower().Equals("hololive") && !c.Agency.ToLower().Equals("nijisanji") &&
                        !c.Agency.ToLower().Equals("independant"))
                    {
                        if ((bool)CheckBoxJP.IsChecked || (bool)CheckBoxEN.IsChecked || (bool)CheckBoxID.IsChecked ||
                            (bool)CheckBoxRegionOther.IsChecked)
                        {
                            switch (c.Region)
                            {
                                case "JP":
                                    if ((bool)CheckBoxJP.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "EN":
                                    if ((bool)CheckBoxEN.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                case "ID":
                                    if ((bool)CheckBoxID.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                                default:
                                    if ((bool)CheckBoxRegionOther.IsChecked)
                                    {
                                        retVal.Add(c);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            retVal.Add(c);
                        }
                    }
                }
            }
            return retVal;
        }
        private void ListBoxChannelList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //checks what entry in the channel list was clicked on
                //relies on the toString() method of channel.cs starting with the name and having a '(' afterwards
                string name = ListBoxChannelList.SelectedItem.ToString().Split('(')[0].Trim();
                string URL = channels.Find(x => x.Name.Equals(name)).URL + "/live";
                //opens a channel's livestream link in the system's default browser
                System.Diagnostics.Process.Start(URL);
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to open channel in your browser.";
            }
        }
        private void ButtonAddChannel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEditChannelWindow acw = new AddEditChannelWindow(this, null);
                acw.Show();
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to add channel.";
            }
        }
        public void AddChannel(Channel c)
        {
            channels.Add(c);
            RefreshChannelList(channels);
        }
        public bool NameExistsInList(string name)
        {
            return channels.Any(x => x.Name.Equals(name));
        }
        public bool URLExistsInList(string URL)
        {
            return channels.Any(x => x.URL.Equals(URL));
        }
        private void ButtonRemoveChannel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListBoxChannelList.SelectedItems.Count > 0)
                {
                    //using this method multiple channels can be removed at once
                    foreach (var selected in ListBoxChannelList.SelectedItems)
                    {
                        //relies on the toString() method of channel.cs starting with the name and having a '(' afterwards
                        channels.Remove(channels.Find(x => x.Name.Equals(selected.ToString().Split('(')[0].Trim())));
                    }
                    LabelMessage.Content = "Successfully removed " + ListBoxChannelList.SelectedItems.Count 
                        + " channel(s).";
                    RefreshChannelList(FilterChannelList(channels).OrderByDescending(x => x.Live).ToList());
                }
                else
                {
                    LabelMessage.Content = "Select channel to remove.";
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to remove channel.";
            }
        }
        private void ButtonEditChannel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListBoxChannelList.SelectedItems.Count == 1)
                {
                    Channel c = channels.Find(x =>
                    x.Name.Equals(ListBoxChannelList.SelectedItem.ToString().Split('(')[0].Trim()));
                    channels.Remove(c);
                    //relies on the toString() method of channel.cs starting with the name and having a '(' afterwards
                    AddEditChannelWindow ecw = new AddEditChannelWindow(this, c);
                    ecw.Show();
                }
                else if (ListBoxChannelList.SelectedItems.Count == 0)
                {
                    LabelMessage.Content = "Select channel to edit.";
                }
                else
                {
                    LabelMessage.Content = "You can only edit one channel at a time.";
                }
            }
            catch(Exception)
            {
                LabelMessage.Content = "Error trying to edit channel";
            }
        }
        private void CheckBoxChanged (object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshChannelList(FilterChannelList(channels).OrderByDescending(x => x.Live).ToList());
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to filter channel list.";
            }
        }
    }
}