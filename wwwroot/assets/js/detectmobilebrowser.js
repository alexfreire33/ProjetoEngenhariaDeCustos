function detectmob() { 
 if( navigator.userAgent.match(/webOS/i)
 || navigator.userAgent.match(/iPhone/i)
 || navigator.userAgent.match(/iPad/i)
 || navigator.userAgent.match(/iPod/i)
 ){
    
    window.location="https://itunes.apple.com/br/app/convide-e-ganhe/id1394937191?l=en&mt=8";

  }else if(navigator.userAgent.match(/Android/i)){
  	window.location="https://play.google.com/store/apps/details?id=br.Ginside.ConvideeGanhe";

  } else {
    window.location="https://convideeganhe.com.br/";
  }
}