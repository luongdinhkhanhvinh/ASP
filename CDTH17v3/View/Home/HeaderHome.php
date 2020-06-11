@call JS_Call_When_Onload('SSp.init')
<div id="header-home" class="header-home-abs">

    <!--khung header-top-->
    <div id="header-top" class="header-top-abs">

        <!--logo-->
        <div class="logo" id="header-logo">
        <a href="{{YUH_URI_ROOT}}"><img src="{{YUH_URI_ROOT}}/Resource/img/logo/3.png"></a>
        </div>

        <!--Avatar người dùng và Menu-->
        <div class="header-left" id="header-left">
            @include "../Shared/Headers/User.php"
            @include "../Shared/Headers/Navbar/Index.php"
        </div>

    </div>

    @include "Slides.php"
</div>
