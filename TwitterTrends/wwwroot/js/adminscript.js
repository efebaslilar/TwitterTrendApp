document.getElementById("submit").addEventListener("click", function() {
    var country = document.getElementById("country").value;
    var number = document.getElementById("number").value;
    var name = document.getElementById("textbox1").value;
    var count = document.getElementById("textbox2").value;
    var trendinghour = document.getElementById("textbox3").value;
    var trendingminute = document.getElementById("textbox4").value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/admin/addsettings", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function() {
        if (xhr.readyState === 4 && xhr.status === 200) {
            location.reload(); // Sayfayı yenile
        }
    };

    var params = "country=" + encodeURIComponent(country) + "&number=" + encodeURIComponent(number) + "&name=" + encodeURIComponent(name) + "&count=" + encodeURIComponent(count) + "&trendinghour=" + encodeURIComponent(trendinghour) + "&trendingminute=" + encodeURIComponent(trendingminute);
    xhr.send(params);
});


$(document).ready(function () {
    $('.delete').on('click', function (e) {
        e.preventDefault();

        // Button ID değerini alıyoruz.
        var id = $(this).attr('id');

        // Kullanıcıya onaylama mesajı gösteriyoruz.
        if (confirm('Silmek İstediğinize Emin misiniz?')) {
            // Onay verilirse, Ajax isteğini yaparız.
            $.ajax({
                url: '/admin/delete/' + id, 
                type: 'GET', // İstek türü.
                success: function (response) {
                    
                    location.reload(); // Sayfayı yenileriz.
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    });
});