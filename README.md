# 3DSnakeGame

2020.3.29f1 ile yapılmıştır. Design pattern olarak ScriptableObject'ler ile Observer Pattern tercih edilmiştir. Oyun landscape modu için tasarlanmıştır. 

Oyunda 9 seviye bulunmaktadır. Her seviyede 15 adet elma toplanması gerekmektedir. Örneğin 7. seviyeyi geçmek için 1. seviyeden itibaren tüm elmaların toplanmış olması ve 7. seviyede de 15 elma toplanması gerekmektedir. Böylece 7x15'ten 105 elma toplanması gerekmektedir. 

Hardcore modda engellere çarpılması halinde oyun tekrar hardcore modda başlar. Ancak normal bölümlerde 1. bölüme geri dönülür. Oyuna başlamdan önce 0.3 saniyelik bir bekleme süresi mevcuttur. 

Skor ana menüye dönüldüğünde sıfırlanır. Her fail durumunda skor kontrol edilir ve ilk 5 highscore arasındaysa kaydedilir. 

Her seviyede yılanın hızı artmaktadır. 

Oyun dosyalarına Assets/ProjectsFolder üzerinden ulaşabilirsiniz. Hemen hemen her class ve etkisi olan fonksiyona summary eklenmiştir.  


