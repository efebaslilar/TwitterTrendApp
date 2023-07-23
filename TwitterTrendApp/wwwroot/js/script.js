const countrySelection = document.querySelector('.country-selection');
const trendList = document.querySelector('.trend-list');
const hastagList = document.querySelector('#hashtag-list');
//const trendListFragment = document.createDocumentFragment();
//const hastagListFragment = document.createDocumentFragment();
const realtimeTitle = document.querySelector('.realtime-trends .title');
const trendsHeader = document.querySelector('.trends-twitter .header');


countrySelection.addEventListener('change', (event) => {
    const selectedCountry = event.target.value;

    // Başlığı belirli bir formata göre güncelle
    realtimeTitle.textContent = `Realtime ${selectedCountry.charAt(0).toUpperCase() + selectedCountry.slice(1)}`;
    trendsHeader.textContent = `${selectedCountry.charAt(0).toUpperCase() + selectedCountry.slice(1)} Trending`;

    // İstek atmak için gerekli parametreleri ayarla
    const params = new URLSearchParams();
    params.append('Country', selectedCountry);

    // İstek gönder
    fetch('/Country?' + params)
        .then(response => {
            // İstek başarılı olduğunda buraya gelir
            return response.json(); // Yanıtı JSON formatında al
        })
        .then(data => {
            // Yanıtı işle veya kullan
            //trendListFragment.innerHTML = '';
            //hastagListFragment.innerHTML = '';
            let trendcontent='';
            let hastagcontent='';
            for (let i = 0; i < data.length; i++) {
                /*                const deger = data[i + 1] === "0" ? Math.floor(Math.random() * (70 - 10 + 1) + 10).toString() : data[i + 1];*/

            /*    const trendLi = document.createElement('li');*/
                trendcontent += `<li>
                 <div class="card-content">
                     <span class="header"><span class="index">${(i + 1)} · </span>${data[i].hastagName}</span>
                     <span class="info">
                     <span class="tweet-amount">${data[i].quantity}K Tweets</span>
                     <a href="${data[i].hrefurl}">HASHTAG</a>
                   </span>
                 </div></li>`;
              /*  trendListFragment.appendChild(trendLi);*/

                /* <span class="trending-time">Trending since ${data[i].trendingHour} hours ${data[i].trendingMinute} minutes.</span>
                    //<br> */
         /*       const hastagLi = document.createElement('li');*/
                hastagcontent += `<li>
                                      <span class="info">${(i +1)} · Trending</span><br>
                                      <span class="title">${data[i].hastagName}</span><br>
                                      <span class="description">${data[i].quantity}k Tweet</span></li>`;
              /*  hastagListFragment.appendChild(hastagLi);*/
            }

            trendList.innerHTML = trendcontent;
          /*  trendList.appendChild(trendListFragment);*/

            hastagList.innerHTML = hastagcontent;
           /* hastagList.appendChild(hastagListFragment);*/
        })
        .catch(error => {
            // İstek başarısız olduğunda buraya gelir
            console.error('İstek hatası:', error);
        });
});


window.addEventListener('DOMContentLoaded', () => {
    const listItems = document.querySelectorAll('.trend-list li');
    listItems.forEach((item, index) => {
        const indexElement = item.querySelector('.index');
        indexElement.textContent = (index + 1) + ' · ';
    });
});
