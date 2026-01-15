# TWA OVERLORD - VERİ TOPLAMA KONTROL LİSTESİ

Lütfen aşağıdaki her sayfa için **güncel link** ve **HTML yapısını** kontrol edip bana ver.

---

## ✅ 1. GENEL BAKIŞ (OVERVIEW)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=overview`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] `game_data.village.id` JavaScript objesi var mı?
- [ ] `#wood`, `#stone`, `#iron` elementleri var mı?
- [ ] `#unit_overview_table` tablosu var mı?
- [ ] `strong[data-count='spear']` gibi asker sayıları var mı?

**Lütfen ver:**
```
<table id="header_info" align="center" width="100%" cellspacing="0">
				<colgroup>
					<col width="1%">
					<col width="96%">
					<col width="1%">
					<col width="1%">
					<col width="1%">
				</colgroup>
				<tbody><tr>
					<td class="topAlign">
						<table class="header-border">
	                        <tbody><tr>
	                            <td>
									<table class="box menu nowrap">
	                                    <tbody><tr id="menu_row2">
																																																							<td style="white-space:nowrap;" id="menu_row2_village" class="firstcell box-item icon-box nowrap">
																									<a class="nowrap tooltip-delayed" href="/game.php?village=12218&amp;screen=overview" data-title="Köye Genel Bakış&lt;br/&gt; :: klavye kısayolu: &lt;b&gt;v&lt;/b&gt;"><span class="icon header village"></span>Köy 1</a>
																							</td>
																						<td class="box-item" style="padding-right: 6px"><b class="nowrap">(471|614) K64</b></td>
												                                        <td class="box-item">
	                                        	<script type="text/javascript">
												//<![CDATA[
	                                        		villageDock.saveLink = '/game.php?village=12218&screen=overview&ajaxaction=dockVillagelist&h=58fce238';		                                        	villageDock.loadLink = '/game.php?village=12218&screen=groups&mode=overview&ajax=load_group_menu';
		                                        	villageDock.docked = 0;

													$(function() {
				                                        if(villageDock.docked) {
					                                        villageDock.open();
				                                        }
													});
		                                        //]]>
		                                        </script>
	                                        	<a href="#" id="open_groups" onclick="return villageDock.open(event);"><span class="icon header arr_down"></span></a>
												<a href="#" id="close_groups" onclick="return villageDock.close(event);" style="display: none;"><span class="icon header arr_up"></span></a>
	                                            <input type="hidden" id="popup_close" value="kapat">
	                                            <input type="hidden" value="/game.php?village=12218&amp;screen=groups&amp;ajax=load_villages_from_group&amp;mode=overview" id="show_groups_villages_link">
	                                            <input type="hidden" value="/game.php?screen=overview" id="village_link">
	                                            <input type="hidden" value="overview" id="group_popup_mode">
	                                            <input type="hidden" value="Grup:" id="group_popup_select_title">
	                                            <input type="hidden" value="Köy" id="group_popup_villages_select">
	                                        </td>
												                                    </tr>
	                                </tbody></table>
	                            </td>
	                        </tr>
							<tr class="newStyleOnly">
								<td class="shadow">
									<div class="leftshadow"> </div>
									<div class="rightshadow"> </div>
								</td>
							</tr>
	                    </tbody></table>
                	</td>

				<td align="right" class="topAlign"> </td><!-- flexible gap -->

				<td align="right" class="topAlign">
                    
                </td>

                                <td align="right" class="topAlign">
					<table align="right" class="header-border menu_block_right">
						<tbody><tr>
							<td>
								<table class="box smallPadding" cellspacing="0" style="empty-cells:show;">
									<tbody><tr style="height: 20px;">
										<td class="box-item icon-box firstcell">
											<a href="/game.php?village=12218&amp;screen=wood" data-title="Odun - saatte 199"><span class="icon header wood"> </span></a>
										</td>
                                        <td class="box-item" style="position: relative">
                                        	<span id="wood" class="res" data-title="Odun - saatte 199">337</span>
                                        </td>
                                        <td class="box-item icon-box">
                                        	<a href="/game.php?village=12218&amp;screen=stone" data-title="Kil - saatte 199"><span class="icon header stone"> </span></a>
                                        </td>
                                        <td class="box-item">
                                        	<span id="stone" class="res" data-title="Kil - saatte 199">3847</span>
                                        </td>
                                        <td class="box-item icon-box">
                                        	<a href="/game.php?village=12218&amp;screen=iron" data-title="Demir - saatte 147"><span class="icon header iron"> </span></a>
                                        </td>
										<td class="box-item">
											<span id="iron" class="res" data-title="Demir - saatte 147">1463</span>
										</td>
                                        <td class="box-item icon-box">
                                        	<a href="/game.php?village=12218&amp;screen=storage" data-title="Depo kapasitesi"><span class="icon header ressources"> </span></a>
                                        </td>
                                        <td class="box-item">
                                        	<span id="storage" data-title="Depo kapasitesi">6420</span>
                                        </td>
																					<td class="box-item icon-box"><a href="/game.php?village=12218&amp;screen=farm" data-title="Çiftlik"><span class="icon header population"> </span></a></td>
											<td class="box-item" align="center" style="margin:0;padding:0;" data-title="Çiftlik">
												<span id="pop_current_label" class="">624</span>/<span id="pop_max_label">854</span>
											</td>
										                                    </tr>
								</tbody></table>
							</td>
						</tr>
						<tr class="newStyleOnly">
							<td class="shadow">
								<div class="leftshadow"> </div>
								<div class="rightshadow"> </div>
							</td>
						</tr>
					</tbody></table>
				</td>

                								<td align="right" class="topAlign">
											<table class="header-border menu_block_right" style="border-collapse: collapse;">
							<tbody><tr>
								<td>
									<table class="box" cellspacing="0">
										<tbody><tr>
											<!-- inventory -->
																							<td class="box-item icon-box firstcell" style="white-space:nowrap; text-align:center;">
													<a href="/game.php?village=12218&amp;screen=inventory" style="vertical-align:middle;" data-title="Envanter">
														<span class="icon header inventory" style="margin:0;"></span>
													</a>
												</td>
											
																							<td class="box-item icon-box" style="white-space:nowrap;">
													<a href="/game.php?village=12218&amp;screen=flags" style="vertical-align:middle;" data-title="Bayraklar">
														<span class="icon header flags_new"></span><span>2</span>													</a>
												</td>
																																		<td class="box-item icon-box">
													<a href="/game.php?village=12218&amp;screen=statue" data-title="Şövalye"><span class="icon header knight"></span></a></td>
																																		<td class="box-item icon-box">
													<a href="/game.php?village=12218&amp;screen=relic_system" data-title="Kalıntılar"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/relic_system/relic_icon.webp" class="" data-title=""></a>
												</td>
																																</tr>
									</tbody></table>
								</td>
							</tr>
							<tr class="newStyleOnly">
								<td class="shadow">
									<div class="leftshadow"> </div>
									<div class="rightshadow"> </div>
								</td>
							</tr>
						</tbody></table>
					                </td>

                				<td class="topAlign  " id="header_commands">
					<table class="header-border menu_block_right">
						<tbody><tr>
							<td>
								<table class="box smallPadding no-gap" cellspacing="0">
									<tbody><tr>

										<td id="incomings_cell" style="text-align: center; padding: 0 4px" class="box-item firstcell nowrap">
											<a style="vertical-align: middle" href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;subtype=attacks">											<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/att.webp" style="vertical-align: -2px" class="" data-title="Gelen saldırılar">
											<span id="incomings_amount">0</span>
											</a>										</td>

										<td id="supports_cell" style="text-align: center; padding: 0 4px" class="box-item separate nowrap">
											<a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;subtype=supports">
												<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/support.webp" style="vertical-align: -2px" class="" data-title="Gelen destek">
												<span id="supports_amount">0</span>
											</a>
										</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
						<tr class="newStyleOnly">
							<td class="shadow">
								<div class="leftshadow"> </div>
								<div class="rightshadow"> </div>
							</td>
						</tr>
					</tbody></table>
				</td>
							</tr>
		</tbody></table>
        <table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            
<table cellspacing="0" cellpadding="0" id="overviewtable" class="ui-sortable">
	<tbody><tr>
        <td valign="top" id="leftcolumn">
			<div id="show_summary" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_summary', this );" src="graphic/minus.png">		Köy 1 (411 puan) 
	</h4>
	<div class="widget_content" style="display: block;">
<div class="visual day ">
            <div class="visual-building visual-building-main2"></div>
            <div class="visual-building visual-building-barracks2"></div>
            <div class="visual-building visual-building-stable1"></div>
            <div class="visual-building visual-building-church_f1"></div>
            <div class="visual-building visual-building-smith2"></div>
            <div class="visual-building visual-building-place1"></div>
            <div class="visual-building visual-building-statue1"></div>
            <div class="visual-building visual-building-market2"></div>
            <div class="visual-building visual-building-wood2"></div>
            <div class="visual-building visual-building-stone2"></div>
            <div class="visual-building visual-building-iron2"></div>
            <div class="visual-building visual-building-farm1"></div>
            <div class="visual-building visual-building-storage2"></div>
            <div class="visual-building visual-building-hide1"></div>
            <div class="visual-building visual-building-wall2"></div>
    
            <div class="visual-label visual-label-main tooltip-delayed" data-title="Ana bina">
            <a href="/game.php?village=12218&amp;screen=main">
                10<span class="order-level"></span><br><span class="building-extra"><span class="" data-endtime="1768413217">0:23:13</span></span>
            </a>
        </div>
            <div class="visual-label visual-label-barracks tooltip-delayed" data-title="Kışla">
            <a href="/game.php?village=12218&amp;screen=barracks">
                5<span class="order-level"></span><br><span class="building-extra"><span class="" data-endtime="1768416024">1:10:00</span></span>
            </a>
        </div>
            <div class="visual-label visual-label-stable tooltip-delayed" data-title="Ahır">
            <a href="/game.php?village=12218&amp;screen=stable">
                3<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-church_f tooltip-delayed" data-title="Ana Tapınak">
            <a href="/game.php?village=12218&amp;screen=church_f">
                1<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-smith tooltip-delayed" data-title="Demirci">
            <a href="/game.php?village=12218&amp;screen=smith">
                5<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-place tooltip-delayed" data-title="İçtima Meydanı">
            <a href="/game.php?village=12218&amp;screen=place">
                1<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-statue tooltip-delayed" data-title="Heykel">
            <a href="/game.php?village=12218&amp;screen=statue">
                1<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-market tooltip-delayed" data-title="Pazar">
            <a href="/game.php?village=12218&amp;screen=market">
                5<span class="order-level"></span><br><span class="building-extra">5/5</span>
            </a>
        </div>
            <div class="visual-label visual-label-wood tooltip-delayed" data-title="Oduncu">
            <a href="/game.php?village=12218&amp;screen=wood">
                12<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-stone tooltip-delayed" data-title="Kil ocağı">
            <a href="/game.php?village=12218&amp;screen=stone">
                12<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-iron tooltip-delayed" data-title="Demir madeni">
            <a href="/game.php?village=12218&amp;screen=iron">
                10<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-farm tooltip-delayed" data-title="Çiftlik">
            <a href="/game.php?village=12218&amp;screen=farm">
                9<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-storage tooltip-delayed" data-title="Depo">
            <a href="/game.php?village=12218&amp;screen=storage">
                10<span class="order-level"></span><br><span class="building-extra"><span class="" data-endtime="1768458290">12:54:26</span></span>
            </a>
        </div>
            <div class="visual-label visual-label-hide tooltip-delayed" data-title="Gizli depo">
            <a href="/game.php?village=12218&amp;screen=hide">
                2<span class="order-level"></span>
            </a>
        </div>
            <div class="visual-label visual-label-wall tooltip-delayed" data-title="Sur">
            <a href="/game.php?village=12218&amp;screen=wall">
                7<span class="order-level">+1</span>
            </a>
        </div>
    
    <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/map/empty.webp" usemap="#map" alt="" class="visual-empty">

    <map name="map" id="map">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=main" coords="406,209,449,153,439,97,362,90,340,124,345,173" class="tooltip-delayed" data-building="main" data-title="Ana bina">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=place" coords="349,291,411,295,433,250,408,228,376,229" class="tooltip-delayed" data-building="place" data-title="İçtima Meydanı">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=wood" coords="503,397,553,434,611,391,557,349" class="tooltip-delayed" data-building="wood" data-title="Oduncu">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=stone" coords="73,320,40,367,55,416,106,434,129,419,130,359" class="tooltip-delayed" data-building="stone" data-title="Kil ocağı">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=iron" coords="40,81,84,115,131,84,127,33,78,36" class="tooltip-delayed" data-building="iron" data-title="Demir madeni">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=wall" coords="459,352,461,399,503,381,501,337" class="tooltip-delayed" data-building="wall" data-title="Sur">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=farm" coords="487,27,507,67,555,100,611,113,625,45,625,27" class="tooltip-delayed" data-building="farm" data-title="Çiftlik">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=hide" coords="276,105,296,137,328,118,303,88" class="tooltip-delayed" data-building="hide" data-title="Gizli depo">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=church_f" coords="442,220,465,238,530,215,525,159,470,124,442,184" class="tooltip-delayed" data-building="church_f" data-title="Ana Tapınak">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=storage" coords="134,214,190,240,231,237,229,171,170,145" class="tooltip-delayed" data-building="storage" data-title="Depo">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=market" coords="250,172,269,249,347,251,363,192,308,146" class="tooltip-delayed" data-building="market" data-title="Pazar">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=barracks" coords="424,309,475,332,520,303,511,256,473,238,424,273" class="tooltip-delayed" data-building="barracks" data-title="Kışla">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=stable" coords="103,262,109,285,187,326,225,309,220,253,137,224" class="tooltip-delayed" data-building="stable" data-title="Ahır">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=smith" coords="211,354,258,379,306,360,317,320,252,282" class="tooltip-delayed" data-building="smith" data-title="Demirci">
                    <area shape="poly" href="/game.php?village=12218&amp;screen=statue" coords="311,252,291,285,301,305,326,307,340,286" class="tooltip-delayed" data-building="statue" data-title="Heykel">
            </map>
<canvas class="visual-anim anim-building-main-2" width="31" height="20"></canvas><canvas class="visual-anim anim-building-wood-prod" width="26" height="24"></canvas><canvas class="visual-anim anim-building-stone-prod" width="33" height="23"></canvas><canvas class="visual-anim anim-building-iron-prod" width="30" height="28"></canvas><canvas class="visual-anim anim-building-farm-prod" width="35" height="28"></canvas><canvas class="visual-anim anim-building-main-prod" width="36" height="29"></canvas><canvas class="visual-anim anim-building-barracks-prod" width="48" height="39"></canvas></div>

<script>
    $(function () {
        new Visual(["anim-building-main-2","anim-building-wood-prod","anim-building-stone-prod","anim-building-iron-prod","anim-building-farm-prod","anim-building-main-prod","anim-building-barracks-prod"], "day");
    });
</script>
</div>
</div><div id="show_event" class="vis moveable hidden_widget" style="display: none;">
	<h4 class="ui-sortable-handle">Olay</h4>
</div><div id="show_incoming_units" class="vis moveable hidden_widget" style="display: none;">
	<h4 class="ui-sortable-handle">Gelen birlikler</h4>
</div><div id="show_outgoing_units" class="vis moveable hidden_widget" style="display: none;">
	<h4 class="ui-sortable-handle">Birliklerin</h4>
</div>
        </td>
        <td valign="top" id="rightcolumn">
			<div id="show_newbie" class="vis moveable hidden_widget" style="display: none;">
	<h4 class="ui-sortable-handle">Çaylak koruması</h4>
</div><div id="show_prod" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_prod', this );" src="graphic/minus.png">		Üretim
	</h4>
	<div class="widget_content" style="display: block;"><table width="100%">
			<tbody><tr class="nowrap">
			<td width="70">
								<a href="/game.php?village=12218&amp;screen=wood"><span class="icon wood-bonus" data-title="41 oranında arttırıldı"> </span></a> Odun
							</td>
			<td>
				<strong> 199</strong> saat başına
							</td>
		</tr>
			<tr class="nowrap">
			<td width="70">
								<a href="/game.php?village=12218&amp;screen=stone"><span class="icon stone-bonus" data-title="41 oranında arttırıldı"> </span></a> Kil
							</td>
			<td>
				<strong> 199</strong> saat başına
							</td>
		</tr>
			<tr class="nowrap">
			<td width="70">
								<a href="/game.php?village=12218&amp;screen=iron"><span class="icon iron-bonus" data-title="30 oranında arttırıldı"> </span></a> Demir
							</td>
			<td>
				<strong> 147</strong> saat başına
							</td>
		</tr>
	</tbody></table>
</div>
</div><div id="show_buildqueue" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_buildqueue', this );" src="graphic/minus.png">		İnşa kuyruğu
	</h4>
	<div class="widget_content" style="display: block;"><table width="100%" id="overview_buildqueue" class="vis">
	<tbody>
								<tr class="queueRow" style="height:50px">
				<td width="40px" align="center"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/wall2.webp" width="40" class="" data-title=""></td>
				<td>Sur<br>
											<span class="small">0:23:14</span>
									</td>
				<td align="center">
					<a style="vertical-align:middle; margin:5px;" class="cancel-icon solo evt-confirm" data-confirm-msg="Bu görevi inşaat sırandan çıkarmak istediğinden emin misin?" href="/game.php?village=12218&amp;screen=overview&amp;action=cancelBuild&amp;id=698485&amp;h=58fce238"></a>

																		<a class="order_feature coinbag solo" onclick="return VillageOverview.change_order('/game.php?village=12218&amp;screen=overview&amp;action=change_order&amp;id=698485&amp;h=58fce238', 'BuildTimeReduction', 10)" href="#" data-available-from="0" data-available-to="1768412617" data-title="Kalan yapım süresini 50% azaltır.&lt;br /&gt;&lt;br /&gt;&lt;strong&gt;Masraf: &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot; title=&quot;Premium Puan&quot;&gt; &lt;/span&gt;10" style="">
							</a>
													<a class="order_feature coinbag solo" onclick="return VillageOverview.change_order('/game.php?village=12218&amp;screen=overview&amp;action=change_order&amp;id=698485&amp;h=58fce238', 'BuildInstant', 10)" href="#" data-available-from="1768412617" data-available-to="1768413037" style="display: none" data-title="İnşaatı anında tamamlar.&lt;br /&gt;&lt;br /&gt;&lt;strong&gt;Masraf: &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot; title=&quot;Premium Puan&quot;&gt; &lt;/span&gt;10&lt;br /&gt;&lt;span class=&quot;green&quot;&gt;0:03:00 varken ücretsiz.&lt;/span&gt;">
							</a>
													<a class="order_feature coinbag-free" onclick="return VillageOverview.change_order('/game.php?village=12218&amp;screen=overview&amp;action=change_order&amp;id=698485&amp;h=58fce238', 'BuildInstantFree', 0)" href="#" data-available-from="1768413037" data-available-to="1768413217" style="display: none" data-title="İnşaatı anında ücretsiz tamamlar.">
							</a>
															</td>
			</tr>
			</tbody>
</table></div>
</div><div id="show_units" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_units', this );" src="graphic/minus.png">		Birimler
	</h4>
	<div class="widget_content" style="display: block;"><table id="unit_overview_table" class="vis bordered-table" width="100%" style="vertical-align: middle;">
    <thead>
        <tr style="border-bottom-width: 1px">
            <td>
                                    <div style="width: 15%; float: left;">
                        <a class="units-widget-prev" data-direction="-1"><div class="widget-arrow arrowLeft"> </div></a>
                    </div>
                    <div style="line-height: 22px; height: 22px; width: 70%; float: left;text-align: center;overflow: hidden; white-space: nowrap; -ms-text-overflow: ellipsis;text-overflow: ellipsis;">
                        <strong class="units-widget-group" style="color: #603000">Hepsi</strong>
                    </div>
                    <div style="width: 15%; float: right;text-align: right">
                        <a class="units-widget-next" data-direction="1"><div class="widget-arrow arrowRight"> </div></a>
                    </div>
                            </td>
        </tr>
    </thead>
    <tbody>
                                                    <tr class="all_unit">
                    <td>
                                         <a href="#" class="unit_link" data-unit="spear"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp" class="" data-title=""> </a>
                 <strong data-count="spear">230</strong> Mızrakçı
                                                </td>
                </tr>
                                                                                    <tr class="all_unit">
                    <td>
                                         <a href="#" class="unit_link" data-unit="sword"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp" class="" data-title=""> </a>
                 <strong data-count="sword">98</strong> Kılıç ustası
                                                </td>
                </tr>
                                                                                    <tr class="all_unit">
                    <td>
                                         <a href="#" class="unit_link" data-unit="axe"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp" class="" data-title=""> </a>
                 <strong data-count="axe">2</strong> Baltacı
                                                </td>
                </tr>
                                                                                    <tr class="all_unit">
                    <td>
                                         <a href="#" class="unit_link" data-unit="spy"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spy.webp" class="" data-title=""> </a>
                 <strong data-count="spy">10</strong> Casus
                                                </td>
                </tr>
                                                                                            <tr class="all_unit">
                        <td>
                                                    <a href="#" class="unit_link" data-unit="knight"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_knight.webp" class="" data-title=""> </a>
                        <strong data-count="knight">1</strong> Şövalye
                                                        </td>
                    </tr>
                                                                                            <tr class="home_unit hide_toggle">
                    <td>
                                         <a href="#" class="unit_link" data-unit="spear"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp" class="" data-title=""> </a>
                 <strong data-count="spear">230</strong> Mızrakçı
                                            </td>
                </tr>
                                                                                    <tr class="home_unit hide_toggle">
                    <td>
                                         <a href="#" class="unit_link" data-unit="sword"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp" class="" data-title=""> </a>
                 <strong data-count="sword">98</strong> Kılıç ustası
                                            </td>
                </tr>
                                                                                    <tr class="home_unit hide_toggle">
                    <td>
                                         <a href="#" class="unit_link" data-unit="axe"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp" class="" data-title=""> </a>
                 <strong data-count="axe">2</strong> Baltacı
                                            </td>
                </tr>
                                                                                    <tr class="home_unit hide_toggle">
                    <td>
                                         <a href="#" class="unit_link" data-unit="spy"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spy.webp" class="" data-title=""> </a>
                 <strong data-count="spy">10</strong> Casus
                                            </td>
                </tr>
                                                                                                                                                                                                                                                                                                                                                 <tr class="home_unit hide_toggle">
                        <td>
                                                    <a href="#" class="unit_link" data-unit="knight"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_knight.webp" class="" data-title=""> </a>
                        <strong data-count="knight">1</strong> Şövalye
                                                    </td>
                    </tr>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    </tbody>
    <tfoot>
            <tr>
            <td><a href="/game.php?village=12218&amp;screen=train">» asker topla</a></td>
        </tr>
        </tfoot>
</table>
<script>
    VillageOverview.units[0] = {"spear":{"id":"spear","image":"unit\/unit_spear.png","type":"infantry","prod_building":"barracks","build_time":1020,"wood":50,"stone":30,"iron":10,"pop":1,"speed":0.000925925925925926,"attack":10,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":15,"defense_cavalry":45,"defense_archer":20,"carry":25,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":4,"defpoints":1,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"M\u0131zrak\u00e7\u0131","shortname":"M\u0131zrak","desc":"M\u0131zrak\u00e7\u0131 en basit birimdir. Atl\u0131lara kar\u015f\u0131 savunma yaparken ve di\u011fer k\u00f6yleri ya\u011fmalarken \u00e7ok etkilidir.","desc_abilities":[]},"sword":{"id":"sword","image":"unit\/unit_sword.png","type":"infantry","prod_building":"barracks","build_time":1500,"wood":30,"stone":30,"iron":70,"pop":1,"speed":0.0007575757575757576,"attack":25,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":50,"defense_cavalry":25,"defense_archer":40,"carry":15,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":5,"defpoints":2,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"K\u0131l\u0131\u00e7 ustas\u0131","shortname":"K\u0131l\u0131\u00e7","desc":"K\u0131l\u0131\u00e7 ustalar\u0131, yava\u015f olmakla birlikte savunmada \u00f6zellikle de piyadelere kar\u015f\u0131 savunma yaparken \u00e7ok etkilidirler. ","desc_abilities":[]},"axe":{"id":"axe","image":"unit\/unit_axe.png","type":"infantry","prod_building":"barracks","build_time":1320,"wood":60,"stone":30,"iron":40,"pop":1,"speed":0.000925925925925926,"attack":40,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":10,"defense_cavalry":5,"defense_archer":10,"carry":10,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":1,"defpoints":4,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"Baltac\u0131","shortname":"Balta","desc":"Baltac\u0131, g\u00fc\u00e7l\u00fc bir sald\u0131r\u0131 birimidir ancak savunmada neredeyse i\u015fe yaramazlar.","desc_abilities":[]},"spy":{"id":"spy","image":"unit\/unit_spy.png","type":"other","prod_building":"stable","build_time":900,"wood":50,"stone":50,"iron":20,"pop":2,"speed":0.001851851851851852,"attack":0,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":2,"defense_cavalry":1,"defense_archer":2,"carry":0,"stealth":1,"perception":1,"can_attack":true,"can_support":true,"attackpoints":1,"defpoints":2,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"Casus","shortname":"Casus","desc":"Casuslar, fark edilmeden d\u00fc\u015fman k\u00f6ylerine s\u0131z\u0131p bilgi toplar.","desc_abilities":["Sald\u0131r\u0131rken sadece di\u011fer casuslar taraf\u0131ndan yakalanabilir.","Sald\u0131r\u0131dan sonra sava\u015f raporunda daha fazla bilgi g\u00f6sterir."]},"knight":{"id":"knight","image":"unit\/unit_knight.png","type":"cavalry","prod_building":"statue","build_time":21600,"wood":20,"stone":20,"iron":40,"pop":10,"speed":0.0016666666666666666,"attack":150,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":250,"defense_cavalry":400,"defense_archer":150,"carry":100,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":40,"defpoints":20,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"\u015e\u00f6valye","shortname":"\u015e\u00f6valye","desc":"\u015e\u00f6valye heykelde \u00fcretilebilen g\u00fc\u00e7l\u00fc ve e\u015fsiz bir birimdir. Ayr\u0131ca destek g\u00f6nderirken birimlerin h\u0131z\u0131n\u0131 art\u0131rabilir.","desc_abilities":["\u015e\u00f6valye ile deste\u011fe giden birimler onun h\u0131z\u0131yla giderler."]}};
    VillageOverview.units[1] = {"spear":{"id":"spear","image":"unit\/unit_spear.png","type":"infantry","prod_building":"barracks","build_time":1020,"wood":50,"stone":30,"iron":10,"pop":1,"speed":0.000925925925925926,"attack":10,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":15,"defense_cavalry":45,"defense_archer":20,"carry":25,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":4,"defpoints":1,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"M\u0131zrak\u00e7\u0131","shortname":"M\u0131zrak","desc":"M\u0131zrak\u00e7\u0131 en basit birimdir. Atl\u0131lara kar\u015f\u0131 savunma yaparken ve di\u011fer k\u00f6yleri ya\u011fmalarken \u00e7ok etkilidir.","desc_abilities":[]},"sword":{"id":"sword","image":"unit\/unit_sword.png","type":"infantry","prod_building":"barracks","build_time":1500,"wood":30,"stone":30,"iron":70,"pop":1,"speed":0.0007575757575757576,"attack":25,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":50,"defense_cavalry":25,"defense_archer":40,"carry":15,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":5,"defpoints":2,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"K\u0131l\u0131\u00e7 ustas\u0131","shortname":"K\u0131l\u0131\u00e7","desc":"K\u0131l\u0131\u00e7 ustalar\u0131, yava\u015f olmakla birlikte savunmada \u00f6zellikle de piyadelere kar\u015f\u0131 savunma yaparken \u00e7ok etkilidirler. ","desc_abilities":[]},"axe":{"id":"axe","image":"unit\/unit_axe.png","type":"infantry","prod_building":"barracks","build_time":1320,"wood":60,"stone":30,"iron":40,"pop":1,"speed":0.000925925925925926,"attack":40,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":10,"defense_cavalry":5,"defense_archer":10,"carry":10,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":1,"defpoints":4,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"Baltac\u0131","shortname":"Balta","desc":"Baltac\u0131, g\u00fc\u00e7l\u00fc bir sald\u0131r\u0131 birimidir ancak savunmada neredeyse i\u015fe yaramazlar.","desc_abilities":[]},"spy":{"id":"spy","image":"unit\/unit_spy.png","type":"other","prod_building":"stable","build_time":900,"wood":50,"stone":50,"iron":20,"pop":2,"speed":0.001851851851851852,"attack":0,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":2,"defense_cavalry":1,"defense_archer":2,"carry":0,"stealth":1,"perception":1,"can_attack":true,"can_support":true,"attackpoints":1,"defpoints":2,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"Casus","shortname":"Casus","desc":"Casuslar, fark edilmeden d\u00fc\u015fman k\u00f6ylerine s\u0131z\u0131p bilgi toplar.","desc_abilities":["Sald\u0131r\u0131rken sadece di\u011fer casuslar taraf\u0131ndan yakalanabilir.","Sald\u0131r\u0131dan sonra sava\u015f raporunda daha fazla bilgi g\u00f6sterir."]},"light":"0","heavy":"0","ram":"0","catapult":"0","knight":{"id":"knight","image":"unit\/unit_knight.png","type":"cavalry","prod_building":"statue","build_time":21600,"wood":20,"stone":20,"iron":40,"pop":10,"speed":0.0016666666666666666,"attack":150,"building_attack_multiplier":null,"additional_max_wall_negation":null,"defense":250,"defense_cavalry":400,"defense_archer":150,"carry":100,"stealth":0,"perception":0,"can_attack":true,"can_support":true,"attackpoints":40,"defpoints":20,"cost_modifier":1,"build_req_detail":null,"tech_levels":null,"tech_costs":null,"available":null,"error":null,"forecast":null,"all_count":null,"order":null,"max":null,"name":"\u015e\u00f6valye","shortname":"\u015e\u00f6valye","desc":"\u015e\u00f6valye heykelde \u00fcretilebilen g\u00fc\u00e7l\u00fc ve e\u015fsiz bir birimdir. Ayr\u0131ca destek g\u00f6nderirken birimlerin h\u0131z\u0131n\u0131 art\u0131rabilir.","desc_abilities":["\u015e\u00f6valye ile deste\u011fe giden birimler onun h\u0131z\u0131yla giderler."]},"snob":"0","militia":"0"};
    VillageOverview.units[2] = {"spear":null,"sword":null,"axe":null,"spy":null,"light":null,"heavy":null,"ram":null,"catapult":null,"knight":null,"snob":null,"militia":null};
</script></div>
</div><div id="show_mood" class="vis moveable hidden_widget" style="display: none;">
	<h4 class="ui-sortable-handle">Sadakat <span class="icon info-small" data-title="Misyoner içeren saldırı bu köyün sadakatini düşürdü. Eğer sadakat 0'a düşerse, o şehri ele geçirebilirsin!"><span></span></span></h4>
</div><div id="show_effects" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_effects', this );" src="graphic/minus.png">		Aktif etkiler
	</h4>
	<div class="widget_content" style="display: block;"><table style="width: 100%">
                <tbody><tr>
                                <td class="village_overview_effect effect_tooltip" data-title="
                            &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/church.webp&quot;&gt;İnançlı&lt;/h3&gt;
                             :: &lt;i&gt;Bu köy tapınaklarından en az birinin tesiri altında.&lt;/i&gt;                            
                                &lt;ul style=&quot;padding-left:15px;&quot;&gt;
                                                                            &lt;li&gt;Sadakatsizlik için ceza yok&lt;/li&gt;
                                                                    &lt;/ul&gt;
                                                    ">
                                            <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/church.webp" alt="" style="vertical-align: middle">
                    İnançlı                </td>
            </tr>
                        <!-- relic -->
                <tr>
                    <td class="effect_tooltip village_overview_effect relic-quality-shoddy" data-title="
                    &lt;h3&gt;&lt;img class=&quot;relic-icon-small&quot; src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/relic_system/relics_46/greataxe_shoddy.webp&quot;&gt; Kalitesiz Çift El Balta&lt;/h3&gt;
                        :: &lt;ul&gt;&lt;li&gt;Baltacı: +2% saldırı ve savunma gücü&lt;/li&gt;&lt;li&gt;Mızrakçı: +1% saldırı ve savunma gücü&lt;/li&gt;&lt;li&gt;Ağır atlı: +1% saldırı ve savunma gücü&lt;/li&gt;&lt;/ul&gt;&lt;p&gt;Konum: &lt;span class=&quot;village_anchor&quot; data-player=&quot;849071243&quot; data-id=&quot;12218&quot;&gt;&lt;a href=&quot;/game.php?village=12218&amp;amp;screen=info_village&amp;amp;id=12218&quot; &gt;Köy 1 (471|614) K64&lt;/a&gt;&lt;/span&gt;&lt;/p&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/relic_system/relics_46/greataxe_shoddy.webp" alt="Kalitesiz Çift El Balta">
                        <a href="/game.php?village=12218&amp;screen=relic_system">Kalitesiz Çift El Balta</a>
                    </td>
                </tr>
                        <tr>
                                <td class="village_overview_effect ">
                                            <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/flags/small/2.webp" alt="" style="vertical-align: middle">
                                            <a href="/game.php?village=12218&amp;screen=flags">+6% hammadde</a>
                                    </td>
            </tr>
                        <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp&quot;&gt; Baltacı: +2% saldırı ve savunma gücü&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li class=''&gt;&lt;b&gt;+2%&lt;/b&gt; Kalitesiz Çift El Balta'den&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp" alt="">
                        Baltacı: +2% saldırı ve savunma gücü                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
                            <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp&quot;&gt; Mızrakçı: +1% saldırı ve savunma gücü&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li class=''&gt;&lt;b&gt;+1%&lt;/b&gt; Kalitesiz Çift El Balta'den&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp" alt="">
                        Mızrakçı: +1% saldırı ve savunma gücü                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
                            <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_heavy.webp&quot;&gt; Ağır atlı: +1% saldırı ve savunma gücü&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li class=''&gt;&lt;b&gt;+1%&lt;/b&gt; Kalitesiz Çift El Balta'den&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_heavy.webp" alt="">
                        Ağır atlı: +1% saldırı ve savunma gücü                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
                            <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/holz.webp&quot;&gt; +20% odun üretimi&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li&gt;&lt;b&gt;+20%&lt;/b&gt; eşya’den son kullanım 11.02.'de 11:45'de&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/holz.webp" alt="">
                        +20% odun üretimi                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
                            <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/lehm.webp&quot;&gt; +20% kil üretimi&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li&gt;&lt;b&gt;+20%&lt;/b&gt; eşya’den son kullanım 11.02.'de 11:45'de&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/lehm.webp" alt="">
                        +20% kil üretimi                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
                            <!-- benefit -->
                                <tr>
                    <td class="effect_tooltip village_overview_effect" data-title="
                        &lt;h3&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/eisen.webp&quot;&gt; +20% demir üretimi&lt;/h3&gt;
                        :: &lt;i&gt;&lt;/i&gt;

                        &lt;ul&gt;
                        &lt;li&gt;&lt;b&gt;+20%&lt;/b&gt; eşya’den son kullanım 11.02.'de 11:45'de&lt;/li&gt;
                &lt;/ul&gt;                    ">
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/eisen.webp" alt="">
                        +20% demir üretimi                        <!-- Mobile tooltip icon -->
                                            </td>
                </tr>
            </tbody></table>
</div>
</div><div id="show_groups" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_groups', this );" src="graphic/minus.png">		Grup üyeliği
	</h4>
	<div class="widget_content" style="display: block;"><!-- groups that can't be manually set (they are controlled by filters) -->
<table class="vis" width="100%">
    </table>
<input type="hidden" value="0" id="village_has_dynamic_membership">

<!-- groups that CAN be manually set-->
<input type="hidden" value="Grupları oluştur" id="group_submit_text">
<input type="hidden" value="Grup üyeliği" id="group_headline">
<input type="hidden" value="/game.php?village=12218&amp;screen=groups&amp;ajaxaction=village&amp;h=58fce238" id="group_assign_action">
<input type="hidden" value="» Düzenle" id="group_edit_village">

<div id="error_div"></div>
<div id="group_assignment"><table id="group_table" width="100%" class="vis"><tbody></tbody></table><table width="100%" class="vis" style="margin-top: -2px;"><tbody><tr><td><i>yok</i></td></tr></tbody></table></div>


<script type="text/javascript">
VillageGroups.showGroups({"result":[],"village_id":12218,"group_id":"0","player_has_static_groups":false}, 'group_assignment', false, function(){ VillageOverview.refreshAMSettingsWidget() });
</script>
</div>
</div><div id="show_notes" class="vis moveable widget ">
	<h4 class="head with-button ui-sortable-handle">
		<img class="widget-button" onclick="return VillageOverview.toggleWidget( 'show_notes', this );" src="graphic/minus.png">		Not defteri
	</h4>
	<div class="widget_content" style="display: block;"><script>
    (function() {
        VillageOverview.show_notes = true;
    })();
</script>

<table width="100%">
	<tbody><tr style="display:none" id="village_note">
		<td><div class="village-note" style="display:none;">
    <div class="village-note-head">
        <div class="village-note-time"></div>
        <span class="village-note-time"></span>
        <span class="float_right village-note-delete" data-title="Notu sil"></span>
    </div>
    <div class="village-note-body">
            </div>
</div></td>
	</tr>
    <tr><td><a id="edit_notes_link" href="#">» Düzenle</a></td></tr>
</tbody></table>
</div>
</div>
		</td>
	</tr>
</tbody></table>


<style type="text/css">
	.placeholder {
		height: 20px;
	}

	.moveable h4 {
		cursor:move;
	}
</style>

<script type="text/javascript">
//<![CDATA[
$( function() {
	VillageOverview.urls.reorder = '/game.php?village=12218&screen=overview&ajaxaction=reorder&h=58fce238';
	VillageOverview.urls.toggle = '/game.php?village=12218&screen=overview&ajaxaction=toggle&h=58fce238';
	VillageOverview.unit_groups = ["Hepsi","Kendine ait","Di\u011fer"];
	VillageOverview.unit_group_selected = 0;
	VillageOverview.init();

	});
//]]>
</script>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>
```

---

## ✅ 2. İÇTİMA MEYDANI (PLACE)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=place`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] `input[name='spear']` elementleri var mı?
- [ ] `data-all-count` attribute'u var mı?
- [ ] Asker sayıları doğru gösteriliyor mu?

**Lütfen ver:**
```
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/place1.webp" class="" data-title="İçtima Meydanı"></td>
		<td valign="top" width="100%">
			<h2>İçtima Meydanı (seviye 1)</h2>
			İçtima meydanında savaşçıların toplanır. Bu merkezde saldırı emirlerini verebilir ve birliklerini kaydırabilirsin.
		</td>
	</tr>
</tbody></table>

<table class="vis modemenu">
	<tbody><tr>
		<td class="selected" style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=command">Komutlar </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=units">Birlikler </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=scavenge">Temizlik </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=scavenge_mass">Toplu Temizlik </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=sim">Simülatör </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=neighbor">Yakındaki köyler </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=call">Toplu destek </a></td>
		<td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=place&amp;mode=templates">Birlik şablonları </a></td>
		</tr>
</tbody></table>

<h3>Komut ver</h3>

<div id="command-form-warning"></div>
    <script type="text/javascript">
        // this will be attached to the target widget
        var onCommandTargetChoice = function(village) {
            $('#command_actions .btn').eq(0).focus(); //this references the attack/support button container, which is separate from the target selection.

            // Handle special village data such as for event village
            // disabled support
            if (village.hasOwnProperty('disallow_support')) {
                $('#target_support').attr('disabled', 'disabled');
            }
            else {
                $('#target_support').removeAttr('disabled');
            }

            // disabled units
            $('.unitsInput').removeAttr('disabled');
            if (village.hasOwnProperty('disallow_units')) {
                $.each(village.disallow_units, function (k, unit_id) {
                    $('#unit_input_' + unit_id).attr('disabled', 'disabled');
                });
            }

            // warning message
            if (village.hasOwnProperty('warning')) {
                $('#command-form-warning').html('<p>' + village.warning + '</p>');
            }
            else {
                $('#command-form-warning').text('');
            }
        };

        $(function() {
            TroopTemplates.current = [];
            $(".evt-select-template").change(function() { TroopTemplates.useTemplate(this); });

            var selectAllState = false;
            $("#selectAllUnits").click(function(event) {
                selectAllState = !selectAllState;
                selectAllUnits(selectAllState);
                TroopTemplates.resetSelect($('.evt-select-template'));
                event.preventDefault();
            });

            var target_widget = new TargetSelection($('#command_target')[0]);
            target_widget.initScriptCompatibility();

            
                        target_widget.setLastAttacked({"id":"12012","x":"473","y":"611","name":"Barbar K\u00f6y\u00fc","player_id":"0","bonus_id":null,"tile_id":null,"village_type":"standard","player_name":null,"points":"52","distance":"13","event_special":"0","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/map\/icon\/v1_left_icon.webp"});
            
            
            if (typeof CommandPopup !== 'undefined') {
                CommandPopup.target_widget = target_widget;
            }

            Place.commandScreen.init();
        });
    </script>

    <form id="command-data-form" name="units" action="/game.php?village=12218&amp;screen=place&amp;try=confirm" method="post" class="float_left">
        <input type="hidden" name="bcf310444495b32bf11652" value="508a9650bcf310">
        <input type="hidden" id="template_id" name="template_id" value="">
        <input type="hidden" name="source_village" value="12218">

        
        <table>
            <tbody><tr><td valign="top"><table class="vis" width="100%"><tbody><tr><th>Piyade</th></tr><tr><td class="nowrap "><a href="#" class="unit_link" data-unit="spear"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp" class="" data-title="Mızrakçı"></a> <input id="unit_input_spear" name="spear" type="text" tabindex="1" value="" class="unitsInput" data-all-count="230"> <a href="#" class="units-entry-all" data-unit="spear" id="units_entry_all_spear">(230)</a>
</td></tr><tr><td class="nowrap "><a href="#" class="unit_link" data-unit="sword"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp" class="" data-title="Kılıç ustası"></a> <input id="unit_input_sword" name="sword" type="text" tabindex="2" value="" class="unitsInput" data-all-count="98"> <a href="#" class="units-entry-all" data-unit="sword" id="units_entry_all_sword">(98)</a>
</td></tr><tr><td class="nowrap "><a href="#" class="unit_link" data-unit="axe"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp" class="" data-title="Baltacı"></a> <input id="unit_input_axe" name="axe" type="text" tabindex="3" value="" class="unitsInput" data-all-count="2"> <a href="#" class="units-entry-all" data-unit="axe" id="units_entry_all_axe">(2)</a>
</td></tr></tbody></table></td>
<td valign="top"><table class="vis" width="100%"><tbody><tr><th>Atlılar</th></tr><tr><td class="nowrap "><a href="#" class="unit_link" data-unit="spy"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spy.webp" class="" data-title="Casus"></a> <input id="unit_input_spy" name="spy" type="text" tabindex="4" value="" class="unitsInput" data-all-count="10"> <a href="#" class="units-entry-all" data-unit="spy" id="units_entry_all_spy">(10)</a>
</td></tr><tr><td class="nowrap unit-input-faded"><a href="#" class="unit_link" data-unit="light"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_light.webp" class="" data-title="Hafif atlı"></a> <input id="unit_input_light" name="light" type="text" tabindex="5" value="" class="unitsInput" data-all-count="0"> <a href="#" class="units-entry-all" data-unit="light" id="units_entry_all_light">(0)</a>
</td></tr><tr><td class="nowrap unit-input-faded"><a href="#" class="unit_link" data-unit="heavy"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_heavy.webp" class="" data-title="Ağır atlı"></a> <input id="unit_input_heavy" name="heavy" type="text" tabindex="6" value="" class="unitsInput" data-all-count="0"> <a href="#" class="units-entry-all" data-unit="heavy" id="units_entry_all_heavy">(0)</a>
</td></tr></tbody></table></td>
<td valign="top"><table class="vis" width="100%"><tbody><tr><th>Kuşatma silahları</th></tr><tr><td class="nowrap unit-input-faded"><a href="#" class="unit_link" data-unit="ram"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_ram.webp" class="" data-title="Koçbaşı"></a> <input id="unit_input_ram" name="ram" type="text" tabindex="7" value="" class="unitsInput" data-all-count="0"> <a href="#" class="units-entry-all" data-unit="ram" id="units_entry_all_ram">(0)</a>
</td></tr><tr><td class="nowrap unit-input-faded"><a href="#" class="unit_link" data-unit="catapult"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_catapult.webp" class="" data-title="Mancınık"></a> <input id="unit_input_catapult" name="catapult" type="text" tabindex="8" value="" class="unitsInput" data-all-count="0"> <a href="#" class="units-entry-all" data-unit="catapult" id="units_entry_all_catapult">(0)</a>
</td></tr></tbody></table></td>
<td valign="top"><table class="vis" width="100%"><tbody><tr><th>Diğer</th></tr><tr><td class="nowrap "><a href="#" class="unit_link" data-unit="knight"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_knight.webp" class="" data-title="Şövalye"></a> <input id="unit_input_knight" name="knight" type="text" tabindex="9" value="" class="unitsInput" data-all-count="1"> <a href="#" class="units-entry-all" data-unit="knight" id="units_entry_all_knight">(1)</a>
</td></tr><tr><td class="nowrap unit-input-faded"><a href="#" class="unit_link" data-unit="snob"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_snob.webp" class="" data-title="Misyoner"></a> <input id="unit_input_snob" name="snob" type="text" tabindex="10" value="" class="unitsInput" data-all-count="0"> <a href="#" class="units-entry-all" data-unit="snob" id="units_entry_all_snob">(0)</a>
</td></tr></tbody></table></td>

        </tr></tbody></table>

        
        <input type="text" name="x" id="inputx" value="" style="display: none">
        <input type="text" name="y" id="inputy" value="" style="display: none">

        <br>

                    <div id="command_target" class="target-select clearfix vis float_left" data-on-choice="onCommandTargetChoice">
                <h4>Hedef:</h4>

                <table class="vis" style="width: 100%">
                    <tbody><tr>
                        <td>
                            <div class="target-types">
                                <label><input type="radio" name="target_type" value="coord" checked="checked"> Koordinat</label>
                                <label><input type="radio" name="target_type" value="village_name"> Köy adı</label>
                                <label><input type="radio" name="target_type" value="player_name"> Oyuncu İsmi</label>
                            </div>

                            <div id="place_target" class="target-input float_left">
                                <input type="text" name="input" class="target-input-field target-input-autocomplete ui-autocomplete-input" data-type="player" value="" autocomplete="off" tabindex="14" data-ignore-single-exact-match="1" placeholder="123|456">
                            </div>
                            <a href="#" class="target-quickbutton target-last-attacked" data-title="Önceki" style="display: inline;"></a>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="target-select-links">
                                                                    <a href="#" onclick="TargetSelection.loadTargetsPopup(event, '/game.php?village=12218&amp;screen=targets&amp;ajax=bookmark&amp;building=place&amp;prefix=&amp;');">» Favoriler</a>
                                                                    <a href="#" onclick="TargetSelection.loadTargetsPopup(event, '/game.php?village=12218&amp;screen=targets&amp;ajax=recent&amp;building=place&amp;prefix=&amp;');">» Olay akışı</a>
                                                                    <a href="#" onclick="TargetSelection.loadTargetsPopup(event, '/game.php?village=12218&amp;screen=targets&amp;ajax=claimed&amp;building=place&amp;prefix=&amp;');">» Rezerve edildi</a>
                                                                                                    <span></span>
                                                                    <span></span>
                                                                    <span></span>
                                                            </div>
                        </td>
                    </tr>
                </tbody></table>
            </div>

            <div id="command_actions" class="target-select clearfix vis float_left">
                <h4>Komut:</h4>


                <table class="vis" style="width: 100%">
                    <tbody><tr>
                        <td>
                            <input id="target_attack" tabindex="15" class="attack btn btn-attack btn-target-action" name="attack" type="submit" value="Saldır">                            <input id="target_support" tabindex="16" class="support btn btn-support btn-target-action" name="support" type="submit" value="Destekle">                        </td>
                    </tr>
                </tbody></table>
            </div>
            </form>

    <div class="vis float_left" style="margin: 4px 0 0 10px; min-width: 125px;">
	<h4>
					<a href="/game.php?village=12218&amp;screen=place&amp;mode=templates">Birlik şablonları</a>
			</h4>
	<table class="vis" style="width: 100%">
		<tbody><tr class="row_b">
			<td><a id="selectAllUnits" href="#">Tüm birlikler</a></td>
		</tr>
			</tbody></table>
</div>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>

---

## ✅ 3. ANA BİNA (MAIN)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=main`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Bina listesi görünüyor mu?
- [ ] `.main_buildrow[data-building='barracks']` gibi elementler var mı?
- [ ] Bina seviyeleri görünüyor mu?
- [ ] İnşaat kuyruğu var mı? (`#build_queue`)

**Lütfen ver:**
```
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <script type="text/javascript">
//<![CDATA[
	$(document).ready(function() {
		BuildingMain.upgrade_building_link = '/game.php?village=12218&screen=main&ajaxaction=upgrade_building&type=main&h=58fce238';
		BuildingMain.downgrade_building_link = '/game.php?village=12218&screen=main&ajaxaction=downgrade_building&type=main&h=58fce238';
		BuildingMain.confirm_queue = false;
		BuildingMain.mode = 0;
	});
//]]>
</script>

<table width="100%"><tbody><tr>
		<td><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/main2.webp" alt="Ana bina" class=""></td>
		<td width="100%"><h2>	Ana bina (Seviye 10)</h2>
Ana bina sayesinde yeni binalar yapılabilir ya da var olan binalar geliştirilebilir. Ana binanın seviyesi ne kadar yüksekse, yeni binalar o kadar çabuk yapılabilir. Ana Binan 15. seviyeye geldiğinde bu köyde binaları yıkabileceksin (100% sadakat gerektirir).</td>
		<td align="right" valign="top" style="white-space:nowrap;"><a href="https://help.klanlar.org/wiki/Binalar" target="_blank">
				Binalar hakkında yardım
			</a></td>
	</tr></tbody></table><br>



<script>
	$(document).ready(function() {
		BuildingMain.init_res_schedule(1768411852062, {"schedules":{"wood":{"1768411188":"0.055341511957154","1770799517":"0.046557144979828"},"stone":{"1768411188":"0.055341511957154","1770799519":"0.046557144979828"},"iron":{"1768411188":"0.040907546663522","1770799523":"0.03441428528836"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411188,1770799517],"stone":[1768411188,1770799519],"iron":[1768411188,1770799523]}}, {"schedules":{"wood":{"1768411178":"302.77550738649","1770799517":"132477.06683362"},"stone":{"1768411178":"3812.7755073865","1770799519":"135987.17751665"},"iron":{"1768411178":"1437.9340788928","1770799523":"99139.268614982"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411178,1770799517],"stone":[1768411178,1770799519],"iron":[1768411178,1770799523]},"values":{"wood":["302.77550738649","132477.06683362"],"stone":["3812.7755073865","135987.17751665"],"iron":["1437.9340788928","99139.268614982"]},"next_timestamps":{"wood":{"1768411178":1770799517},"stone":{"1768411178":1770799519},"iron":{"1768411178":1770799523}},"schedules_flipped":{"wood":{"302.77550738649":1768411178,"132477.06683362":1770799517},"stone":{"3812.7755073865":1768411178,"135987.17751665":1770799519},"iron":{"1437.9340788928":1768411178,"99139.268614982":1770799523}}});
	});
</script>


<div id="buildqueue_wrap">
	<table id="build_queue" class="vis" style="width: 100%">
	<tbody id="buildqueue" class="ui-sortable">
	<tr>
		<th style="width: 23%">İnşaat</th>
		<th>Süre</th>
				<th>Hızlandır</th>
				<th>Tamamlanma</th>
		<th style="width: 15%">İptal</th>
		<th style="background:none !important;"></th>	</tr>
		<tr class="lit nodrag buildorder_wall">
		<td class="lit-item">
			<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/wall2.webp" class="bmain_list_img" data-title="Sur">
			Sur<br>
			Seviye 8		</td>
		<td class="nowrap lit-item">
							<span class="" data-endtime="1768413217">0:22:32</span>
					</td>
				<td class="lit-item">
											<a class="order_feature btn btn-btr" onclick="return BuildingMain.change_order(698485, 'BuildTimeReduction', 10)" href="#" data-available-from="0" data-available-to="1768412617" data-title="Kalan yapım süresini 50% azaltır.&lt;br /&gt;&lt;br /&gt;&lt;strong&gt;Masraf: &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot; title=&quot;Premium Puan&quot;&gt; &lt;/span&gt;10" style="">
					-50%
				</a>
								<a class="order_feature btn btn-btr btn-instant" onclick="return BuildingMain.change_order(698485, 'BuildInstant', 10)" href="#" data-available-from="1768412617" data-available-to="1768413037" style="display: none" data-title="İnşaatı anında tamamlar.&lt;br /&gt;&lt;br /&gt;&lt;strong&gt;Masraf: &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot; title=&quot;Premium Puan&quot;&gt; &lt;/span&gt;10&lt;br /&gt;&lt;span class=&quot;green&quot;&gt;0:03:00 varken ücretsiz.&lt;/span&gt;">
					Bitir
				</a>
								<a class="order_feature btn btn-btr btn-instant-free" onclick="return BuildingMain.change_order(698485, 'BuildInstantFree', 0)" href="#" data-available-from="1768413037" data-available-to="1768413217" style="display: none" data-title="İnşaatı anında ücretsiz tamamlar.">
					Bitir
				</a>
									</td>
				<td class="lit-item">bugün saat 20:53:37</td>
		<td class="lit-item">
			<a class="btn btn-cancel" href="/game.php?village=12218&amp;screen=main&amp;action=cancel&amp;id=698485&amp;mode=build&amp;h=58fce238" onclick="return BuildingMain.cancel(698485, false);">İptal et</a>
		</td>
			</tr>
		<tr class="lit">
		<td colspan="5" style="padding: 0">
			<div class="order-progress" data-progress="{&quot;progress&quot;:[],&quot;slot_start&quot;:1768406755,&quot;slot_end&quot;:&quot;1768413217&quot;,&quot;slot_time&quot;:6462,&quot;slot_elapsed&quot;:5097,&quot;percentage_complete&quot;:&quot;0&quot;}">

			<div class="anim" data-title="" style="width: 79.0932%; background-color: rgb(146, 194, 0);"></div></div>
		</td>
	</tr>
				</tbody>
</table>
<script type="text/javascript">
//<![CDATA[
	BuildingMain.link_cancel = '/game.php?village=12218&screen=main&ajaxaction=cancel_order&type=main&h=58fce238';
	BuildingMain.link_change_order = '/game.php?village=12218&screen=main&ajaxaction=build_order_reduce&h=58fce238';
	BuildingMain.order_count = 1;

	BuildingMain.init_buildqueue('/game.php?village=12218&screen=main&ajaxaction=buildorder_reorder&buildmode=1&h=58fce238');
//]]>
</script>

        <br>
</div>
<script>
    BuildingMain.buildings = {"main":{"id":"main","image":"buildings\/main.png","max_level":30,"min_level":1,"image_levels":[5,15],"req":[],"require":[],"wood":908,"stone":908,"iron":706,"pop":3,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":3403,"build_time_factor":1.2,"build_time_min":10,"points":10,"wood_cheap":726,"stone_cheap":726,"iron_cheap":564,"order":null,"level":"10","level_next":11,"error":"Mevcut hammaddeler bug\u00fcn saat 23:21","forecast":{"available":"future","when":1768422115},"can_build":true,"big_image":"main2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Ana bina","text":"Ana bina sayesinde yeni binalar yap\u0131labilir ya da var olan binalar geli\u015ftirilebilir. Ana binan\u0131n seviyesi ne kadar y\u00fcksekse, yeni binalar o kadar \u00e7abuk yap\u0131labilir. Ana Binan 15. seviyeye geldi\u011finde bu k\u00f6yde binalar\u0131 y\u0131kabileceksin (100% sadakat gerektirir)."},"barracks":{"id":"barracks","image":"buildings\/barracks.png","max_level":25,"min_level":0,"image_levels":[5,20],"req":{"main":3},"require":{"main":{"level":3,"name":"Ana bina","image":"buildings\/main.png","big_image":"main1","met":true}},"wood":635,"stone":584,"iron":286,"pop":2,"wood_factor":1.26,"stone_factor":1.28,"iron_factor":1.26,"pop_factor":1.17,"build_time":1667,"build_time_factor":1.2,"build_time_min":10,"points":16,"wood_cheap":508,"stone_cheap":467,"iron_cheap":228,"order":null,"level":"5","level_next":6,"error":"Mevcut hammaddeler bug\u00fcn saat 21:59","forecast":{"available":"future","when":1768417182},"can_build":true,"big_image":"barracks2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"K\u0131\u015fla","text":"K\u0131\u015flada piyade \u00fcretebilirsin. K\u0131\u015flan\u0131n seviyesi ne kadar y\u00fcksekse birliklerini o kadar h\u0131zl\u0131 \u00fcretebilirsin."},"stable":{"id":"stable","image":"buildings\/stable.png","max_level":20,"min_level":0,"image_levels":[5,10],"req":{"main":10,"barracks":5,"smith":5},"require":{"main":{"level":10,"name":"Ana bina","image":"buildings\/main.png","big_image":"main2","met":true},"barracks":{"level":5,"name":"K\u0131\u015fla","image":"buildings\/barracks.png","big_image":"barracks2","met":true},"smith":{"level":5,"name":"Demirci","image":"buildings\/smith.png","big_image":"smith2","met":true}},"wood":540,"stone":503,"iron":520,"pop":2,"wood_factor":1.26,"stone_factor":1.28,"iron_factor":1.26,"pop_factor":1.17,"build_time":1843,"build_time_factor":1.2,"build_time_min":10,"points":20,"wood_cheap":432,"stone_cheap":402,"iron_cheap":416,"order":null,"level":"3","level_next":4,"error":"Mevcut hammaddeler bug\u00fcn saat 21:31","forecast":{"available":"future","when":1768415465},"can_build":true,"big_image":"stable1","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Ah\u0131r","text":"Ah\u0131rda atl\u0131lar\u0131 yeti\u015ftirebilirsin. Ah\u0131r\u0131n\u0131n seviyesi ne kadar y\u00fcksek olursa, o kadar h\u0131zl\u0131 birlik yeti\u015ftirebilirsin."},"church_f":{"id":"church_f","image":"buildings\/church.png","max_level":1,"min_level":0,"image_levels":[],"req":[],"require":[],"wood":202,"stone":256,"iron":63,"pop":3,"wood_factor":1.26,"stone_factor":1.28,"iron_factor":1.26,"pop_factor":1.55,"build_time":481,"build_time_factor":1.2,"build_time_min":10,"points":10,"wood_cheap":161,"stone_cheap":204,"iron_cheap":50,"order":null,"level":"1","level_next":2,"error":null,"forecast":null,"can_build":true,"big_image":"church_f1","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"Ana Tap\u0131nak","text":"Tap\u0131nak etkisi alt\u0131nda bulunan k\u00f6ylerdeki askerlerin tam g\u00fc\u00e7le sava\u015fmas\u0131n\u0131 sa\u011flar. E\u011fer k\u00f6ylerinizden biri tap\u0131na\u011f\u0131n etki alan\u0131nda de\u011filse birlikler yaln\u0131zca 50% g\u00fc\u00e7le sava\u015f\u0131r. Ana Tap\u0131na\u011f\u0131n etki alan\u0131 daha geni\u015ftir. Bu tap\u0131naktan sadece bir taneye sahip olabilirsiniz."},"smith":{"id":"smith","image":"buildings\/smith.png","max_level":20,"min_level":0,"image_levels":[5,15],"req":{"main":5,"barracks":1},"require":{"main":{"level":5,"name":"Ana bina","image":"buildings\/main.png","big_image":"main2","met":true},"barracks":{"level":1,"name":"K\u0131\u015fla","image":"buildings\/barracks.png","big_image":"barracks1","met":true}},"wood":699,"stone":606,"iron":762,"pop":7,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":5555,"build_time_factor":1.2,"build_time_min":10,"points":19,"wood_cheap":559,"stone_cheap":484,"iron_cheap":609,"order":null,"level":"5","level_next":6,"error":"Mevcut hammaddeler bug\u00fcn saat 22:18","forecast":{"available":"future","when":1768418338},"can_build":true,"big_image":"smith2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Demirci","text":"Demircide yeni silahlar ara\u015ft\u0131rabilir ve geli\u015ftirebilirsin. Demircinin seviyesi ne kadar y\u00fcksekse o kadar iyi silahlar geli\u015ftirir ve o derece k\u0131sa s\u00fcrede ara\u015ft\u0131rma yapars\u0131n."},"place":{"id":"place","image":"buildings\/place.png","max_level":1,"min_level":0,"image_levels":[],"req":[],"require":[],"wood":13,"stone":51,"iron":38,"pop":0,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":50,"build_time_factor":1.2,"build_time_min":10,"points":0,"wood_cheap":10,"stone_cheap":40,"iron_cheap":30,"order":null,"level":"1","level_next":2,"error":null,"forecast":null,"can_build":true,"big_image":"place1","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"\u0130\u00e7tima Meydan\u0131","text":"\u0130\u00e7tima meydan\u0131nda sava\u015f\u00e7\u0131lar\u0131n toplan\u0131r. Bu merkezde sald\u0131r\u0131 emirlerini verebilir ve birliklerini kayd\u0131rabilirsin."},"statue":{"id":"statue","image":"buildings\/statue.png","max_level":1,"min_level":0,"image_levels":[],"req":[],"require":[],"wood":277,"stone":281,"iron":277,"pop":2,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":10,"build_time_factor":1.2,"build_time_min":10,"points":24,"wood_cheap":221,"stone_cheap":224,"iron_cheap":221,"order":null,"level":"1","level_next":2,"error":null,"forecast":null,"can_build":true,"big_image":"statue1","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"Heykel","text":"E\u011fer hala yoksa Heykelde bir \u015f\u00f6valye \u00fcretebilirsin. Ayn\u0131 anda sadece bir adet \u015f\u00f6valyen olabilir."},"market":{"id":"market","image":"buildings\/market.png","max_level":25,"min_level":0,"image_levels":[5,20],"req":{"main":3,"storage":2},"require":{"main":{"level":3,"name":"Ana bina","image":"buildings\/main.png","big_image":"main1","met":true},"storage":{"level":2,"name":"Depo","image":"buildings\/storage.png","big_image":"storage1","met":true}},"wood":318,"stone":337,"iron":318,"pop":7,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":2500,"build_time_factor":1.2,"build_time_min":10,"points":10,"wood_cheap":254,"stone_cheap":269,"iron_cheap":254,"order":null,"level":"5","level_next":6,"error":null,"forecast":null,"can_build":true,"big_image":"market2","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"Pazar","text":"Pazar yerinde ba\u015fka oyuncularla ticaret yapabilir ya da onlara hammadde g\u00f6nderebilirsin."},"wood":{"id":"wood","image":"buildings\/wood.png","max_level":30,"min_level":0,"image_levels":[10,20],"req":[],"require":[],"wood":728,"stone":1107,"iron":555,"pop":4,"wood_factor":1.25,"stone_factor":1.275,"iron_factor":1.245,"pop_factor":1.155,"build_time":5218,"build_time_factor":1.2,"build_time_min":10,"points":6,"wood_cheap":582,"stone_cheap":885,"iron_cheap":444,"order":null,"level":"12","level_next":13,"error":"Mevcut hammaddeler bug\u00fcn saat 22:27","forecast":{"available":"future","when":1768418862},"can_build":true,"big_image":"wood2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Oduncu","text":"Oduncular\u0131n k\u00f6y\u00fcn\u00fcn d\u0131\u015f\u0131ndaki s\u0131k ormandan odun keser. Bu odunlar\u0131 hem k\u00f6y\u00fcn\u00fc geli\u015ftirmek, hem de ordunu silahland\u0131rmak i\u00e7in kullanabilirsin. Oduncunun seviyesi ne kadar y\u00fcksekse, o kadar \u00e7ok kalas \u00fcretilir."},"stone":{"id":"stone","image":"buildings\/stone.png","max_level":30,"min_level":0,"image_levels":[10,20],"req":[],"require":[],"wood":1144,"stone":840,"iron":529,"pop":6,"wood_factor":1.27,"stone_factor":1.265,"iron_factor":1.24,"pop_factor":1.14,"build_time":5218,"build_time_factor":1.2,"build_time_min":10,"points":6,"wood_cheap":915,"stone_cheap":672,"iron_cheap":423,"order":null,"level":"12","level_next":13,"error":"Mevcut hammaddeler yar\u0131n \u015fu saatte 00:32","forecast":{"available":"future","when":1768426379},"can_build":true,"big_image":"stone2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Kil oca\u011f\u0131","text":"Kil oca\u011f\u0131nda i\u015f\u00e7ilerin, k\u00f6y\u00fcn\u00fc kurmak i\u00e7in \u00f6nemli olan kili \u00e7\u0131kar\u0131rlar. Kil oca\u011f\u0131n\u0131n seviyesi ne kadar y\u00fcksekse o kadar \u00e7ok kil \u00e7\u0131kar\u0131l\u0131r."},"iron":{"id":"iron","image":"buildings\/iron.png","max_level":30,"min_level":0,"image_levels":[10,20],"req":[],"require":[],"wood":710,"stone":738,"iron":602,"pop":7,"wood_factor":1.252,"stone_factor":1.275,"iron_factor":1.24,"pop_factor":1.17,"build_time":4083,"build_time_factor":1.2,"build_time_min":10,"points":6,"wood_cheap":568,"stone_cheap":590,"iron_cheap":481,"order":null,"level":"10","level_next":11,"error":"Mevcut hammaddeler bug\u00fcn saat 22:22","forecast":{"available":"future","when":1768418537},"can_build":true,"big_image":"iron2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Demir madeni","text":"Demir madeninde, i\u015f\u00e7ilerin sava\u015flar\u0131n sonucunu belirleyen demiri \u00e7\u0131kar\u0131rlar. Demir madeninin seviyesi ne kadar y\u00fcksekse, o kadar \u00e7ok demir \u00fcretilir."},"farm":{"id":"farm","image":"buildings\/farm.png","max_level":30,"min_level":1,"image_levels":[10,20],"req":[],"require":[],"wood":477,"stone":487,"iron":297,"pop":0,"wood_factor":1.3,"stone_factor":1.32,"iron_factor":1.29,"pop_factor":1,"build_time":3605,"build_time_factor":1.2,"build_time_min":10,"points":5,"wood_cheap":381,"stone_cheap":389,"iron_cheap":237,"order":null,"level":"9","level_next":10,"error":"Mevcut hammaddeler bug\u00fcn saat 21:12","forecast":{"available":"future","when":1768414327},"can_build":true,"big_image":"farm1","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"\u00c7iftlik","text":"\u00c7iftlik, birliklerine ve i\u015f\u00e7ilerine yiyecek sa\u011flar. \u00c7iftli\u011fini geli\u015ftirmezsen k\u00f6y\u00fcn b\u00fcy\u00fcmez. \u00c7iftli\u011fin seviyesi ne kadar y\u00fcksekse o derecede fazla n\u00fcfus besleyebilirsin."},"storage":{"id":"storage","image":"buildings\/storage.png","max_level":30,"min_level":1,"image_levels":[10,20],"req":[],"require":[],"wood":630,"stone":546,"iron":358,"pop":0,"wood_factor":1.265,"stone_factor":1.27,"iron_factor":1.245,"pop_factor":1.15,"build_time":3856,"build_time_factor":1.2,"build_time_min":10,"points":6,"wood_cheap":504,"stone_cheap":436,"iron_cheap":286,"order":null,"level":"10","level_next":11,"error":"Mevcut hammaddeler bug\u00fcn saat 21:58","forecast":{"available":"future","when":1768417091},"can_build":true,"big_image":"storage2","cheap":false,"cheap_possible":true,"destroy_time":null,"name":"Depo","text":"Depo sayesinde, k\u00f6y\u00fcnde \u00fcretilen hammaddeleri (odun, kil, demir) depolayabilirsin. Deponun seviyesi ne kadar y\u00fcksekse, i\u00e7inde o kadar \u00e7ok hammadde depolanabilir."},"hide":{"id":"hide","image":"buildings\/hide.png","max_level":10,"min_level":0,"image_levels":[],"req":[],"require":[],"wood":78,"stone":94,"iron":78,"pop":1,"wood_factor":1.25,"stone_factor":1.25,"iron_factor":1.25,"pop_factor":1.17,"build_time":178,"build_time_factor":1.2,"build_time_min":10,"points":5,"wood_cheap":62,"stone_cheap":75,"iron_cheap":62,"order":null,"level":"2","level_next":3,"error":null,"forecast":null,"can_build":true,"big_image":"hide1","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"Gizli depo","text":"Gizli depo sayesinde, hammaddelerini g\u00fcvenli bir \u015fekilde d\u00fc\u015fmanlar\u0131ndan saklayabilirsin, b\u00f6ylece ya\u011fmalanmalar\u0131n\u0131 \u00f6nlersin.  D\u00fc\u015fman casuslar bile gizli deponuzdaki hammaddeleri g\u00f6remezler."},"wall":{"id":"wall","image":"buildings\/wall.png","max_level":20,"min_level":0,"image_levels":[5,15],"req":{"barracks":1},"require":{"barracks":{"level":1,"name":"K\u0131\u015fla","image":"buildings\/barracks.png","big_image":"barracks1","met":true}},"wood":318,"stone":698,"iron":127,"pop":3,"wood_factor":1.26,"stone_factor":1.275,"iron_factor":1.26,"pop_factor":1.17,"build_time":8457,"build_time_factor":1.2,"build_time_min":240,"points":8,"wood_cheap":254,"stone_cheap":558,"iron_cheap":101,"order":null,"level":"7","level_next":9,"error":null,"forecast":null,"can_build":true,"big_image":"wall2","cheap":true,"cheap_possible":true,"destroy_time":null,"name":"Sur","text":"Sur d\u00fc\u015fman birliklerine kar\u015f\u0131 k\u00f6y\u00fcn\u00fc korur. Seviyesi ne kadar y\u00fcksek olursa, k\u00f6y\u00fcn de o kadar iyi korunur. Ayr\u0131ca k\u00f6ydeki birimlerin savunma g\u00fcc\u00fcn\u00fc de art\u0131r\u0131r."}};
</script>

<div id="building_wrapper">

    
    <table id="buildings" class="vis nowrap" style="width: 100%;">
        <tbody><tr>
            <th style="width: 23%">Binalar</th>
            <th colspan="5">İhtiyaç</th>
            <th style="width: 30%">İnşa et</th>
        </tr>
                <tr id="main_buildrow_main">
            <td>
                <a href="/game.php?village=12218&amp;screen=main"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/main2.webp" class="bmain_list_img" data-title="Ana bina"></a>
                <a href="/game.php?village=12218&amp;screen=main">Ana bina</a><br>
                <span style="font-size: 0.9em">Seviye 10</span>
            </td>
                            <td data-cost="908" class="cost_wood warn"><span class="icon header wood"> </span>908</td>
                <td data-cost="908" class="cost_stone"><span class="icon header stone"> </span>908</td>
                <td data-cost="706" class="cost_iron"><span class="icon header iron"> </span>706</td>
                <td><span class="icon header time"></span>0:56:43</td>
                <td><span class="icon header population"> </span>3</td>
                <td class="build_options">

                                    <a id="main_buildlink_main_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=main&amp;type=main&amp;h=58fce238&amp;cheap" data-building="main" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;908&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;726&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;908&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;726&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;706&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;564&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 22:27&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build current-quest" id="main_buildlink_main_11" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=main&amp;type=main&amp;h=58fce238" data-building="main" data-level-next="11" data-title="Başkent Kurmak II">Seviye 11</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 23:21 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_barracks">
            <td>
                <a href="/game.php?village=12218&amp;screen=barracks"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/barracks2.webp" class="bmain_list_img" data-title="Kışla"></a>
                <a href="/game.php?village=12218&amp;screen=barracks">Kışla</a><br>
                <span style="font-size: 0.9em">Seviye 5</span>
            </td>
                            <td data-cost="635" class="cost_wood warn"><span class="icon header wood"> </span>635</td>
                <td data-cost="584" class="cost_stone"><span class="icon header stone"> </span>584</td>
                <td data-cost="286" class="cost_iron"><span class="icon header iron"> </span>286</td>
                <td><span class="icon header time"></span>0:27:47</td>
                <td><span class="icon header population"> </span>2</td>
                <td class="build_options">

                                    <a id="main_buildlink_barracks_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=barracks&amp;type=main&amp;h=58fce238&amp;cheap" data-building="barracks" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;635&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;508&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;584&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;467&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;286&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;228&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 21:21&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_barracks_6" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=barracks&amp;type=main&amp;h=58fce238" data-building="barracks" data-level-next="6">Seviye 6</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 21:59 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_stable">
            <td>
                <a href="/game.php?village=12218&amp;screen=stable"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/stable1.webp" class="bmain_list_img" data-title="Ahır"></a>
                <a href="/game.php?village=12218&amp;screen=stable">Ahır</a><br>
                <span style="font-size: 0.9em">Seviye 3</span>
            </td>
                            <td data-cost="540" class="cost_wood warn"><span class="icon header wood"> </span>540</td>
                <td data-cost="503" class="cost_stone"><span class="icon header stone"> </span>503</td>
                <td data-cost="520" class="cost_iron"><span class="icon header iron"> </span>520</td>
                <td><span class="icon header time"></span>0:30:43</td>
                <td><span class="icon header population"> </span>2</td>
                <td class="build_options">

                                    <a id="main_buildlink_stable_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=stable&amp;type=main&amp;h=58fce238&amp;cheap" data-building="stable" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;540&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;432&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;503&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;402&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;520&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;416&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 20:58&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_stable_4" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=stable&amp;type=main&amp;h=58fce238" data-building="stable" data-level-next="4">Seviye 4</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 21:31 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_church_f">
            <td>
                <a href="/game.php?village=12218&amp;screen=church_f"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/church_f1.webp" class="bmain_list_img" data-title="Ana Tapınak"></a>
                <a href="/game.php?village=12218&amp;screen=church_f">Ana Tapınak</a><br>
                <span style="font-size: 0.9em">Seviye 1</span>
            </td>
                            <td colspan="6" class="inactive center">Bina gelişimi tamamlandı</td>
                    </tr>
            <tr id="main_buildrow_smith">
            <td>
                <a href="/game.php?village=12218&amp;screen=smith"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/smith2.webp" class="bmain_list_img" data-title="Demirci"></a>
                <a href="/game.php?village=12218&amp;screen=smith">Demirci</a><br>
                <span style="font-size: 0.9em">Seviye 5</span>
            </td>
                            <td data-cost="699" class="cost_wood warn"><span class="icon header wood"> </span>699</td>
                <td data-cost="606" class="cost_stone"><span class="icon header stone"> </span>606</td>
                <td data-cost="762" class="cost_iron"><span class="icon header iron"> </span>762</td>
                <td><span class="icon header time"></span>1:32:35</td>
                <td><span class="icon header population"> </span>7</td>
                <td class="build_options">

                                    <a id="main_buildlink_smith_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=smith&amp;type=main&amp;h=58fce238&amp;cheap" data-building="smith" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;699&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;559&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;606&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;484&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;762&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;609&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 21:36&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_smith_6" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=smith&amp;type=main&amp;h=58fce238" data-building="smith" data-level-next="6">Seviye 6</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 22:19 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_place">
            <td>
                <a href="/game.php?village=12218&amp;screen=place"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/place1.webp" class="bmain_list_img" data-title="İçtima Meydanı"></a>
                <a href="/game.php?village=12218&amp;screen=place">İçtima Meydanı</a><br>
                <span style="font-size: 0.9em">Seviye 1</span>
            </td>
                            <td colspan="6" class="inactive center">Bina gelişimi tamamlandı</td>
                    </tr>
            <tr id="main_buildrow_statue">
            <td>
                <a href="/game.php?village=12218&amp;screen=statue"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/statue1.webp" class="bmain_list_img" data-title="Heykel"></a>
                <a href="/game.php?village=12218&amp;screen=statue">Heykel</a><br>
                <span style="font-size: 0.9em">Seviye 1</span>
            </td>
                            <td colspan="6" class="inactive center">Bina gelişimi tamamlandı</td>
                    </tr>
            <tr id="main_buildrow_market">
            <td>
                <a href="/game.php?village=12218&amp;screen=market"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/market2.webp" class="bmain_list_img" data-title="Pazar"></a>
                <a href="/game.php?village=12218&amp;screen=market">Pazar</a><br>
                <span style="font-size: 0.9em">Seviye 5</span>
            </td>
                            <td data-cost="318" class="cost_wood"><span class="icon header wood"> </span>318</td>
                <td data-cost="337" class="cost_stone"><span class="icon header stone"> </span>337</td>
                <td data-cost="318" class="cost_iron"><span class="icon header iron"> </span>318</td>
                <td><span class="icon header time"></span>0:41:40</td>
                <td><span class="icon header population"> </span>7</td>
                <td class="build_options">

                                    <a id="main_buildlink_market_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=market&amp;type=main&amp;h=58fce238&amp;cheap" data-building="market" data-cost="30" class="btn btn-bcr float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;318&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;254&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;337&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;269&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;318&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;254&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

">-20%</a>
                

                                <a class="btn btn-build" id="main_buildlink_market_6" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=market&amp;type=main&amp;h=58fce238" data-building="market" data-level-next="6">Seviye 6</a>

                                                                    </td>
                    </tr>
            <tr id="main_buildrow_wood">
            <td>
                <a href="/game.php?village=12218&amp;screen=wood"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/wood2.webp" class="bmain_list_img" data-title="Oduncu"></a>
                <a href="/game.php?village=12218&amp;screen=wood">Oduncu</a><br>
                <span style="font-size: 0.9em">Seviye 12</span>
            </td>
                            <td data-cost="728" class="cost_wood warn"><span class="icon header wood"> </span>728</td>
                <td data-cost="1107" class="cost_stone"><span class="icon header stone"> </span>1107</td>
                <td data-cost="555" class="cost_iron"><span class="icon header iron"> </span>555</td>
                <td><span class="icon header time"></span>1:26:58</td>
                <td><span class="icon header population"> </span>4</td>
                <td class="build_options">

                                    <a id="main_buildlink_wood_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=wood&amp;type=main&amp;h=58fce238&amp;cheap" data-building="wood" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;728&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;582&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;1107&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;885&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;555&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;444&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 21:43&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_wood_13" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=wood&amp;type=main&amp;h=58fce238" data-building="wood" data-level-next="13">Seviye 13</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 22:27 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_stone">
            <td>
                <a href="/game.php?village=12218&amp;screen=stone"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/stone2.webp" class="bmain_list_img" data-title="Kil ocağı"></a>
                <a href="/game.php?village=12218&amp;screen=stone">Kil ocağı</a><br>
                <span style="font-size: 0.9em">Seviye 12</span>
            </td>
                            <td data-cost="1144" class="cost_wood warn"><span class="icon header wood"> </span>1144</td>
                <td data-cost="840" class="cost_stone"><span class="icon header stone"> </span>840</td>
                <td data-cost="529" class="cost_iron"><span class="icon header iron"> </span>529</td>
                <td><span class="icon header time"></span>1:26:58</td>
                <td><span class="icon header population"> </span>6</td>
                <td class="build_options">

                                    <a id="main_buildlink_stone_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=stone&amp;type=main&amp;h=58fce238&amp;cheap" data-building="stone" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;1144&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;915&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;840&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;672&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;529&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;423&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 23:24&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_stone_13" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=stone&amp;type=main&amp;h=58fce238" data-building="stone" data-level-next="13">Seviye 13</a>

                                                        <div class="inactive" style="width: 165px">yarın şu saatte 00:33 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_iron">
            <td>
                <a href="/game.php?village=12218&amp;screen=iron"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/iron2.webp" class="bmain_list_img" data-title="Demir madeni"></a>
                <a href="/game.php?village=12218&amp;screen=iron">Demir madeni</a><br>
                <span style="font-size: 0.9em">Seviye 10</span>
            </td>
                            <td data-cost="710" class="cost_wood warn"><span class="icon header wood"> </span>710</td>
                <td data-cost="738" class="cost_stone"><span class="icon header stone"> </span>738</td>
                <td data-cost="602" class="cost_iron"><span class="icon header iron"> </span>602</td>
                <td><span class="icon header time"></span>1:08:03</td>
                <td><span class="icon header population"> </span>7</td>
                <td class="build_options">

                                    <a id="main_buildlink_iron_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=iron&amp;type=main&amp;h=58fce238&amp;cheap" data-building="iron" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;710&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;568&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;738&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;590&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;602&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;481&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 21:39&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_iron_11" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=iron&amp;type=main&amp;h=58fce238" data-building="iron" data-level-next="11">Seviye 11</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 22:22 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_farm">
            <td>
                <a href="/game.php?village=12218&amp;screen=farm"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/farm1.webp" class="bmain_list_img" data-title="Çiftlik"></a>
                <a href="/game.php?village=12218&amp;screen=farm">Çiftlik</a><br>
                <span style="font-size: 0.9em">Seviye 9</span>
            </td>
                            <td data-cost="477" class="cost_wood warn"><span class="icon header wood"> </span>477</td>
                <td data-cost="487" class="cost_stone"><span class="icon header stone"> </span>487</td>
                <td data-cost="297" class="cost_iron"><span class="icon header iron"> </span>297</td>
                <td><span class="icon header time"></span>1:00:05</td>
                <td></td>
                <td class="build_options">

                                    <a id="main_buildlink_farm_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=farm&amp;type=main&amp;h=58fce238&amp;cheap" data-building="farm" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;477&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;381&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;487&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;389&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;297&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;237&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 20:43&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_farm_10" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=farm&amp;type=main&amp;h=58fce238" data-building="farm" data-level-next="10">Seviye 10</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 21:12 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_storage">
            <td>
                <a href="/game.php?village=12218&amp;screen=storage"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/storage2.webp" class="bmain_list_img" data-title="Depo"></a>
                <a href="/game.php?village=12218&amp;screen=storage">Depo</a><br>
                <span style="font-size: 0.9em">Seviye 10</span>
            </td>
                            <td data-cost="630" class="cost_wood warn"><span class="icon header wood"> </span>630</td>
                <td data-cost="546" class="cost_stone"><span class="icon header stone"> </span>546</td>
                <td data-cost="358" class="cost_iron"><span class="icon header iron"> </span>358</td>
                <td><span class="icon header time"></span>1:04:16</td>
                <td></td>
                <td class="build_options">

                                    <a id="main_buildlink_storage_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=storage&amp;type=main&amp;h=58fce238&amp;cheap" data-building="storage" data-cost="30" class="btn btn-bcr btn-bcr-disabled float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;630&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;504&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;546&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;436&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;358&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;286&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

	&lt;span class=&quot;inactive&quot;&gt;Mevcut hammaddeler bugün saat 21:20&lt;/span&gt;
">-20%</a>
                

                                <a style="display:none" class="btn btn-build" id="main_buildlink_storage_11" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=storage&amp;type=main&amp;h=58fce238" data-building="storage" data-level-next="11">Seviye 11</a>

                                                        <div class="inactive" style="width: 165px">bugün saat 21:58 mevcut hammaddeler</div>
                                                    </td>
                    </tr>
            <tr id="main_buildrow_hide">
            <td>
                <a href="/game.php?village=12218&amp;screen=hide"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/hide1.webp" class="bmain_list_img" data-title="Gizli depo"></a>
                <a href="/game.php?village=12218&amp;screen=hide">Gizli depo</a><br>
                <span style="font-size: 0.9em">Seviye 2</span>
            </td>
                            <td data-cost="78" class="cost_wood"><span class="icon header wood"> </span>78</td>
                <td data-cost="94" class="cost_stone"><span class="icon header stone"> </span>94</td>
                <td data-cost="78" class="cost_iron"><span class="icon header iron"> </span>78</td>
                <td><span class="icon header time"></span>0:02:58</td>
                <td><span class="icon header population"> </span>1</td>
                <td class="build_options">

                                    <a id="main_buildlink_hide_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=hide&amp;type=main&amp;h=58fce238&amp;cheap" data-building="hide" data-cost="30" class="btn btn-bcr float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;78&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;62&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;94&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;75&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;78&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;62&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

">-20%</a>
                

                                <a class="btn btn-build" id="main_buildlink_hide_3" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=hide&amp;type=main&amp;h=58fce238" data-building="hide" data-level-next="3">Seviye 3</a>

                                                                    </td>
                    </tr>
            <tr id="main_buildrow_wall">
            <td>
                <a href="/game.php?village=12218&amp;screen=wall"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/wall2.webp" class="bmain_list_img" data-title="Sur"></a>
                <a href="/game.php?village=12218&amp;screen=wall">Sur</a><br>
                <span style="font-size: 0.9em">Seviye 7</span>
            </td>
                            <td data-cost="318" class="cost_wood"><span class="icon header wood"> </span>318</td>
                <td data-cost="698" class="cost_stone"><span class="icon header stone"> </span>698</td>
                <td data-cost="127" class="cost_iron"><span class="icon header iron"> </span>127</td>
                <td><span class="icon header time"></span>2:20:57</td>
                <td><span class="icon header population"> </span>3</td>
                <td class="build_options">

                                    <a id="main_buildlink_wall_cheap" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=wall&amp;type=main&amp;h=58fce238&amp;cheap" data-building="wall" data-cost="30" class="btn btn-bcr float_right" data-title="20% azaltılan masraf: &lt;br /&gt;


&lt;strike&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;318&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header wood&quot;&gt; &lt;/span&gt;254&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;698&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header stone&quot;&gt; &lt;/span&gt;558&lt;/span&gt;&lt;br/&gt;
&lt;strike&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;127&lt;/strike&gt;
&lt;span&gt;&lt;span class=&quot;icon header iron&quot; &gt; &lt;/span&gt;101&lt;/span&gt;&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;Masraf:  &lt;/strong&gt; &lt;span class=&quot;icon header premium&quot;&gt;&lt;/span&gt;30

">-20%</a>
                

                                <a class="btn btn-build current-quest" id="main_buildlink_wall_9" href="/game.php?village=12218&amp;screen=main&amp;action=upgrade_building&amp;id=wall&amp;type=main&amp;h=58fce238" data-building="wall" data-level-next="9" data-title="Başkent Kurmak II">Seviye 9</a>

                                                                    </td>
                    </tr>
        </tbody></table>

    <br>

        <table id="buildings_unmet" class="vis nowrap tall" style="width: 100%">
        <tbody><tr>
            <th style="width: 23%">Henüz yok</th>
            <th>İhtiyaç</th>
        </tr>
                <tr>
            <td>
                <a href="/game.php?village=12218&amp;screen=garage"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/garage1.webp" class="bmain_list_img" data-title="Atölye"></a>
                <a href="/game.php?village=12218&amp;screen=garage">Atölye</a>
            </td>
            <td>
                <div class="unmet_req">
                                    <span>
                                        <span>
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/main2.webp" style="vertical-align: middle" alt="" class="">
                        <span>Ana bina (10)</span>
                    </span>
                                        </span>
                                    <span>
                                        <span>
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/smith2.webp" style="vertical-align: middle" alt="" class="">
                        <span class="inactive">Demirci (10)</span>
                    </span>
                                        </span>
                                                <span></span>
                                </div>
            </td>
        </tr>
                <tr>
            <td>
                <a href="/game.php?village=12218&amp;screen=snob"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/snob1.webp" class="bmain_list_img" data-title="Akademi"></a>
                <a href="/game.php?village=12218&amp;screen=snob">Akademi</a>
            </td>
            <td>
                <div class="unmet_req">
                                    <span>
                                        <span>
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/main3.webp" style="vertical-align: middle" alt="" class="">
                        <span class="inactive">Ana bina (20)</span>
                    </span>
                                        </span>
                                    <span>
                                        <span>
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/smith3.webp" style="vertical-align: middle" alt="" class="">
                        <span class="inactive">Demirci (20)</span>
                    </span>
                                        </span>
                                    <span>
                                        <span>
                        <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/market2.webp" style="vertical-align: middle" alt="" class="">
                        <span class="inactive">Pazar (10)</span>
                    </span>
                                        </span>
                                                </div>
            </td>
        </tr>
            </tbody></table>
    <br>
    </div>
<script>
    BuildingMain.init();
</script>
<form action="/game.php?village=12218&amp;screen=main&amp;action=change_name" method="post">
<table class="vis">
<tbody><tr><th colspan="3">Köy adını değiştir</th></tr>
<tr><td><input type="text" name="name" value="Köy 1" maxlength="32" size="32"></td><td><input type="submit" class="btn" value="Değiştir"></td></tr>
</tbody></table>
<input type="hidden" name="h" value="58fce238"></form>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
```

---

## ✅ 4. KIŞLA (BARRACKS/TRAIN)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=barracks`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Asker basma formu var mı?
- [ ] `input[name='spear']` gibi input'lar var mı?
- [ ] Eğitim kuyruğu görünüyor mu?
- [ ] "Eğit" butonu var mı?

**Lütfen ver:**
```
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/barracks2.webp" class="" data-title="Kışla"></td>
		<td valign="top" width="100%">
			<h2>Kışla (seviye 5)</h2>
			Kışlada piyade üretebilirsin. Kışlanın seviyesi ne kadar yüksekse birliklerini o kadar hızlı üretebilirsin.
		</td>
	</tr>
</tbody></table>




<table class="vis">
	<tbody><tr>
		<td class="selected"><a href="/game.php?village=12218&amp;screen=barracks&amp;mode=train">Asker toplama</a></td>
		<td><a href="/game.php?village=12218&amp;screen=barracks&amp;mode=decommission">Açığa alma</a></td>	</tr>
</tbody></table>
<div class="current_prod_wrapper">
					
	<div id="replace_barracks">
				<table class="vis">
		<tbody><tr>
            <th class="nowrap">Bir sonraki birimin tamamlanması (Kılıç ustası):</th>
			<th><span class="">0:06:38</span></th>
		</tr>
		</tbody></table>
		
		<div class="trainqueue_wrap" id="trainqueue_wrap_barracks">
			<table class="vis" style="width: 100%">
				<tbody><tr>
					<th style="width: 25%">Eğitim</th>
					<th>Süre</th>
					<th>Tamamlanma</th>
                    <th style="width: 150px">İptal *</th>
									</tr>
	
								<tr class="lit">
					<td class="lit-item">
						<div class="unit_sprite unit_sprite_smaller sword"></div>
						6 Kılıç ustası
					</td>
					<td class="lit-item"><span class="">1:08:55</span></td>
					<td class="lit-item">bugün saat 21:40:24</td>
					<td class="lit-item"><a class="btn btn-cancel" onclick="return TrainOverview.cancelOrder(168584)" href="/game.php?village=12218&amp;screen=barracks&amp;action=cancel&amp;id=168584&amp;h=58fce238">İptal et</a></td>
									</tr>
	
								</tbody><tbody id="trainqueue_barracks" class="ui-sortable">
		
						
						
				</tbody>
	
			</table>
		</div>
        <div style="font-size: 7pt;">
                            * (harcanan hammaddenin 90%'ı depona iade edilir)                    </div>
		<br>

				<script type="text/javascript">
			//<![CDATA[
			init_trainqueue('barracks', '/game.php?village=12218&screen=barracks&ajaxaction=trainorder_reorder&h=58fce238');
				//]]>
		</script>
			</div>
</div><form action="/game.php?village=12218&amp;screen=barracks&amp;action=train&amp;mode=train" id="train_form" method="post">
	<table class="vis" style="width: 100%">
		<tbody><tr>
			<th style="width: 20%">Birim</th>
			<th style="min-width: 400px">İhtiyaç</th>
			<th>Köyde/toplam</th>
			<th style="width: 120px">Asker topla</th>
		</tr>

						<tr class="row_a">
			<td class="nowrap">
				<a href="#" class="unit_link" data-unit="spear">
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/spear.webp" style="vertical-align: middle" alt="" class="">
					Mızrakçı
				</a>
			</td>
			<td>
				<div class="recruit_req">
                    <span><span class="icon header wood"> </span><span id="spear_0_cost_wood">50</span></span>
                    <span><span class="icon header stone"> </span><span id="spear_0_cost_stone">30</span></span>
                    <span><span class="icon header iron"> </span><span id="spear_0_cost_iron">10</span></span>
				<span><span class="icon header population"> </span><span id="spear_0_cost_pop">1</span></span>
				<span><span class="icon header time"></span><span id="spear_0_cost_time">0:08:29</span></span>
				</div>
			</td>
			<td style="text-align: center">230/230</td>
            <td>
                <span id="spear_0_interaction">
                    <input name="spear" value="" class="recruit_unit" id="spear_0" type="text" style="width: 50px; color: black;" maxlength="5" tabindex="1">
                    <a id="spear_0_a" href="javascript:unit_build_block.set_max('spear')">(6)</a>
                </span>
                <span id="spear_0_afford_hint" class="inactive" style="text-align: center; font-size: 11px; display:none;">
                    
                </span>
                            </td>
		</tr>
															<tr class="row_a">
			<td class="nowrap">
				<a href="#" class="unit_link" data-unit="sword">
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/sword.webp" style="vertical-align: middle" alt="" class="">
					Kılıç ustası
				</a>
			</td>
			<td>
				<div class="recruit_req">
                    <span><span class="icon header wood"> </span><span id="sword_0_cost_wood">30</span></span>
                    <span><span class="icon header stone"> </span><span id="sword_0_cost_stone">30</span></span>
                    <span><span class="icon header iron"> </span><span id="sword_0_cost_iron">70</span></span>
				<span><span class="icon header population"> </span><span id="sword_0_cost_pop">1</span></span>
				<span><span class="icon header time"></span><span id="sword_0_cost_time">0:12:28</span></span>
				</div>
			</td>
			<td style="text-align: center">98/98</td>
            <td>
                <span id="sword_0_interaction">
                    <input name="sword" value="" class="recruit_unit" id="sword_0" type="text" style="width: 50px; color: black;" maxlength="5" tabindex="2">
                    <a id="sword_0_a" href="javascript:unit_build_block.set_max('sword')">(11)</a>
                </span>
                <span id="sword_0_afford_hint" class="inactive" style="text-align: center; font-size: 11px; display:none;">
                    
                </span>
                            </td>
		</tr>
															<tr class="row_a">
			<td class="nowrap">
				<a href="#" class="unit_link" data-unit="axe">
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/axe.webp" style="vertical-align: middle" alt="" class="">
					Baltacı
				</a>
			</td>
			<td>
				<div class="recruit_req">
                    <span><span class="icon header wood"> </span><span id="axe_0_cost_wood">60</span></span>
                    <span><span class="icon header stone"> </span><span id="axe_0_cost_stone">30</span></span>
                    <span><span class="icon header iron"> </span><span id="axe_0_cost_iron">40</span></span>
				<span><span class="icon header population"> </span><span id="axe_0_cost_pop">1</span></span>
				<span><span class="icon header time"></span><span id="axe_0_cost_time">0:10:58</span></span>
				</div>
			</td>
			<td style="text-align: center">2/2</td>
            <td>
                <span id="axe_0_interaction">
                    <input name="axe" value="" class="recruit_unit" id="axe_0" type="text" style="width: 50px; color: black;" maxlength="5" tabindex="3">
                    <a id="axe_0_a" href="javascript:unit_build_block.set_max('axe')">(5)</a>
                </span>
                <span id="axe_0_afford_hint" class="inactive" style="text-align: center; font-size: 11px; display:none;">
                    
                </span>
                            </td>
		</tr>
													<tr>
			<td colspan="3">
			</td>
			<td>
				<input class="btn btn-recruit" style="float: inherit" type="submit" value="Asker topla" tabindex="4">
			</td>
		</tr>
	</tbody></table>
<input type="hidden" name="h" value="58fce238"></form>
<br>


<script type="text/javascript">
//<![CDATA[
	$(document).ready(function(){
		TrainOverview.init();
		TrainOverview.init_res_schedule(1768411877110, {"schedules":{"wood":{"1768411188":"0.055341511957154","1770799517":"0.046557144979828"},"stone":{"1768411188":"0.055341511957154","1770799519":"0.046557144979828"},"iron":{"1768411188":"0.040907546663522","1770799523":"0.03441428528836"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411188,1770799517],"stone":[1768411188,1770799519],"iron":[1768411188,1770799523]}}, {"schedules":{"wood":{"1768411178":"302.77550738649","1770799517":"132477.06683362"},"stone":{"1768411178":"3812.7755073865","1770799519":"135987.17751665"},"iron":{"1768411178":"1437.9340788928","1770799523":"99139.268614982"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411178,1770799517],"stone":[1768411178,1770799519],"iron":[1768411178,1770799523]},"values":{"wood":["302.77550738649","132477.06683362"],"stone":["3812.7755073865","135987.17751665"],"iron":["1437.9340788928","99139.268614982"]},"next_timestamps":{"wood":{"1768411178":1770799517},"stone":{"1768411178":1770799519},"iron":{"1768411178":1770799523}},"schedules_flipped":{"wood":{"302.77550738649":1768411178,"132477.06683362":1770799517},"stone":{"3812.7755073865":1768411178,"135987.17751665":1770799519},"iron":{"1437.9340788928":1768411178,"99139.268614982":1770799523}}});
        TrainOverview.initSingleVillageMode();

		TrainOverview.train_link = "\/game.php?village=12218&screen=barracks&ajaxaction=train&mode=train&h=58fce238";
		TrainOverview.cancel_link = "\/game.php?village=12218&screen=barracks&ajaxaction=cancel&h=58fce238";
		TrainOverview.cancel_all_link = "\/game.php?village=12218&screen=barracks&action=cancel_all&h=58fce238";
		TrainOverview.pop_max = 854;
	});

	unit_managers = { };
	unit_managers.units = {
		            spear: {
    wood: 50,
    stone: 30,
    iron: 10,
                pop: 1,
                build_time: 508.13555754892,
                requirements_met: true                }
            ,		            sword: {
    wood: 30,
    stone: 30,
    iron: 70,
                pop: 1,
                build_time: 747.25817286606,
                requirements_met: true                }
            ,		            axe: {
    wood: 60,
    stone: 30,
    iron: 40,
                pop: 1,
                build_time: 657.58719212213,
                requirements_met: true                }
            			};
	var unit_build_block = new UnitBuildManager(0, {
		res: {
						wood: 341,						stone: 3851,						iron: 1467,						pop: 230					}
	});

    // in case of partial reload, wait for inputs to be restored first
    setTimeout(function() {
        unit_build_block._onchange();
    }, 1);

//]]>
</script>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>
```

---

## ✅ 5. AHIR (STABLE)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=stable`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Süvari basma formu var mı?
- [ ] `input[name='light']`, `input[name='heavy']` var mı?

**Lütfen ver:**
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/stable1.webp" class="" data-title="Ahır"></td>
		<td valign="top" width="100%">
			<h2>Ahır (seviye 3)</h2>
			Ahırda atlıları yetiştirebilirsin. Ahırının seviyesi ne kadar yüksek olursa, o kadar hızlı birlik yetiştirebilirsin.
		</td>
	</tr>
</tbody></table>




<table class="vis">
	<tbody><tr>
		<td class="selected"><a href="/game.php?village=12218&amp;screen=stable&amp;mode=train">Asker toplama</a></td>
		<td><a href="/game.php?village=12218&amp;screen=stable&amp;mode=decommission">Açığa alma</a></td>	</tr>
</tbody></table>

<table class="vis" style="width: 100%">
	<tbody><tr>
		<th style="width: 25%">Henüz yok</th>
		<th>İhtiyaç</th>
	</tr>
			<tr style="line-height: 30px">
		<td>
			<a href="#" class="unit_link" data-unit="spy">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/grey/spy.webp" style="opacity: 0.7; vertical-align: middle" alt="" class="">
				Casus
			</a>
		</td>
		<td>
			<div class="unmet_req float_left" style="width: 400px">
							<span>
								<span>
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/stable1.webp" style="vertical-align: middle" alt="" class="">
					<span>Ahır (Seviye 1)</span>
				</span>
								</span>
						</div>

							<span class="float_right" style="margin-right: 5px"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/overview/research.webp" style="vertical-align: middle" alt="" class="">&nbsp;<a href="/game.php?village=12218&amp;screen=smith" style="float: right">Araştırma</a></span>
					</td>
	</tr>
				<tr style="line-height: 30px">
		<td>
			<a href="#" class="unit_link" data-unit="light">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/grey/light.webp" style="opacity: 0.7; vertical-align: middle" alt="" class="">
				Hafif atlı
			</a>
		</td>
		<td>
			<div class="unmet_req float_left" style="width: 400px">
							<span>
								<span>
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/stable1.webp" style="vertical-align: middle" alt="" class="">
					<span>Ahır (Seviye 3)</span>
				</span>
								</span>
						</div>

							<span class="float_right" style="margin-right: 5px"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/overview/research.webp" style="vertical-align: middle" alt="" class="">&nbsp;<a href="/game.php?village=12218&amp;screen=smith" style="float: right">Araştırma</a></span>
					</td>
	</tr>
				<tr style="line-height: 30px">
		<td>
			<a href="#" class="unit_link" data-unit="heavy">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/recruit/grey/heavy.webp" style="opacity: 0.7; vertical-align: middle" alt="" class="">
				Ağır atlı
			</a>
		</td>
		<td>
			<div class="unmet_req float_left" style="width: 400px">
							<span>
								<span>
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/stable3.webp" style="vertical-align: middle" alt="" class="">
					<span class="inactive">Ahır (Seviye 10)</span>
				</span>
								</span>
							<span>
								<span>
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/grey/smith3.webp" style="vertical-align: middle" alt="" class="">
					<span class="inactive">Demirci (Seviye 15)</span>
				</span>
								</span>
						</div>

					</td>
	</tr>
			</tbody></table>

<script type="text/javascript">
//<![CDATA[
	$(document).ready(function(){
		TrainOverview.init();
		TrainOverview.init_res_schedule(1768411906618, {"schedules":{"wood":{"1768411188":"0.055341511957154","1770799517":"0.046557144979828"},"stone":{"1768411188":"0.055341511957154","1770799519":"0.046557144979828"},"iron":{"1768411188":"0.040907546663522","1770799523":"0.03441428528836"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411188,1770799517],"stone":[1768411188,1770799519],"iron":[1768411188,1770799523]}}, {"schedules":{"wood":{"1768411178":"302.77550738649","1770799517":"132477.06683362"},"stone":{"1768411178":"3812.7755073865","1770799519":"135987.17751665"},"iron":{"1768411178":"1437.9340788928","1770799523":"99139.268614982"}},"items_count":{"wood":2,"stone":2,"iron":2},"timestamps":{"wood":[1768411178,1770799517],"stone":[1768411178,1770799519],"iron":[1768411178,1770799523]},"values":{"wood":["302.77550738649","132477.06683362"],"stone":["3812.7755073865","135987.17751665"],"iron":["1437.9340788928","99139.268614982"]},"next_timestamps":{"wood":{"1768411178":1770799517},"stone":{"1768411178":1770799519},"iron":{"1768411178":1770799523}},"schedules_flipped":{"wood":{"302.77550738649":1768411178,"132477.06683362":1770799517},"stone":{"3812.7755073865":1768411178,"135987.17751665":1770799519},"iron":{"1437.9340788928":1768411178,"99139.268614982":1770799523}}});
        TrainOverview.initSingleVillageMode();

		TrainOverview.train_link = "\/game.php?village=12218&screen=stable&ajaxaction=train&mode=train&h=58fce238";
		TrainOverview.cancel_link = "\/game.php?village=12218&screen=stable&ajaxaction=cancel&h=58fce238";
		TrainOverview.cancel_all_link = "\/game.php?village=12218&screen=stable&action=cancel_all&h=58fce238";
		TrainOverview.pop_max = 854;
	});

	unit_managers = { };
	unit_managers.units = {
		            spy: {
    wood: 50,
    stone: 50,
    iron: 20,
                pop: 2,
                build_time: 503.77156981938,
                requirements_met: false                }
            ,		            light: {
    wood: 125,
    stone: 100,
    iron: 250,
                pop: 4,
                build_time: 1007.5431396388,
                requirements_met: false                }
            ,		            heavy: {
    wood: 200,
    stone: 150,
    iron: 600,
                pop: 6,
                build_time: 2015.0862792775,
                requirements_met: false                }
            			};
	var unit_build_block = new UnitBuildManager(0, {
		res: {
						wood: 343,						stone: 3853,						iron: 1468,						pop: 230					}
	});

    // in case of partial reload, wait for inputs to be restored first
    setTimeout(function() {
        unit_build_block._onchange();
    }, 1);

//]]>
</script>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>

---

## ✅ 6. PAZAR (MARKET)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=market&mode=send`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Müsait tüccar sayısı görünüyor mu?
- [ ] Kaynak gönderme formu var mı?
- [ ] `input[name='wood']`, `input[name='stone']`, `input[name='iron']` var mı?

**Lütfen ver:**
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/market2.webp" class="" data-title="Pazar"></td>
		<td valign="top" width="100%">
			<h2>Pazar (seviye 5)</h2>
			Pazar yerinde başka oyuncularla ticaret yapabilir ya da onlara hammadde gönderebilirsin.
		</td>
	</tr>
</tbody></table>

<script type="text/javascript">
    var Data = {
        Trader : {
            carry: 1000,
            amount: 5,
            total: 5,
            capacity : function () {
                return Data.Trader.carry * Data.Trader.amount;
            }
        },

        Res : {
            wood: 0,
            stone: 0,
            iron: 0
        }
    };

    $(document).ready(function() {
        Market.init(Data, 'other_offer');
    });
</script>
<table>
	<tbody><tr>
		<td valign="top">
			<table class="vis modemenu">
                                    <tbody><tr id="id_other_offer"><td class="selected" style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=other_offer">Ticaret </a></td></tr>
                                    <tr id="id_exchange"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=exchange">Premium Takası </a></td></tr>
                                    <tr id="id_own_offer"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=own_offer">Teklif oluştur </a></td></tr>
                                    <tr id="id_mass_create_offers"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=mass_create_offers">Çoklu teklif oluştur </a></td></tr>
                                    <tr id="id_send"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=send">Hammadde gönder </a></td></tr>
                                    <tr id="id_transports"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=transports">Nakliyatlar </a></td></tr>
                                    <tr id="id_traders"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=traders">Tüccar durumu </a></td></tr>
                                    <tr id="id_all_own_offer"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=all_own_offer">Tüm tekliflerin </a></td></tr>
                                    <tr id="id_call"><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=market&amp;mode=call">İstek </a></td></tr>
                			</tbody></table>
		</td>
		<td valign="top">
<div id="market_status_bar">
	<table class="vis">
		<tbody><tr>
			<th>Tüccar: <span id="market_merchant_available_count">5</span>/<span id="market_merchant_total_count">5</span></th>
			<th>Azami transfer miktarı: <span id="market_merchant_max_transport">5000</span></th>
					</tr>
	</tbody></table>

	</div>
<h3>Teklif bul</h3>
<form id="offer_filter" action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=search" method="post">

    <input id="order_by" type="hidden" name="order_by" value="trader_time">
    <input id="toggle_dir" type="hidden" name="toggle_dir" value="0">
    <input type="hidden" name="swap" value="0">

    <!-- resource selection -->
            <!-- desktop -->
        <table class="vis">
            <tbody><tr>
                <th>Talebim:</th>
                <td>
                    <table id="selection_sell">
                        <tbody><tr>
                            <td><label><input type="radio" name="res_sell" value="all" onclick="Market.Modes.other_offer.lockBuy();" checked="checked">hepsi</label></td>
                            <td><label><input type="radio" name="res_sell" value="wood" onclick="Market.Modes.other_offer.lockBuy('wood');"><span class="icon header wood" data-title="Odun"></span></label></td>
                            <td><label><input type="radio" name="res_sell" value="stone" onclick="Market.Modes.other_offer.lockBuy('stone');"><span class="icon header stone" data-title="Kil"></span></label></td>
                            <td><label><input type="radio" name="res_sell" value="iron" onclick="Market.Modes.other_offer.lockBuy('iron');"><span class="icon header iron" data-title="Demir"></span></label></td>
                        </tr>
                    </tbody></table>
                </td>
                            </tr>
            <tr>
                <th>Teklifim:</th>
                <td>
                    <table id="selection_buy">
                        <tbody><tr>
                            <td><label><input type="radio" name="res_buy" value="all" onclick="Market.Modes.other_offer.lockSell();" checked="checked">hepsi</label></td>
                            <td><label><input type="radio" name="res_buy" value="wood" onclick="Market.Modes.other_offer.lockSell('wood');"><span class="icon header wood" data-title="Odun"></span></label></td>
                            <td><label><input type="radio" name="res_buy" value="stone" onclick="Market.Modes.other_offer.lockSell('stone');"><span class="icon header stone" data-title="Kil"></span></label></td>
                            <td><label><input type="radio" name="res_buy" value="iron" onclick="Market.Modes.other_offer.lockSell('iron');"><span class="icon header iron" data-title="Demir"></span></label></td>
                        </tr>
                    </tbody></table>
                </td>
            </tr>
        </tbody></table>
    

    <br>
			<input type="hidden" name="ratio_max" value="1">
	    <table class="vis">
        <tbody><tr><th colspan="3">Sınırlandırmalar</th></tr>
        <tr style="vertical-align:top">
            <td>Süre:&nbsp;
                <select id="trader_time_max_hours" name="trader_time_max_hours">
                                            <option value="0.5">0.5 saat</option>
                                            <option value="1">1 saat</option>
                                            <option value="2">2 saat</option>
                                            <option value="3">3 saat</option>
                                            <option value="5">5 saat</option>
                                            <option value="10">10 saat</option>
                                            <option value="24" selected="">24 saat</option>
                                            <option value="48">48 saat</option>
                                            <option value="96">96 saat</option>
                                    </select>
            </td>
			            <td>
                <label for="offer_filter_select">Filtre:  </label>
                <select id="offer_filter_select" name="filter">
                    <option value="all" selected="">Tümünü göster</option>
                                            <option value="ally">Sadece klan</option>
                        <option value="ally_allies">Klan ve müttefikler</option>
                                        <option value="friends">Sadece arkadaşlar</option>
                    <option value="no_enemies">Düşmanları hariç</option>
                </select>
            </td>
        </tr>
    </tbody></table>
    <br>
<input type="hidden" name="h" value="58fce238"></form>
<table class="vis">
<tbody><tr>
			<th>Alacağın</th>
		<th>Vereceğin</th>
		<th>Oyuncu</th>
		<th><a href="#" onclick="Market.Modes.other_offer.sort('trader_time');">Süre</a></th>
		<th><a href="#" onclick="Market.Modes.other_offer.sort('ratio')">Oran</a></th>
		<th><a href="#" onclick="Market.Modes.other_offer.sort('count')">Mevcut</a></th>
					<th>Kabul et</th>
			</tr>

<!-- village merchant -->
                <!-- desktop -->
        <tr>
            <td class="nowrap">
                <span class="merchant_exchange_btn_choose" data-title="Lütfen bu değişimde almak istediğin hammaddeyi seç.">
                    <span class="icon header ressources"></span>
                </span>
                <span id="exchange_amount_buy">1000</span>
            </td>
            <td class="nowrap">
                <span class="merchant_exchange_btn_choose" data-title="Lütfen bu değişimde göndermek istediğin hammaddeyi seç.">
                    <span class="icon header ressources"></span>
                </span>
                <input id="exchange_amount_sell" type="text" name="sell" value="1000" size="6">
            </td>
            <td style="text-align:center;"><span class="icon header premium"></span>Tüccar</td>
            <td>Hemen</td>
            <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span>1</td>
            <td>Sınırsız</td>
            <td style="text-align:center;">
                <form id="merchant_exchange_form" action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=merchantexchange" method="post">
                                            <a id="merchant_exchange_btn_choose" class="btn merchant_exchange_btn_choose" href="#">Takas</a>
                                        <input name="res_buy" id="merchant_exchange_res_buy" type="hidden" value="all">
                    <input name="res_sell" id="merchant_exchange_res_sell" type="hidden" value="all">
                    <input name="sell" id="merchant_exchange_sell" type="hidden" value="1000">
                <input type="hidden" name="h" value="58fce238"></form>
            </td>
        </tr>
    
    <script type="text/javascript">
    //<![CDATA[
        $(document).ready(function() {
            MarketMerchantExchange.exchangeFactor = "1";
            MarketMerchantExchange.messages.confirm = "";
            MarketMerchantExchange.messages.nores = "Ticaret için hammadde seçmedin.";
            MarketMerchantExchange.res_wanted = "all";
            MarketMerchantExchange.res_offering = "all";
            MarketMerchantExchange.init();
        });
    //]]>
    </script>

<!-- other offers -->
    <!-- show offers -->
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>1<span class="grey">.</span>000</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header stone" data-title="Kil"> </span>1<span class="grey">.</span>000</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=5390589">PlayMaker34 [SNCK-E]</a></td>
                <td>0:43:40</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                    <form class="market_accept_offer " action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=accept_multi&amp;id=5267&amp;start=0" method="post" style="display: inline-block; min-width: 140px;">
                        <input type="hidden" name="id" value="5267">
                        <input class="btn float_right" type="submit" value="Kabul et" style="vertical-align:middle;">
                        <span>
                            <input type="text" name="count" style="width:30px; vertical-align:middle;" value="1" onclick="this.value=''">
                            <span>
                                (<a style="cursor: alias" href="#" onclick="$(this).parents('form').eq(0).find('input[name=count]').val(1); return false;">1</a>)
                            </span>
                        </span>
                    <input type="hidden" name="h" value="58fce238"></form>
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>500</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>500</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=848980436">serkan37370 [SNCK-E]</a></td>
                <td>1:23:34</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>500</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header stone" data-title="Kil"> </span>500</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=849069564">rhm20 [SNCK]</a></td>
                <td>1:42:10</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                    <form class="market_accept_offer " action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=accept_multi&amp;id=5483&amp;start=0" method="post" style="display: inline-block; min-width: 140px;">
                        <input type="hidden" name="id" value="5483">
                        <input class="btn float_right" type="submit" value="Kabul et" style="vertical-align:middle;">
                        <span>
                            <input type="text" name="count" style="width:30px; vertical-align:middle;" value="1" onclick="this.value=''">
                            <span>
                                (<a style="cursor: alias" href="#" onclick="$(this).parents('form').eq(0).find('input[name=count]').val(1); return false;">1</a>)
                            </span>
                        </span>
                    <input type="hidden" name="h" value="58fce238"></form>
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header stone" data-title="Kil"> </span>300</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>300</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=849068207">M.T. [SNCK]</a></td>
                <td>1:56:29</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                    <form class="market_accept_offer " action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=accept_multi&amp;id=5230&amp;start=0" method="post" style="display: inline-block; min-width: 140px;">
                        <input type="hidden" name="id" value="5230">
                        <input class="btn float_right" type="submit" value="Kabul et" style="vertical-align:middle;">
                        <span>
                            <input type="text" name="count" style="width:30px; vertical-align:middle;" value="1" onclick="this.value=''">
                            <span>
                                (<a style="cursor: alias" href="#" onclick="$(this).parents('form').eq(0).find('input[name=count]').val(1); return false;">1</a>)
                            </span>
                        </span>
                    <input type="hidden" name="h" value="58fce238"></form>
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header stone" data-title="Kil"> </span>400</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>400</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=5320785">ozgurruh4141 [MHT]</a></td>
                <td>2:14:49</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>750</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>750</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=849060147">EAGLE 1903 [ZIRH]</a></td>
                <td>2:25:07</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>1<span class="grey">.</span>000</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>1<span class="grey">.</span>000</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=848921648">Dieqo [METEO2]</a></td>
                <td>3:03:10</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>1<span class="grey">.</span>000</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>1<span class="grey">.</span>000</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=848942706">milagro [Nam]</a></td>
                <td>3:10:40</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header stone" data-title="Kil"> </span>500</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>500</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=849063335">MaxWeLL [METEO2]</a></td>
                <td>3:12:22</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>1 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    
        <!-- insert the offer -->
        <tr>
                                            <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header iron" data-title="Demir"> </span>1<span class="grey">.</span>000</span> </td>
                <td style="white-space:nowrap;"><span class="nowrap"><span class="icon header wood" data-title="Odun"> </span>1<span class="grey">.</span>000</span> </td>
                <td><a href="/game.php?village=12218&amp;screen=info_player&amp;id=848927398">mkaanoguz [METEO2]</a></td>
                <td>4:41:44</td>
                <td style="background-color: rgb(255, 255, 100); text-align:center;"><span class="icon header scale"></span> 1</td>
                <td>3 Teklif</td>
            
                        <td>
                                                                        Yeterli hammadde yok
                            </td>
        </tr>
    </tbody></table>

    <form action="/game.php?village=12218&amp;screen=market&amp;mode=other_offer&amp;action=change_other_offer_pagesize" method="post">
        <table class="vis">
            <tbody><tr><th colspan="2">Sayfa başına teklif:</th><td><input name="page_size" type="text" style="width: 50px" value="100"></td><td><input class="btn" type="submit" value="Kaydet"></td></tr>
        </tbody></table>
    <input type="hidden" name="h" value="58fce238"></form>
</td></tr></tbody></table>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>

## ✅ 7. AKADEMİ - ALTIN BASMA (SNOB/COIN)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=snob&mode=coin`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Altın basma formu var mı?
- [ ] Maksimum altın sayısı görünüyor mu?
- [ ] `#coin_mint_fill_max` elementi var mı?

**Lütfen ver:**
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/snob1.webp" class="" data-title="Akademi"></td>
		<td valign="top" width="100%">
			<h2>Akademi (mevcut değil)</h2>
			Akademi sayesinde misyoner üretebilir ve sadakatlerini düşürerek köyler fethedebilirsiniz.
		</td>
	</tr>
</tbody></table>

<table class="vis tall">
	<tbody><tr>
		<th>Önkoşullar:</th>
	</tr>
		<tr>
		<td class="nowrap">
			<a href="/game.php?village=12218&amp;screen=main"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/main3.webp" style="float: left; margin-right: 8px" alt="" class=""></a>
			<a href="/game.php?village=12218&amp;screen=main">Ana bina</a> (Seviye 20)		</td>
	</tr>
		<tr>
		<td class="nowrap">
			<a href="/game.php?village=12218&amp;screen=smith"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/smith3.webp" style="float: left; margin-right: 8px" alt="" class=""></a>
			<a href="/game.php?village=12218&amp;screen=smith">Demirci</a> (Seviye 20)		</td>
	</tr>
		<tr>
		<td class="nowrap">
			<a href="/game.php?village=12218&amp;screen=market"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/mid/market2.webp" style="float: left; margin-right: 8px" alt="" class=""></a>
			<a href="/game.php?village=12218&amp;screen=market">Pazar</a> (Seviye 10)		</td>
	</tr>
		
</tbody></table>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>

---

## ✅ 8. AKADEMİ - MİSYONER (SNOB/TRAIN)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=snob&mode=train`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Misyoner basma formu var mı?
- [ ] `input[name='snob']` var mı?

**Lütfen ver:**
```
1. Tam URL:
2. Misyoner basma formunun HTML'i:
```

---

## ✅ 9. DEMİRCİ (SMITH)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=smith`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Asker geliştirme listesi var mı?
- [ ] Mevcut seviyeler görünüyor mu?

**Lütfen ver:**
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <table width="100%">
	<tbody><tr>
		<td valign="top"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/big_buildings/smith2.webp" class="" data-title="Demirci"></td>
		<td valign="top" width="100%">
			<h2>Demirci (seviye 5)</h2>
			Demircide yeni silahlar araştırabilir ve geliştirebilirsin. Demircinin seviyesi ne kadar yüksekse o kadar iyi silahlar geliştirir ve o derece kısa sürede araştırma yaparsın.
		</td>
	</tr>
</tbody></table>

<script type="text/javascript">
//<![CDATA[
	BuildingSmith.link_research = "\/game.php?village=12218&screen=smith&ajaxaction=research&h=58fce238";
	BuildingSmith.link_cancel = "\/game.php?village=12218&screen=smith&ajaxaction=cancel&h=58fce238";
	BuildingSmith.link_remove = "\/game.php?village=12218&screen=smith&ajaxaction=remove&h=58fce238";
//]]>
</script>

<div id="tech_list">

    <table class="vis" width="100%">
        <tbody><tr><th width="33%">Piyade</th><th width="33%">Atlılar</th><th width="33%">Kuşatma silahları</th></tr>

                <tr>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite spear" data-unit="spear"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="spear">Mızrakçı</a>
		
			<br>
			                                    <span class="inactive">Araştırıldı</span>
                					</td>
	</tr>
</tbody></table>
</td>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite spy_grey" data-unit="spy"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="spy">Casus</a>
		
			<br>
											    <span class="nowrap warn" id="spy_cost_wood"><span class="icon header wood"> </span>560</span>
                    <span class="nowrap" id="spy_cost_stone"><span class="icon header stone"> </span>480</span>
                    <span class="nowrap" id="spy_cost_iron"><span class="icon header iron"> </span>480</span>
				    <br>
													<span class="inactive">Mevcut hammaddeler bugün saat 21:37</span>
									</td>
	</tr>
</tbody></table>
</td>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite ram_cross" data-unit="ram"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="ram">Koçbaşı</a>
		
			<br>
							<span class="inactive">
                    <div>Karşılanmayan koşullar:</div>
                                                                        Atölye (1)<br>
                                            				</span>
					</td>
	</tr>
</tbody></table>
</td>
        </tr>
                <tr>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite sword" data-unit="sword"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="sword">Kılıç ustası</a>
		
			<br>
			                                    <span class="inactive">Araştırıldı</span>
                					</td>
	</tr>
</tbody></table>
</td>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite light_grey" data-unit="light"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="light">Hafif atlı</a>
		
			<br>
											    <span class="nowrap warn" id="light_cost_wood"><span class="icon header wood"> </span>2<span class="grey">.</span>200</span>
                    <span class="nowrap" id="light_cost_stone"><span class="icon header stone"> </span>2<span class="grey">.</span>400</span>
                    <span class="nowrap warn" id="light_cost_iron"><span class="icon header iron"> </span>2<span class="grey">.</span>000</span>
				    <br>
													<span class="inactive">Mevcut hammaddeler yarın şu saatte 05:51</span>
									</td>
	</tr>
</tbody></table>
</td>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite catapult_cross" data-unit="catapult"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="catapult">Mancınık</a>
		
			<br>
							<span class="inactive">
                    <div>Karşılanmayan koşullar:</div>
                                                                        Atölye (2)<br>
                                                                                                Demirci (12)<br>
                                            				</span>
					</td>
	</tr>
</tbody></table>
</td>
        </tr>
                <tr>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite axe" data-unit="axe"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="axe">Baltacı</a>
		
			<br>
			                                    <span class="inactive">Araştırıldı</span>
                					</td>
	</tr>
</tbody></table>
</td>
            <td>
<table class="vis">
	<tbody><tr>
		<td>
			<a href="#" class="unit_link unit_sprite heavy_cross" data-unit="heavy"></a>
		</td>
		<td valign="top" style="line-height: 24px">
			<a href="#" class="unit_link" data-unit="heavy">Ağır atlı</a>
		
			<br>
							<span class="inactive">
                    <div>Karşılanmayan koşullar:</div>
                                                                        Ahır (10)<br>
                                                                                                Demirci (15)<br>
                                            				</span>
					</td>
	</tr>
</tbody></table>
</td>
                    </tr>
                <tr>
                                            </tr>
        
    </tbody></table><br>

    <script>
        $(function() {
            BuildingSmith.techs = {"available":{"spear":{"id":"spear","name":"M\u0131zrak\u00e7\u0131","level":"1","level_after":1,"level_highest":1,"downgrades":0,"error_level":true,"image_state":"spear","image":"unit_big\/spear.png"},"sword":{"id":"sword","name":"K\u0131l\u0131\u00e7 ustas\u0131","level":"1","level_after":1,"level_highest":1,"downgrades":0,"error_level":true,"image_state":"sword","image":"unit_big\/sword.png"},"axe":{"id":"axe","name":"Baltac\u0131","level":"1","level_after":1,"level_highest":1,"downgrades":0,"error_level":true,"image_state":"axe","image":"unit_big\/axe.png"},"spy":{"id":"spy","name":"Casus","level":"0","level_after":0,"level_highest":0,"downgrades":0,"wood":560,"stone":480,"iron":480,"research_time":"0:40:58","research_error":"Mevcut hammaddeler bug\u00fcn saat 21:37","can_research":true,"image_state":"spy_grey","image":"unit_big\/spy_grey.png"},"light":{"id":"light","name":"Hafif atl\u0131","level":"0","level_after":0,"level_highest":0,"downgrades":0,"wood":2200,"stone":2400,"iron":2000,"research_time":"1:32:12","research_error":"Mevcut hammaddeler yar\u0131n \u015fu saatte 05:51","can_research":true,"image_state":"light_grey","image":"unit_big\/light_grey.png"},"heavy":{"id":"heavy","name":"A\u011f\u0131r atl\u0131","level":"0","level_after":0,"level_highest":0,"downgrades":0,"error_buildings":true,"require":{"stable":{"level":10,"name":"Ah\u0131r","image":"buildings\/stable.png","big_image":"stable3","met":false},"smith":{"level":15,"name":"Demirci","image":"buildings\/smith.png","big_image":"smith3","met":false}},"image_state":"heavy_cross","image":"unit_big\/heavy_cross.png"},"ram":{"id":"ram","name":"Ko\u00e7ba\u015f\u0131","level":"0","level_after":0,"level_highest":0,"downgrades":0,"error_buildings":true,"require":{"garage":{"level":1,"name":"At\u00f6lye","image":"buildings\/garage.png","big_image":"garage1","met":false}},"image_state":"ram_cross","image":"unit_big\/ram_cross.png"},"catapult":{"id":"catapult","name":"Manc\u0131n\u0131k","level":"0","level_after":0,"level_highest":0,"downgrades":0,"error_buildings":true,"require":{"garage":{"level":2,"name":"At\u00f6lye","image":"buildings\/garage.png","big_image":"garage1","met":false},"smith":{"level":12,"name":"Demirci","image":"buildings\/smith.png","big_image":"smith2","met":false}},"image_state":"catapult_cross","image":"unit_big\/catapult_cross.png"}},"unavailable":[]};
            BuildingSmith.init();
        });
    </script>
</div>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>

## ✅ 10. RAPORLAR (REPORT)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=report&mode=all`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Rapor listesi görünüyor mu?
- [ ] `.report-link` class'ı var mı?
- [ ] Okunmamış raporlar işaretli mi? (`.unread`)

**Lütfen ver:**
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <h2>Raporlar</h2>


<table class="no_spacing" width="100%"><tbody><tr><td valign="top">
<table class="vis modemenu" width="100">
	<tbody><tr><td class="selected" style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=all">Hepsi </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=attack">Saldırılar </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=defense">Savunmalar </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=support">Destekler </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=trade">Ticaret </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=event">Etkinlikler </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=other">Diğer </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=forwarded">İletilenler </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=public">Açık </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=filter">Filtre </a></td></tr>
	<tr><td style="min-width: 80px"><a href="/game.php?village=12218&amp;screen=report&amp;mode=groups">Klasör </a></td></tr>
</tbody></table>
</td><td valign="top" width="100%">
<script type="text/javascript">
//<![CDATA[
	$(function(){
		JToggler.init('#report_list input[type="checkbox"]');
	});
//]]>
</script>
<table class="vis" width="100%">

	<tbody><tr>
		            <td style="width: 40px; text-align: center">
                 <a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=-1">[Hepsi]</a> 
            </td>
		
		<td align="center" colspan="2">
			 <strong>&gt;Yeni raporlar &lt; </strong>  <a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=6969">[Arşiv]</a>  <a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=9265">[Yağma Asistanı]</a> 
		</td>

		            <td width="140">
                <a href="/game.php?village=12218&amp;screen=report&amp;mode=groups">» Klasör oluştur</a>
            </td>
			</tr>

	<tr>
		<td align="center" colspan="4">
			<strong> &gt;1&lt; </strong><a class="paged-nav-item" href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;from=12"> [2] </a><a class="paged-nav-item" href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;from=24"> [3] </a>
		</td>
	</tr>

<tr class="report_filter">
	<td colspan="4">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_subject">
			<label for="filter_subject">Rapor ismine göre sırala: </label><input type="text" id="filter_subject" name="filter_subject" value="">
			<input class="btn" type="submit" value="Filtre">
		<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>
<tr class="report_filter">
	<td colspan="4">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_current_village">
			<input type="checkbox" name="filter_current_village" id="filter_current_village" onchange="this.form.submit()"><label for="filter_current_village">Yalnızca bu köye ait raporları göster</label>
		<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>
<tr class="report_filter">
	<td colspan="4">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_max_loot">
			<input type="checkbox" name="filter_max_loot" id="filter_max_loot" onchange="this.form.submit()"><label for="filter_max_loot">Yalnızca maksimum ganimeti göster</label>
		<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>
<tr class="report_filter">
	<td colspan="4">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_own_reports">
			<input type="checkbox" name="filter_own_reports" id="filter_own_reports" onchange="this.form.submit()"><label for="filter_own_reports">Sadece kendi raporlarını göster</label>
		<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>
<tr class="report_filter">
	<td colspan="2" style="vertical-align: top;">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_dots" id="battle_filter_form">
            <h5>Savaş sonucuna göre sırala: </h5>
			<div class="filter-row">
				<input type="checkbox" class="report-filter-checkbox" name="filter_dots[4]" value="4" id="filter_dots_blue">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/blue.webp" class="" data-title="">
				<label for="filter_dots_blue">Casuslandı</label>
			</div>

			<div class="filter-row">
				<input type="checkbox" class="report-filter-checkbox" name="filter_dots[1]" value="1" id="filter_dots_green">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/green.webp" class="" data-title="">
				<label for="filter_dots_green">Tam zafer</label>
			</div>

			<div class="filter-row">
				<input type="checkbox" class="report-filter-checkbox" name="filter_dots[2]" value="2" id="filter_dots_yellow">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/yellow.webp" class="" data-title="">
				<label for="filter_dots_yellow">Kayıplar</label>
			</div>

			<div class="filter-row">
				<input type="checkbox" class="report-filter-checkbox" name="filter_dots[5]" value="5" id="filter_dots_red_yellow">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/red_yellow.webp" class="" data-title="">
				<label for="filter_dots_red_yellow">Yenilgi, ama binalara zarar verildi</label>
			</div>

			<div class="filter-row">
				<input type="checkbox" class="report-filter-checkbox" name="filter_dots[6]" value="6" id="filter_dots_red_blue">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/red_blue.webp" class="" data-title="">
				<label for="filter_dots_red_blue">Yenilgi, ama casuslandı</label>
			</div>

			<div class="filter-row">
				<input class="report-filter-checkbox" type="checkbox" name="filter_dots[3]" value="3" id="filter_dots_red">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/red.webp" class="" data-title="">
				<label for="filter_dots_red">Yenildi</label>
			</div>
		<input type="hidden" name="h" value="58fce238"></form>
		<br>
	</td>
	<td colspan="2" style="vertical-align: top">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=set_filter_icon">
            <h5>Komut ikonlarına göre sırala:</h5>

            <label><input type="radio" name="filter_attack_type" value="0" onclick="this.form.submit()" checked=""> Hepsi</label><br>
                            <label><input type="radio" name="filter_attack_type" value="8" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_small.webp" class="" data-title=""> Küçük saldırı (1-1000 birim)</label><br>
                            <label><input type="radio" name="filter_attack_type" value="16" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_medium.webp" class="" data-title=""> Orta saldırı (1000-5000 birim)</label><br>
                            <label><input type="radio" name="filter_attack_type" value="32" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_large.webp" class="" data-title=""> Büyük saldırı (5000+ birim) </label><br>
                            <label><input type="radio" name="filter_attack_type" value="1" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/farm.webp" class="" data-title=""> Yağma saldırısı</label><br>
                        <br>
            <label>
                <input type="radio" onclick="this.form.submit()" name="filter_icon_operator" value="AND" checked=""> VE
            </label>
            <label>
                <input type="radio" onclick="this.form.submit()" name="filter_icon_operator" value="OR"> VEYA
            </label>
            <br>
            <br>

							<label><input type="checkbox" name="filter_icon[2]" value="2" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/snob.webp" class="" data-title=""> Misyoner İçeriyor</label><br>
							<label><input type="checkbox" name="filter_icon[64]" value="64" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/spy.webp" class="" data-title=""> Casus İçeriyor</label><br>
							<label><input type="checkbox" name="filter_icon[4]" value="4" onclick="this.form.submit()"> <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/knight.webp" class="" data-title=""> Şövalye İçeriyor</label><br>
					<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>

<tr class="report_filter">
	<td colspan="4">
		<form method="POST" action="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;action=reset_filter">
			<input class="btn" type="submit" value="Tüm filtreleri sıfırla">
		<input type="hidden" name="h" value="58fce238"></form>
	</td>
</tr>
<tr class="report_filter">
	<td colspan="4">
		<a href="#" onclick="Report.toggleFilters('/game.php?village=12218&amp;screen=report&amp;mode=all&amp;ajaxaction=set_filter_shown&amp;h=58fce238', false)">» Filtreleri gizle</a>
	</td>
</tr><tr>
</tr><tr id="report_filter_hide" style="display:none">
	<td colspan="4">
		<a href="#" onclick="Report.toggleFilters('/game.php?village=12218&amp;screen=report&amp;mode=all&amp;ajaxaction=set_filter_shown&amp;h=58fce238', true)">» Filtreleri göster</a>	</td>
</tr>
</tbody></table>

<div class="report-preview">
    <div class="report-preview-content"></div>
</div>

<form action="/game.php?village=12218&amp;screen=report&amp;mode=process_reports&amp;refmode=all" method="post">
	<table id="report_list" class="vis" width="100%">
		<tbody><tr>
			<th><input name="all" type="checkbox" class="selectAll" id="select_all_top" onclick="selectAll(this.form, this.checked)"></th>
			<th>Konu</th>
			<th>Alındı</th>
					</tr>
			<tr class="unread report-1400774">
			<td>
				<input name="id_1400774" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/awards/scavenge_mini.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1400774">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1400774" class="report-link" data-id="1400774">
														<span class="quickedit-label">
															Kazanılan başarı: Toplayıcı (Odun - Seviye 1)
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 21:13</td>
					</tr>
			<tr class="unread report-1400773">
			<td>
				<input name="id_1400773" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/icons/report_scavenging.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1400773">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1400773" class="report-link" data-id="1400773">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1) temizliyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 21:13</td>
					</tr>
			<tr class=" report-1335839">
			<td>
				<input name="id_1335839" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/icons/report_scavenging.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1335839">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1335839" class="report-link" data-id="1335839">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1) temizliyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 17:53</td>
					</tr>
			<tr class="unread report-1256843">
			<td>
				<input name="id_1256843" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/awards/award3_mini.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1256843">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1256843" class="report-link" data-id="1256843">
														<span class="quickedit-label">
															Kazanılan başarı: Yağmacı (Odun - Seviye 1)
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 13:27</td>
					</tr>
			<tr class="unread report-1250166">
			<td>
				<input name="id_1250166" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/icons/report_scavenging.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1250166">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1250166" class="report-link" data-id="1250166">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1) temizliyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 13:05</td>
					</tr>
			<tr class="unread report-1200874">
			<td>
				<input name="id_1200874" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/icons/report_scavenging.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="1200874">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1200874" class="report-link" data-id="1200874">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1) temizliyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 10:09</td>
					</tr>
			<tr class=" report-1135502">
			<td>
				<input name="id_1135502" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
											<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_small.webp" class="" data-title="Küçük saldırı (1-1000 birim)">
									</div>

				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/dots/green.webp" class="" data-title="Tam zafer">  <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/max_loot/0.webp" class="" data-title="Kısmi yağma: Askerlerin bulabildikleri her şeyi yağmaladı.&lt;br /&gt; &lt;span class=&quot;nowrap&quot;&gt;&lt;span class=&quot;icon header wood&quot; title=&quot;Odun&quot;&gt; &lt;/span&gt;17&lt;/span&gt; &lt;span class=&quot;nowrap&quot;&gt;&lt;span class=&quot;icon header stone&quot; title=&quot;Kil&quot;&gt; &lt;/span&gt;17&lt;/span&gt; &lt;span class=&quot;nowrap&quot;&gt;&lt;span class=&quot;icon header iron&quot; title=&quot;Demir&quot;&gt; &lt;/span&gt;17&lt;/span&gt; "> 
								<span class="quickedit report-title" data-id="1135502">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=1135502" class="report-link" data-id="1135502">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1 (471|614) K64), Barbar Köyü (473|613) K64 adlı oyuncuya saldırıyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 13, 03:54</td>
					</tr>
			<tr class="unread report-916849">
			<td>
				<input name="id_916849" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/icons/report_scavenging.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="916849">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=916849" class="report-link" data-id="916849">
														<span class="quickedit-label">
															DivinityVL6134 (Köy 1) temizliyor
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 12, 13:59</td>
					</tr>
			<tr class="unread report-909088">
			<td>
				<input name="id_909088" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/awards/quests_mini.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="909088">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=909088" class="report-link" data-id="909088">
														<span class="quickedit-label">
															Kazanılan başarı: Görevlerin Ustası (Odun - Seviye 1)
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 12, 13:28</td>
					</tr>
			<tr class="unread report-882877">
			<td>
				<input name="id_882877" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/premium/coinbag_14x14.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="882877">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=882877" class="report-link" data-id="882877">
														<span class="quickedit-label">
															+20% demir üretimi etkinleştirildi!
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 12, 11:45</td>
					</tr>
			<tr class="unread report-882868">
			<td>
				<input name="id_882868" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/premium/coinbag_14x14.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="882868">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=882868" class="report-link" data-id="882868">
														<span class="quickedit-label">
															+20% kil üretimi etkinleştirildi!
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 12, 11:45</td>
					</tr>
			<tr class="unread report-882858">
			<td>
				<input name="id_882858" type="checkbox">
			</td>
			<td style="overflow: hidden">
				<div class="nowrap float_right" style="margin-top: 2px">
									</div>

				 
									<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/premium/coinbag_14x14.webp" style="vertical-align: -2px" alt="" class="">
								<span class="quickedit report-title" data-id="882858">
					<span class="quickedit-content">
						<a href="/game.php?village=12218&amp;screen=report&amp;mode=all&amp;group_id=0&amp;view=882858" class="report-link" data-id="882858">
														<span class="quickedit-label">
															+20% odun üretimi etkinleştirildi!
														</span>
						</a>
												<a class="rename-icon" href="#" data-title="Adını değiştir"></a>
											</span>
				</span>
				<span class="report-unread">
					(yeni)
				</span>
			</td>
			<td class="nowrap">Oca 12, 11:45</td>
					</tr>
	
			<tr>
			<th colspan="2">
				<input name="all" type="checkbox" class="selectAll" id="select_all" onclick="selectAll(this.form, this.checked)"> <label for="select_all">hepsini seç</label></th>
							<th></th>
									</tr>
		</tbody></table>

	<table class="vis" align="left" style="float: left;">
		<tbody><tr>
			<td>
				<input type="hidden" value="0" name="from">
				<input type="hidden" value="33" name="num_reports">
				<input type="hidden" value="0" name="current_group_id">
				<input type="hidden" name="h" value="58fce238">
				<input class="btn btn-cancel" type="submit" value="Sil" name="del">
							<input class="btn" type="submit" value="Yayınla" name="forward">
			  	<input class="btn" type="submit" value="İlet" name="real_forward">
				<input class="btn" type="submit" value="Kabul et" name="accept_forwarded" data-title="İletilen tüm raporları kabul et.">
						</td>
							<td>
				<select name="group_id">
																																	<option value="6969">Arşiv</option>
																				<option value="9265">Yağma Asistanı</option>
													</select>
				<input class="btn" type="submit" value="Kaydır" name="arch">
			</td>
				</tr>
	</tbody></table>
</form>

<form action="/game.php?village=12218&amp;screen=report&amp;action=change_page_size&amp;mode=all&amp;from=0" method="post">
	<table class="vis nowrap" align="left" style="float: left;">
		<tbody><tr>
			<th colspan="2">Sayfa başına rapor:</th>
				<td><input name="page_size" type="text" style="width: 50px" value="12"></td>
			<td><input class="btn" type="submit" value="Değiştir"></td>
		</tr>
	</tbody></table>
<input type="hidden" name="h" value="58fce238"></form>

<div style="clear:both;"> </div>



<script>
	$(function(){
		$('.quickedit').QuickEdit( { url: TribalWars.buildURL('POST', 'report', { ajaxaction: 'edit_subject', report_id: '__ID__' } ) } );
	});
</script>
</td></tr></tbody></table>
	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>

## ✅ 11. HARİTA (MAP)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=map`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] `TWMap.villages` JavaScript objesi var mı?
- [ ] Harita yükleniyor mu?

**Lütfen ver:**
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            <h2>
    Kıta <span id="continent_id">64</span>

    </h2>

<script type="text/javascript">
//<![CDATA[

	/** General purpose map script variables **/

	TWMap.premium = true;
	TWMap.mobile = false;
	TWMap.morale = true;
	TWMap.night = false;
	TWMap.classic_gfx = false; // Needed to display day borders if user activated classic graphics

    TWMap.scrollBound = {
        x_min: 0,
        x_max: 999,
        y_min: 0,
        y_max: 999
    };

	TWMap.tileSize = [53, 38];

	TWMap.screenKey = '58fce238';
	TWMap.topoKey = 2882651525;
	TWMap.con.CON_COUNT = 10;
	TWMap.con.SEC_COUNT = 20;
	TWMap.con.SUB_COUNT = 5;

	TWMap.image_base = 'https://dstr.innogamescdn.com/asset/c645ceed/graphic/';
	TWMap.graphics = 'https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/';

			TWMap.currentVillage = 12218;
		TWMap.cachePopupContents = true;

    TWMap.minimap_cache_stamp = 34;


	/** Context menu **/

	TWMap.context._ownOrder = ["mp_info","mp_recruit","mp_profile","mp_overview","mp_fav","mp_res","mp_att","mp_farm_a","mp_farm_b"];
	TWMap.context._otherOrder = ["mp_info","mp_lock","mp_profile","mp_msg","mp_fav","mp_res","mp_att","mp_farm_a","mp_farm_b"];
	TWMap.urls.ctx = {};
	TWMap.urls.ctx.mp_overview = '/game.php?village=__village__&screen=overview';
	TWMap.urls.ctx.mp_info = '/game.php?village=12218&screen=info_village&id=__village__';
	TWMap.urls.ctx.mp_fav = '/game.php?village=12218&screen=info_village&id=__village__&ajaxaction=add_target&json=1&h=58fce238';
	TWMap.urls.ctx.mp_unfav = '/game.php?village=12218&screen=info_village&id=__village__&ajaxaction=del_target&json=1&h=58fce238';
	TWMap.urls.ctx.mp_lock = '/game.php?village=12218&screen=info_village&id=__village__&ajaxaction=toggle_reserve_village&json=1&h=58fce238';
	TWMap.urls.ctx.mp_res = '/game.php?village=12218&screen=market&mode=send&target=__village__';
	TWMap.urls.ctx.mp_att = '/game.php?village=12218&screen=place&target=__village__';
	TWMap.urls.ctx.mp_recruit = '/game.php?village=12218&screen=train&village=__village__';
	TWMap.urls.ctx.mp_profile = '/game.php?village=12218&screen=info_player&id=__owner__';
	TWMap.urls.ctx.mp_msg = '/game.php?village=12218&screen=mail&mode=new&player=__owner__';
	TWMap.urls.ctx.mp_unlock = TWMap.urls.ctx.mp_lock;
	TWMap.urls.ctx.mp_invite = '/game.php?village=12218&screen=settings&mode=ref&source=map';
	TWMap.urls.ctx.mp_invite_hide = '/game.php?village=12218&screen=settings&ajaxaction=map_hide_invitation&json=1&h=58fce238';

						TWMap.urls.ctx.mp_farm_a = '/game.php?village=12218&screen=am_farm&mode=farm&ajaxaction=farm&template_id=6324&target=__village__&source=__source__&json=1&h=58fce238';
					TWMap.urls.ctx.mp_farm_b = '/game.php?village=12218&screen=am_farm&mode=farm&ajaxaction=farm&template_id=6325&target=__village__&source=__source__&json=1&h=58fce238';
			
		TWMap.ghost = {"x":472,"y":611};
	
	TWMap.context.enabled = true;
			TWMap.context._showPremium = true;
                TWMap.troop_templates = [];
        TWMap.current_units = {"spear":"230","sword":"98","axe":"2","spy":"10","light":"0","heavy":"0","ram":"0","catapult":"0","knight":"1","snob":"0","militia":"0"};
        TWMap.command_hash = ["bcf310444495b32bf11652","508a9650bcf310"];
        	
	/** Other URLs **/

	TWMap.urls.villageInfo = '/game.php?village=12218&screen=info_village&id=__village__';
	TWMap.urls.villagePopup = '/game.php?village=12218&screen=map&ajax=map_info&source=12218&target=__village__';
	TWMap.urls.sizeSave = '/game.php?village=12218&screen=settings&ajaxaction=set_map_size&&h=58fce238';
	TWMap.urls.changeShowBelief = '/game.php?village=12218&screen=settings&ajaxaction=change_topo_show_belief&&h=58fce238';
	TWMap.urls.changeShowRelics = '/game.php?village=12218&screen=settings&ajaxaction=change_topo_show_relics&&h=58fce238';
	TWMap.urls.changeUseContext = '/game.php?village=12218&screen=settings&ajaxaction=change_use_contextmenu&&h=58fce238';
	TWMap.urls.savePopup = '/game.php?village=12218&screen=map&ajax=save_map_popup&';

	/** Attacked villages **/
	
	/** Village colors **/

			TWMap.colors['this'] = [255, 255, 255];
			TWMap.colors['player'] = [240, 200, 0];
			TWMap.colors['friend'] = [69, 255, 146];
			TWMap.colors['ally'] = [0, 0, 244];
			TWMap.colors['partner'] = [0, 160, 244];
			TWMap.colors['nap'] = [128, 0, 128];
			TWMap.colors['enemy'] = [244, 0, 0];
			TWMap.colors['other'] = [130, 60, 10];
			TWMap.colors['sleep'] = [0, 0, 0];
			TWMap.colors['grey'] = [150, 150, 150];
			TWMap.colors['stronghold'] = [10, 150, 150];
			TWMap.colors['highlight_village'] = [255, 0, 255];
			TWMap.colors['highlight_player'] = [239, 165, 239];
	
    TWMap.GreatSiege.setSiegeVillageIds([]);
    TWMap.GreatSiege.setDistances(
		3,
		15
	);

	TWMap.inline_send.enabled = 1;

	TWMap.ignore_villages = [];

	TWMap.non_attackable_players = ["60","587","1158","2392","2417","2942","3167","4395","5775","7109","8180","8685","9549","9786","10387","11507","12173","13121","15490","16797","17991","19214","19665","30780","34868","40534","44551","47012","50807","53280","55316","66600","77363","84642","87203","89563","102539","140262","146785","150677","152679","159692","177235","186419","194868","222453","223254","252874","296893","352683","354960","363297","365625","420412","422314","422825","430024","439605","466613","523683","532644","602844","620271","632125","665383","695831","718048","718256","733055","806232","815149","835040","841041","854899","858906","870484","870541","874079","904462","906930","959090","971787","1007745","1020526","1044824","1045046","1053825","1062208","1083542","1117571","1118338","1121546","1123385","1181582","1191750","1194256","1195238","1197687","1211416","1212530","1230463","1244759","1250387","1250979","1261246","1261660","1264425","1269409","1282266","1296150","1302036","1326677","1344798","1354104","1359792","1376956","1377415","1381277","1421767","1436284","1436715","1437733","1443741","1468339","1469352","1472645","1478805","1493517","1499048","1500573","1501771","1503295","1503504","1504453","1517024","1529525","1535528","1546518","1553950","1555092","1576111","1591316","1593899","1596700","1601756","1606299","1607131","1613840","1615341","1616431","1618086","1628332","1629791","1635660","1643118","1644915","1649528","1649950","1654113","1661388","1661580","1669192","1675366","1676071","1678787","1681544","1687234","1694912","1698322","1708097","1709837","1718744","1719391","1723715","1724728","1728012","1733098","1738958","1739681","1743902","1744284","1755413","1765661","1765855","1779571","1785768","1786651","1799354","1802155","1802212","1805149","1816255","1816744","1819695","1821007","1832891","1834058","1835883","1845124","1848954","1855216","1858523","4758322","4771429","4782724","4796624","4815192","4819287","4825918","4829242","4833622","4845754","4851075","4855195","4856342","4870855","4870916","4871941","4874897","4880906","4882516","4885521","4889089","4889679","4891078","4901096","4915481","4921720","4926943","4932782","4936026","4942945","4945229","4947443","4947766","4950075","4953638","4967542","4968785","4970982","4988488","5003811","5010985","5019766","5033444","5043674","5047502","5047728","5054033","5057257","5060174","5062775","5065024","5066041","5066837","5067814","5075451","5082400","5082884","5084366","5090540","5094189","5094239","5101472","5102210","5102756","5103089","5104758","5105074","5105853","5112997","5113581","5116572","5118337","5121295","5124187","5124722","5127141","5132112","5134153","5134675","5135611","5145478","5147911","5156606","5169217","5172541","5181907","5182358","5183794","5184924","5188125","5190642","5196139","5196363","5200266","5200791","5204506","5209036","5209141","5212682","5213166","5216021","5216191","5219214","5219784","5222164","5223480","5230082","5230085","5234129","5240179","5241642","5243991","5246468","5246968","5247986","5249635","5250388","5252129","5254726","5254855","5258667","5261525","5266700","5267177","5267848","5270838","5279816","5284184","5284340","5304323","5307327","5313410","5315489","5316870","5317052","5317561","5318876","5325836","5326355","5327564","5330271","5330689","5330744","5334412","5336818","5341437","5342787","5344925","5345033","5345495","5347565","5347820","5348227","5350427","5350457","5351259","5354195","5356245","5356254","5357089","5363254","5363952","5366479","5367271","5369942","5370687","5371203","5372117","5374429","5374806","5378673","5380519","5383633","5384113","5385009","5385123","5391114","5392680","5394505","5396009","5397847","5398982","5400433","5400438","5402224","5402887","5403779","5404516","5404713","5405389","5409459","5411535","5411747","5411810","5415432","5416569","5417418","5418357","5423519","5423888","5424485","5424512","5426561","5427585","5429930","5433158","5433408","5434596","5435742","5436613","5436671","5438002","5438416","5438651","5443516","5443916","5444719","5446722","5447443","5451290","5454446","5454736","5455659","5455890","5455967","5456953","5458527","5462130","5463568","5465800","5466397","5467690","5470134","5471640","5472135","5472505","5473872","5474894","5476026","5476430","5482155","5482792","5483223","5485652","5485702","5487178","5487243","5487246","5487247","5488134","5489635","5490423","5490582","5491825","5492392","5493000","5493637","5495218","5497225","5497711","5498168","5498526","5498885","5500258","5500483","5501243","5502706","5503085","5505985","5510910","5511927","5513201","5513562","5516725","5516726","5517944","5519887","5520042","5521085","5523278","5525287","5527146","5528152","5528413","5529044","5529358","5529919","5530881","5531028","5531068","5531617","5532631","5533290","5533549","5533577","5535198","5537527","5538037","5539741","5540731","5541312","5541651","5541755","5542920","5543038","5545545","5545644","5545765","5546007","5546613","5547799","5549597","5549919","5550289","5550888","5551796","5553519","5554692","5554873","5555377","5556988","5557091","5557703","5557739","5558427","5559083","5560536","5560550","5561033","5561750","5562777","5563241","5566683","5568836","5571092","5572986","848879550","848884462","848888287","848888307","848890090","848890587","848891464","848892257","848893836","848895246","848895347","848895563","848896225","848896512","848897946","848898420","848901125","848902254","848902482","848904627","848905893","848907569","848908753","848909915","848910168","848910192","848910210","848910497","848910548","848911061","848911254","848911286","848911346","848911474","848911508","848911513","848911837","848912533","848914070","848917263","848919202","848921856","848924437","848925124","848925379","848925507","848927028","848927367","848928054","848928339","848929416","848930626","848930718","848932254","848933129","848933726","848934318","848934612","848935302","848935697","848936473","848937687","848938956","848941400","848942458","848942706","848942894","848943192","848944416","848945369","848945755","848945823","848946102","848946676","848946988","848948307","848948878","848949722","848951438","848952426","848952536","848952637","848952926","848954748","848954815","848954911","848956321","848957075","848957119","848957450","848958237","848958702","848961047","848961857","848962162","848962588","848964097","848964576","848965381","848965703","848965725","848965730","848966437","848967586","848968225","848971454","848971556","848971771","848972536","848973042","848973656","848974575","848975163","848975515","848976066","848977408","848977414","848977417","848978258","848978923","848980144","848980602","848983937","848983953","848985753","848986570","848986667","848986942","848987315","848987823","848987824","848988069","848988167","848988239","848988871","848988873","848988901","848988965","848989207","848989212","848989273","848989342","848989484","848989510","848989547","848989656","848989749","848989794","848989807","848989874","848989952","848990098","848990137","848990170","848990220","848990444","848990580","848990856","848990933","848991653","848991927","848992016","848992338","848992650","848992875","848992961","848993041","848993050","848993453","848993607","848993608","848993980","848994009","848994327","848994963","848995090","848995143","848995283","848995313","848995376","848995526","848995559","848995612","848995623","848995686","848995707","848995873","848995914","848995944","848996080","848996280","848996395","848996436","848996453","848996456","848996476","848996486","848996504","848996573","848996604","848996711","848997011","848997048","848997059","848997249","848997279","848997386","848997414","848997451","848997479","848997525","848997952","848997968","848998311","848998345","848998437","848998480","848998661","848998976","848999136","848999916","848999979","849000087","849001488","849001511","849001556","849001772","849002076","849002166","849002202","849002270","849002537","849003632","849003975","849004199","849004845","849005278","849005729","849006117","849006183","849006396","849006407","849006457","849006458","849007027","849007277","849008346","849008405","849008476","849008500","849008714","849009006","849009108","849009340","849009564","849010478","849010604","849011416","849011437","849011717","849011888","849012002","849012107","849012114","849012124","849012532","849012782","849013691","849013852","849014375","849017157","849017191","849017192","849017285","849017378","849017381","849017385","849017987","849018186","849018360","849018435","849018477","849018519","849018520","849018631","849018787","849018884","849019347","849019693","849020037","849020088","849020860","849022148","849022198","849022748","849022796","849023097","849023145","849023350","849024456","849025013","849025538","849025541","849026258","849026554","849026592","849026699","849027441","849027903","849028054","849028748","849029167","849029336","849029503","849029775","849030807","849030930","849031452","849031659","849032108","849032136","849033156","849033420","849033941","849033948","849034390","849035128","849035313","849035549","849035551","849036041","849036132","849036277","849036369","849036557","849036604","849036963","849037644","849037671","849037691","849038138","849038140","849038146","849038147","849038530","849038721","849038817","849038912","849038924","849038946","849038966","849039174","849039562","849040794","849040816","849041033","849041255","849041749","849041840","849042144","849042462","849042918","849043020","849043135","849043187","849043605","849044211","849044268","849044618","849044988","849045029","849045138","849045294","849045379","849045560","849045946","849045948","849046445","849046569","849046698","849046701","849046746","849047031","849047033","849047035","849047619","849047985","849048133","849048657","849048748","849049003","849049589","849049666","849050050","849050333","849050416","849051212","849051253","849052006","849052455","849052512","849052543","849052626","849052796","849053125","849053656","849053816","849053862","849054436","849054713","849054807","849055035","849055367","849055403","849055504","849055517","849055566","849055759","849055798","849055821","849055989","849056013","849056085","849056214","849056371","849056665","849057025","849057345","849057435","849057973","849058111","849058303","849058551","849059538","849060477","849060781","849060871","849061051","849061136","849061196","849061878","849061900","849062050","849062091","849062337","849062467","849062545","849062815","849062848","849063107","849063139","849063166","849063266","849063298","849063363","849063582","849063642","849063755","849064029","849064207","849064252","849064727","849064756","849064825","849064878","849064974","849065036","849065044","849065147","849065170","849065183","849065196","849065224","849065250","849065272","849065366","849065459","849065477","849065683","849065703","849065829","849065865","849065922","849065965","849066004","849066059","849066099","849066118","849066122","849066159","849066198","849066278","849066279","849066281","849066286","849066287","849066362","849066403","849066442","849066461","849066463","849066469","849066470","849066471","849066473","849066476","849066478","849066488","849066517","849066729","849066783","849066954","849066958","849067008","849067154","849067206","849067210","849067235","849067347","849067466","849067632","849067728","849067802","849067917","849067921","849067949","849068007","849068048","849068110","849068122","849068124","849068141","849068142","849068172","849068337","849068403","849068537","849068551","849068553","849068556","849068562","849068572","849068575","849068578","849068585","849068594","849068610","849068660","849068661","849068663","849068665","849068690","849068692","849068694","849068696","849068746","849068766","849068789","849068825","849068830","849068855","849068888","849068903","849068920","849068921","849068925","849068927","849068957","849068980","849068981","849068982","849068983","849068984","849068990","849068996","849069004","849069040","849069092","849069113","849069117","849069198","849069200","849069220","849069233","849069238","849069251","849069310","849069415","849069465","849069492","849069497","849069510","849069537","849069712","849069741","849069751","849069811","849069814","849069915","849069955","849069963","849069987","849069988","849070004","849070048","849070050","849070058","849070163","849070166","849070169","849070188","849070207","849070336","849070454","849070466","849070521","849070546","849070566","849070609","849070625","849070628","849070637","849070659","849070693","849070731","849070797","849070819","849070833","849070848","849070891","849070900","849070901","849070947","849071047","849071063","849071069","849071085","849071239","849071240","849071241","849071274","849071275","849071276","849071278","849071279","849071280","849071282","849071283","849071284","849071285","849071288","849071290","849071291","849071292","849071293","849071294","849071295","849071296","849071297","849071299","849071300","849071301","849071302","849071303","849071306","849071310","849071311","849071313","849071314","849071315","849071316","849071317","849071318","849071319","849071320","849071321","849071322","849071323","849071324","849071326","849071327","849071328","849071331","849071333","849071334","849071335","849071336","849071337","849071338","849071339","849071343","849071345","849071346","849071347","849071350","849071351","849071354","849071355","849071356","849071359","849071361","849071362","849071363","849071367","849071369","849071370","849071372","849071374","849071375","849071376","849071377","849071378","849071379","849071380","849071383","849071384","849071386","849071387","849071390","849071391","849071392","849071393","849071394","849071395","849071396","849071397","849071398","849071399","849071400","849071401","849071402","849071403","849071404","849071405","849071406","849071407","849071408","849071409","849071410","849071411","849071412","849071413","849071414","849071416","849071417","849071418","849071421","849071422","849071424","849071427","849071428","849071429","849071431","849071432","849071433","849071435","849071437","849071438","849071444","849071445","849071446","849071447","849071448","849071451","849071452","849071453","849071454","849071455","849071456","849071459","849071462","849071463","849071465","849071466","849071467","849071469","849071470","849071472","849071473","849071474","849071478","849071479","849071481","849071482","849071483","849071484","849071485","849071487","849071488","849071490","849071492","849071493","849071495","849071496","849071497","849071498","849071499","849071500","849071501","849071502","849071503","849071505","849071506","849071507","849071508","849071510","849071511","849071512","849071513","849071514","849071515","849071516","849071517","849071518","849071519","849071520","849071521","849071522","849071523","849071524","849071525","849071526","849071527","849071528","849071529","849071530","849071531","849071532","849071533","849071534","849071535","849071536","849071537","849071538","849071539","849071540","849071541","849071542","849071543","849071544","849071545","849071546","849071547","849071548","849071549","849071550","849071551","849071552","849071553","849071554","849071555","849071556","849071557","849071558","849071559","849071560","849071561","849071562","849071563","849071564","849071565","849071566","849071571","849071572","849071573","849071574","849071575","849071576","849071577","849071578","849071579","849071580","849071581","849071582","849071583","849071584","849071585","849071586","849071587","849071588","849071589","849071590","849071591","849071592","849071593","849071594","849071595","849071596","849071597","849071598","849071599","849071600","849071601","849071602","849071603","849071604","849071606","849071607","849071608","849071609","849071610","849071611","849071612","849071614","849071615","849071616","849071617","849071618","849071619","849071620","849071621","849071623","849071624","849071625","849071626","849071627","849071628","849071629","849071630","849071631","849071632","849071633","849071634","849071635","849071636","849071637","849071638","849071639","849071640","849071641","849071642","849071643","849071645","849071646","849071647","849071649","849071650","849071652","849071653","849071655","849071656","849071657","849071658","849071659","849071660","849071661","849071662","849071664","849071665","849071666","849071667","849071668","849071669","849071670","849071671","849071672","849071673","849071674","849071675","849071676","849071677","849071678","849071679","849071680","849071681","849071682","849071683","849071684","849071686","849071687","849071688","849071689","849071690","849071691","849071692","849071693","849071695","849071696"];
	TWMap.non_attackable_villages = [];

	TWMap.bonus_data = {"1":{"text":"100% daha fazla odun \u00fcretimi","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/wood.webp"},"2":{"text":"100% daha fazla kil \u00fcretimi","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/stone.webp"},"3":{"text":"100% daha fazla demir \u00fcretimi","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/iron.webp"},"4":{"text":"10% daha fazla n\u00fcfus","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/farm.webp"},"5":{"text":"K\u0131\u015flada 33% daha h\u0131zl\u0131 \u00fcretim","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/barracks.webp"},"6":{"text":"Ah\u0131rda 33% daha h\u0131zl\u0131 \u00fcretim","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/stable.webp"},"7":{"text":"At\u00f6lyede 50% daha h\u0131zl\u0131 \u00fcretim","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/garage.webp"},"8":{"text":"30% daha fazla hammadde \u00fcretimi (t\u00fcm hammaddeler)","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/all.webp"},"9":{"text":"50% daha fazla depo kapasitesi ve t\u00fcccarlar.","image":"https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/bonus\/storage.webp"}};
	TWMap.images = ["gras1.png","gras2.png","gras3.png","gras4.png","v1_left.png","v1.png","v2_left.png","v2.png","v3_left.png","v3.png","v4_left.png","v4.png","v5_left.png","v5.png","v6_left.png","v6.png","b1_left.png","b1.png","b2_left.png","b2.png","b3_left.png","b3.png","b4_left.png","b4.png","b5_left.png","b5.png","b6_left.png","b6.png","berg1.png","berg2.png","berg3.png","berg4.png","forest0000.png","forest0001.png","forest0010.png","forest0011.png","forest0100.png","forest0101.png","forest0110.png","forest0111.png","forest1000.png","forest1001.png","forest1010.png","forest1011.png","forest1100.png","forest1101.png","forest1110.png","forest1111.png","see.png","event_xmas.png","event_easter.png","ghost.png","event_merchant.png","event_wizard.png","event_easter2014.png","event_fall2014.png","rune_village.png","citynw.png","cityne.png","citysw.png","cityse.png","cityn1.png","cityn2.png","citye1.png","citye2.png","citys1.png","citys2.png","cityw1.png","cityw2.png","citym1.png","citym2.png","citym3.png","citym4.png","citye3.png","citye4.png","cityw3.png","cityw4.png","citym5.png","citym6.png","citym7.png","citym8.png","citym9.png","citym10.png","stronghold0.png","stronghold1.png","stronghold2.png","stronghold3.png","stronghold4.png","university.png","castle_v1.png","castle_v2.png","castle_v3.png","castle_v4.png","castle_v5.png","castle_v6.png","castle_b1.png","castle_b2.png","castle_b3.png","castle_b4.png","castle_b5.png","castle_b6.png","civilian_v1.png","civilian_v2.png","civilian_v3.png","civilian_v4.png","civilian_v5.png","civilian_v6.png","civilian_b1.png","civilian_b2.png","civilian_b3.png","civilian_b4.png","civilian_b5.png","civilian_b6.png","forest_v1.png","forest_v2.png","forest_v3.png","forest_v4.png","forest_v5.png","forest_v6.png","forest_b1.png","forest_b2.png","forest_b3.png","forest_b4.png","forest_b5.png","forest_b6.png","fortress_v1.png","fortress_v2.png","fortress_v3.png","fortress_v4.png","fortress_v5.png","fortress_v6.png","fortress_b1.png","fortress_b2.png","fortress_b3.png","fortress_b4.png","fortress_b5.png","fortress_b6.png","market_v1.png","market_v2.png","market_v3.png","market_v4.png","market_v5.png","market_v6.png","market_b1.png","market_b2.png","market_b3.png","market_b4.png","market_b5.png","market_b6.png","military_v1.png","military_v2.png","military_v3.png","military_v4.png","military_v5.png","military_v6.png","military_b1.png","military_b2.png","military_b3.png","military_b4.png","military_b5.png","military_b6.png","mine_v1.png","mine_v2.png","mine_v3.png","mine_v4.png","mine_v5.png","mine_v6.png","mine_b1.png","mine_b2.png","mine_b3.png","mine_b4.png","mine_b5.png","mine_b6.png","banner_blue_v1.png","banner_blue_v2.png","banner_blue_v3.png","banner_blue_v4.png","banner_blue_v5.png","banner_blue_v6.png","banner_blue_b1.png","banner_blue_b2.png","banner_blue_b3.png","banner_blue_b4.png","banner_blue_b5.png","banner_blue_b6.png","banner_orange_v1.png","banner_orange_v2.png","banner_orange_v3.png","banner_orange_v4.png","banner_orange_v5.png","banner_orange_v6.png","banner_orange_b1.png","banner_orange_b2.png","banner_orange_b3.png","banner_orange_b4.png","banner_orange_b5.png","banner_orange_b6.png","banner_pink_v1.png","banner_pink_v2.png","banner_pink_v3.png","banner_pink_v4.png","banner_pink_v5.png","banner_pink_v6.png","banner_pink_b1.png","banner_pink_b2.png","banner_pink_b3.png","banner_pink_b4.png","banner_pink_b5.png","banner_pink_b6.png","banner_red_v1.png","banner_red_v2.png","banner_red_v3.png","banner_red_v4.png","banner_red_v5.png","banner_red_v6.png","banner_red_b1.png","banner_red_b2.png","banner_red_b3.png","banner_red_b4.png","banner_red_b5.png","banner_red_b6.png","banner_turquoise_v1.png","banner_turquoise_v2.png","banner_turquoise_v3.png","banner_turquoise_v4.png","banner_turquoise_v5.png","banner_turquoise_v6.png","banner_turquoise_b1.png","banner_turquoise_b2.png","banner_turquoise_b3.png","banner_turquoise_b4.png","banner_turquoise_b5.png","banner_turquoise_b6.png","banner_yellow_v1.png","banner_yellow_v2.png","banner_yellow_v3.png","banner_yellow_v4.png","banner_yellow_v5.png","banner_yellow_v6.png","banner_yellow_b1.png","banner_yellow_b2.png","banner_yellow_b3.png","banner_yellow_b4.png","banner_yellow_b5.png","banner_yellow_b6.png"];

	/** Some sector fun **/
	TWMap.sectorPrefech = [{"x":460,"y":600,"tiles":[[3,1,1,1,0,1,32,2,1,3,3,1,0,1,1,3,36,1,3,2],[3,2,40,34,1,30,31,3,40,35,3,2,1,1,2,1,2,1,1,3],[48,1,0,0,1,29,28,3,1,36,1,2,0,1,0,40,42,34,1,41],[2,2,2,0,0,2,1,0,1,3,32,1,33,2,1,0,1,0,0,45],[0,1,2,48,0,3,2,0,3,3,2,1,36,1,1,1,1,2,3,37],[2,3,3,3,2,1,3,0,3,1,40,34,0,1,1,0,2,0,40,39],[34,0,41,34,0,0,3,0,2,3,3,2,1,2,2,1,2,0,0,36],[3,0,36,1,33,2,1,2,3,2,3,32,1,0,2,0,0,3,0,2],[0,2,1,3,36,2,3,3,2,40,34,3,0,2,0,0,1,1,3,3],[0,3,2,0,2,0,3,1,1,0,3,2,3,0,3,33,3,0,2,0],[3,1,2,40,34,0,0,3,2,33,2,0,1,1,3,37,2,40,42,34],[42,42,34,2,1,40,34,1,2,36,1,48,3,2,3,36,3,0,3,0],[3,1,2,0,0,1,2,40,35,3,1,1,3,1,2,2,0,1,2,3],[35,1,40,34,2,2,3,3,36,1,1,1,1,0,1,41,34,3,1,3],[36,3,1,2,2,3,3,2,3,0,3,1,2,2,3,36,3,0,1,0],[2,0,2,1,0,2,0,3,33,2,0,0,0,1,48,3,2,40,43,34],[2,1,3,3,0,3,32,0,36,3,0,1,32,3,3,1,1,0,36,3],[2,3,0,2,1,1,3,2,3,2,3,0,2,1,1,0,1,0,0,3],[2,1,2,3,0,1,3,3,3,40,42,35,1,33,1,33,3,3,2,33],[40,34,3,1,0,3,2,32,0,0,2,37,1,45,43,39,1,33,0,37]],"data":{"x":460,"y":600,"villages":[{"1":["8787",7,"rhm20","590","849069564",42,null,"0",null,null,"standard","104",7],"2":["12328",5,"ALTA","273","849071257",42,null,"0",null,null,"standard","0",5],"3":["3045",7,"k\u00f6y","433","5400071",42,null,"0",null,null,"standard","104",7],"9":["3037",7,"DADAHAN","575","288",42,null,"0",null,null,"standard","104",7],"11":["12564",7,"Nefretettik'nin k\u00f6y\u00fc","460","849017157",42,null,"0",null,null,"standard","186",7]},{"1":["6781",7,"ANKARA","725","5534047",42,null,"0",null,null,"standard","104",7],"7":["12736",7,"Bushidoo'nin k\u00f6y\u00fc","323","849071299",42,null,"0",null,null,"standard","104",7]},{"1":["10747",7,"asayi\u015f10","545","18594",42,null,"0",null,null,"standard","104",7],"2":["12582",7,"Labnee'nin k\u00f6y\u00fc","460","849017192",42,null,"0",null,null,"standard","186",7],"7":["14172",5,"N\u0130GHTVEXA","197","849071481",42,null,"0",null,null,"standard","0",5],"13":["12730",5,"lolopoz1'nin k\u00f6y\u00fc","36","849071297",42,null,"0",null,null,"standard","0",5],"18":["13064",5,"Eksilirsin'nin k\u00f6y\u00fc","70","1661388",42,null,"0",null,null,"standard","0",5]},{"0":["11112",4,0,"49","0",42,null,"0",null,null,"standard",null,4],"1":["3053",7,"\u0130Y\u0130","591","849070859",42,null,"0",null,null,"standard","104",7],"2":["7409",7,"*Dobra45*'nin k\u00f6y\u00fc","756","849003430",42,null,"0",null,null,"standard","229",7],"4":["3039",7,"captan93'nin k\u00f6y\u00fc","912","29202",42,null,"0",null,null,"standard","104",7],"8":["12075",7,"WoS","706","849064130",42,null,"0",null,null,"standard","104",7],"9":["12303",4,0,"55","0",42,null,"0",null,null,"standard",null,4]},{"0":["10976",4,0,"53","0",42,null,"0",null,null,"standard",null,4],"1":["4269",7,"sadcegkhan 1903'nin k\u00f6y\u00fc","650","4965069",42,null,"0",null,null,"standard","104",7],"2":["15270",5,"N\u0130GHTVEXA'nin k\u00f6y\u00fc","195","849071643",42,null,"0",null,null,"standard","0",5],"4":["11680",4,0,"46","0",42,null,"0",null,null,"standard",null,4],"6":["11589",4,0,"151","0",42,null,"0",null,null,"standard",null,4],"9":["12407",4,0,"58","0",42,null,"0",null,null,"standard",null,4]},{"0":["5453",7,"ichweiss1'nin k\u00f6y\u00fc","766","802119",42,null,"0",null,null,"standard","104",7],"1":["14992",5,"berkay1748'nin k\u00f6y\u00fc","137","849071607",42,null,"0",null,null,"standard","208",5],"3":["10997",5,"mavi","191","5414144",42,null,"0",null,null,"standard","0",5],"4":["11190",4,0,"51","0",42,null,"0",null,null,"standard",null,4],"6":["6103",7,"YILDIZ S\u0130LAH\u015e\u00d6R","438","5173122",42,null,"0",null,null,"standard","104",7],"12":["13354",5,"Penumbra'nin k\u00f6y\u00fc","238","849055367",42,null,"0",null,null,"standard","0",5],"14":["12589",4,0,"56","0",42,null,"0",null,null,"standard",null,4]},{"1":["11315",5,"Bak\u0131rkaktus07'nin k\u00f6y\u00fc","36","849071171",42,null,"0",null,null,"standard","0",5],"5":["11113",5,"fullmetaljacket'nin k\u00f6y\u00fc","120","848958640",42,null,"0",null,null,"standard","0",5],"8":["12233",4,0,"73","0",42,null,"0",null,null,"standard",null,4],"11":["12277",4,0,"53","0",42,null,"0",null,null,"standard",null,4]},{"0":["11162",4,0,"50","0",42,null,"0",null,null,"standard",null,4],"1":["10644",4,0,"108","0",42,null,"0",null,null,"standard",null,4],"3":["10773",7,"Pro Texas'nin k\u00f6y\u00fc","479","1558492",42,null,"0",null,null,"standard","186",7],"7":["11917",5,"KeMaNcI'nin k\u00f6y\u00fc","191","20291",42,null,"0",null,null,"standard","186",5]},{"0":["10474",4,0,"73","0",42,null,"0",null,null,"standard",null,4],"1":["10951",7,"Maden Suyu'nin k\u00f6y\u00fc","798","848916996",42,null,"0",null,null,"standard","186",7],"2":["10534",4,0,"61","0",42,null,"0",null,null,"standard",null,4],"8":["3459",7,"~TuNgSTeN~ -1","783","849069098",42,null,"0",null,null,"standard","186",7],"11":["3455",7,"Gargamelin K\u00f6y\u00fc","459","849062351",42,null,"0",null,null,"standard","186",7],"13":["12509",4,0,"86","0",42,null,"0",null,null,"standard",null,4]},{"0":["10640",4,0,"53","0",42,null,"0",null,null,"standard",null,4],"3":["6401",7,"ZaGRoS'nin k\u00f6y\u00fc","610","5406481",42,null,"0",null,null,"standard","186",7],"4":["11709",7,"GALATASARAY","445","5445018",42,null,"0",null,null,"standard","268",7],"8":["3451",7,"ilker2727'nin k\u00f6y\u00fc","647","5529548",42,null,"0",null,null,"standard","186",7],"19":["12849",4,0,"58","0",42,null,"0",null,null,"standard",null,4]},{"0":["5611",7,"Trawma'nin k\u00f6y\u00fc","570","1502543",42,null,"0",null,null,"standard","229",7],"2":["11000",4,0,"64","0",42,null,"0",null,null,"standard",null,4],"8":["11583",7,"Kralw'nin k\u00f6y\u00fc","435","849071163",42,null,"0",null,null,"standard","198",7],"11":["12267",4,0,"52","0",42,null,"0",null,null,"standard",null,4]},{"3":["8693",5,"criminalwinds'nin k\u00f6y\u00fc","270","849068648",42,null,"0",null,null,"standard","0",5],"14":["12218",7,"K\u00f6y 1","411","849071243",42,null,"0",null,null,"standard","186",7]},{"2":["10672",4,0,"45","0",42,null,"0",null,null,"standard",null,4],"3":["4157",7,"1Haspa'nin k\u00f6y\u00fc","690","848884598",42,null,"0",null,null,"standard","96",7],"9":["4561",7,"Irwwing'nin k\u00f6y\u00fc","787","849055500",42,null,"0",null,null,"standard","229",7],"12":["11875",4,0,"165","0",42,null,"0",null,null,"standard",null,4]},{"11":["12012",4,0,"52","0",42,null,"0",null,null,"standard",null,4],"13":["12333",4,0,"74","0",42,null,"0",null,null,"standard",null,4],"18":["13800",5,"talut.'nin k\u00f6y\u00fc","36","858906",42,null,"0",null,null,"standard","0",5]},{"2":["10941",9,"KAJUNOYAN'nin k\u00f6y\u00fc","1.092","5403149",42,null,"0",null,null,"standard","268",9],"4":["11222",4,0,"61","0",42,null,"0",null,null,"standard",null,4],"9":["3449",7,"ZERYAN","631","5529473",42,null,"0",null,null,"standard","186",7],"11":["12390",5,"skurt34","284","849071263",42,null,"0",null,null,"standard","0",5],"18":["12659",4,0,"52","0",42,null,"0",null,null,"standard",null,4]},{"0":["10556",4,0,"74","0",42,null,"0",null,null,"standard",null,4],"2":["10315",5,"dubams\u0131'nin k\u00f6y\u00fc","134","849070925",42,null,"0",null,null,"standard","0",5],"3":["10665",5,"rainbrave'nin k\u00f6y\u00fc","261","848886305",42,null,"0",null,null,"standard","0",5],"11":["11938",4,0,"46","0",42,null,"0",null,null,"standard",null,4]},{"1":["13602",7,"Tibet73'nin k\u00f6y\u00fc","339","13121",42,null,"0",null,null,"standard","0",7],"2":["11130",4,0,"75","0",42,null,"0",null,null,"standard",null,4],"3":["6493",7,"Yaln\u0131zKurt","672","5451897",42,null,"0",null,null,"standard","268",7],"7":["14170",5,"csiege'nin k\u00f6y\u00fc","174","5438416",42,null,"0",null,null,"standard","70",5]},{"0":["10578",4,0,"52","0",42,null,"0",null,null,"standard",null,4],"2":["8181",7,"cirak'nin k\u00f6y\u00fc","936","849060758",42,null,"0",null,null,"standard","268",7],"6":["213",7,"Otoban Faresi","807","5492345",42,null,"0",null,null,"standard","160",7],"8":["4851",7,"B\u0130R AVU\u00c7 V\u0130DA 1","329","849067963",42,null,"0",null,null,"standard","0",7]},{"0":["7029",7,"rafeturkoglu'nin k\u00f6y\u00fc","572","848932701",42,null,"0",null,null,"standard","160",7],"1":["9962",4,0,"56","0",42,null,"0",null,null,"standard",null,4],"4":["5893",7,"*34YNS34*'nin k\u00f6y\u00fc","516","4848028",42,null,"0",null,null,"standard","160",7],"6":["11353",5,"KDB17'nin k\u00f6y\u00fc","224","849063918",42,null,"0",null,null,"standard","0",5],"12":["3445",7,"PlayMaker34'nin k\u00f6y\u00fc","601","5390589",42,null,"0",null,null,"standard","186",7],"16":["12615",4,0,"59","0",42,null,"0",null,null,"standard",null,4]},{"3":["10372",4,0,"54","0",42,null,"0",null,null,"standard",null,4],"8":["11836",4,0,"101","0",42,null,"0",null,null,"standard",null,4],"12":["11433",7,"RHunter","494","849054656",42,null,"0",null,null,"standard","345",7]}],"players":{"288":["otuz8","575","104",0,false,"12","1 K\u00f6y"],"8259":["piramit48","741","104",0,false,"0","1 K\u00f6y"],"13121":["Tibet73","339","0","yar\u0131n \u015fu saatte 22:37",false,"0","1 K\u00f6y"],"16799":["patrommsemt","718","96",0,false,"560719","1 K\u00f6y"],"18594":["asayi\u015f10","545","104",0,false,"0","1 K\u00f6y"],"20291":["KeMaNcI","191","186",0,false,"0","1 K\u00f6y"],"29202":["captan93","912","104",0,false,"561533","1 K\u00f6y"],"59249":["Akduman","218","186",0,false,"0","1 K\u00f6y"],"177235":["akhisar45","305","186","17.01.'de 00:24'de",false,"0","1 K\u00f6y"],"219837":["The Motherland Calls","934","96",0,false,"560515","1 K\u00f6y"],"234388":["maltun","753","183",0,false,"0","1 K\u00f6y"],"380241":["zerozero","582","160",0,false,"0","1 K\u00f6y"],"474978":["ilkefe16","913","229",0,false,"0","1 K\u00f6y"],"559408":["thecrunk","398","186",0,false,"0","1 K\u00f6y"],"768394":["Tutum","941","96",0,false,"0","1 K\u00f6y"],"802119":["ichweiss1","766","104",0,false,"0","1 K\u00f6y"],"858906":["talut.","36","0","16.01.'de 12:47'de",false,"0","1 K\u00f6y"],"874079":["golevez","58","0","16.01.'de 19:44'de",false,"0","1 K\u00f6y"],"904462":["DevilKobra10","424","104","yar\u0131n \u015fu saatte 16:00",false,"0","1 K\u00f6y"],"973631":["MU AK AT","319","208",0,false,"0","1 K\u00f6y"],"1187425":["SALTUKHAN1","341","0",0,false,"0","1 K\u00f6y"],"1195238":["harzemsahi","298","186","16.01.'de 02:07'de",false,"0","1 K\u00f6y"],"1502543":["Trawma","570","229",0,false,"0","1 K\u00f6y"],"1509110":["cavuslar","545","104",0,false,"0","1 K\u00f6y"],"1558492":["Pro Texas","479","186",0,false,"0","1 K\u00f6y"],"1598660":["god10","643","268",0,false,"0","1 K\u00f6y"],"1603773":["-Zihgir-","537","345",0,false,"0","1 K\u00f6y"],"1604935":["Loyd","492","104",0,false,"0","1 K\u00f6y"],"1609479":["enfurkar54","579","104",0,false,"0","1 K\u00f6y"],"1625509":["Tepkisiz","446","160",0,false,"0","1 K\u00f6y"],"1661388":["Eksilirsin","70","0","yar\u0131n \u015fu saatte 10:35",false,"0","1 K\u00f6y"],"1675366":["Efendi muhammet54","191","0","16.01.'de 20:04'de",false,"0","1 K\u00f6y"],"1678787":["LeBronJames26","321","129","bug\u00fcn saat 20:44",false,"0","1 K\u00f6y"],"1678934":["Timur Lenq","361","208",0,false,"0","1 K\u00f6y"],"1685184":["An\u0131tkabir","473","229",0,false,"0","1 K\u00f6y"],"1704186":["fuego","834","268",0,false,"0","1 K\u00f6y"],"1723715":["G R O N D","36","0","yar\u0131n \u015fu saatte 23:08",false,"0","1 K\u00f6y"],"1725680":["MystraL","1.378","96",0,false,"560835","1 K\u00f6y"],"1748213":["BETTON60","367","96",0,false,"0","1 K\u00f6y"],"1782633":["SANGATT","492","96",0,false,"0","1 K\u00f6y"],"1805911":["SeeqSeing","449","96",0,false,"0","1 K\u00f6y"],"4819661":["Lord eyeraser","235","0",0,false,"0","1 K\u00f6y"],"4848028":["*34YNS34*","516","160",0,false,"0","1 K\u00f6y"],"4859957":["Bordoxx","187","223",0,false,"0","1 K\u00f6y"],"4886819":["compliment","1.350","229",0,false,"561583","1 K\u00f6y"],"4917855":["M1AySu","243","0",0,false,"0","1 K\u00f6y"],"4918164":["LV The BaNNeD","514","0",0,false,"0","1 K\u00f6y"],"4918196":["clubbeddeath","886","104",0,false,"0","1 K\u00f6y"],"4965069":["sadcegkhan 1903","650","104",0,false,"0","1 K\u00f6y"],"5047007":[".DRACULA.","362","0",0,false,"0","1 K\u00f6y"],"5082366":["Hayro is on Fire","841","160",0,false,"560711","1 K\u00f6y"],"5173122":["tekerchi","438","104",0,false,"0","1 K\u00f6y"],"5185523":["EyvahYand\u0131m","554","96",0,false,"0","1 K\u00f6y"],"5201799":["Pant\u00fcrkizm*","144","0",0,false,"0","1 K\u00f6y"],"5218892":["Santiago19","255","160",0,false,"0","1 K\u00f6y"],"5294933":["Morihei Ueshiba","36","0",0,false,"0","1 K\u00f6y"],"5315489":["Myke53","486","345","yar\u0131n \u015fu saatte 17:54",false,"0","1 K\u00f6y"],"5320785":["ozgurruh4141","685","198",0,false,"0","1 K\u00f6y"],"5350427":["Nahro23","275","342","yar\u0131n \u015fu saatte 21:08",false,"0","1 K\u00f6y"],"5358726":["3fsane","494","186",0,false,"0","1 K\u00f6y"],"5371203":["Timidis Nocte","461","186","bug\u00fcn saat 21:28",false,"0","1 K\u00f6y"],"5387918":["Ayasofya1453","347","0",0,false,"0","1 K\u00f6y"],"5390589":["PlayMaker34","601","186",0,false,"0","1 K\u00f6y"],"5400071":["124444","433","104",0,false,"0","1 K\u00f6y"],"5403149":["KAJUNOYAN","1.092","268",0,false,"0","1 K\u00f6y"],"5406481":["ZaGRoS","610","186",0,false,"561287","1 K\u00f6y"],"5414144":["mavideniz35","191","0",0,false,"0","1 K\u00f6y"],"5414755":["Karasan59","896","96",0,false,"0","1 K\u00f6y"],"5421026":["gkhnbab","502","96",0,false,"0","1 K\u00f6y"],"5432396":["TIGGY","920","268",0,false,"561309","1 K\u00f6y"],"5438416":["csiege","174","70","16.01.'de 22:23'de",false,"0","1 K\u00f6y"],"5438565":["nyx.","856","96",0,false,"0","1 K\u00f6y"],"5440754":["KeananK","443","186",0,false,"0","1 K\u00f6y"],"5445018":["Mrtayse","445","268",0,false,"0","1 K\u00f6y"],"5451897":["Yaln\u0131zKurt","672","268",0,false,"0","1 K\u00f6y"],"5461467":["san\u0131r\u0131m ba\u015faramayaca\u011f\u0131m","965","184",0,false,"0","1 K\u00f6y"],"5465403":["sevi\u015fmedenuyumayal\u0131m","585","96",0,false,"0","1 K\u00f6y"],"5472207":["Maksimus Decimus M.","142","0",0,false,"0","1 K\u00f6y"],"5474387":["\u0130brahimKutlu*","36","0",0,false,"0","1 K\u00f6y"],"5477057":["ZuzuX","1.520","96",0,false,"560678","1 K\u00f6y"],"5485319":["eksCatii","777","96",0,false,"0","1 K\u00f6y"],"5488826":["infilak20","253","96",0,false,"0","1 K\u00f6y"],"5492345":["Otoban Faresi","807","160",0,false,"0","1 K\u00f6y"],"5498046":["cse101","344","186",0,false,"0","1 K\u00f6y"],"5502095":["reflex","271","186",0,false,"0","1 K\u00f6y"],"5508018":["Linukas","839","186",0,false,"560865","1 K\u00f6y"],"5522966":["yarimt","408","160",0,false,"0","1 K\u00f6y"],"5525330":["Zorbeydyp","735","104",0,false,"0","1 K\u00f6y"],"5527514":["Mr.WHOAMI","638","186",0,false,"0","1 K\u00f6y"],"5529473":["Snowgalp","631","186",0,false,"0","1 K\u00f6y"],"5529548":["ilker2727","647","186",0,false,"0","1 K\u00f6y"],"5534047":["KRAL06","725","104",0,false,"0","1 K\u00f6y"],"5540969":["LOFA Erinzm","593","173",0,false,"0","1 K\u00f6y"],"5559589":["BK58","576","96",0,false,"561592","1 K\u00f6y"],"848884462":["Charmander1903","36","0","yar\u0131n \u015fu saatte 04:04",false,"0","1 K\u00f6y"],"848884598":["1Haspa","690","96",0,false,"0","1 K\u00f6y"],"848886305":["rainbrave","261","0",0,false,"0","1 K\u00f6y"],"848889754":["EMRN","256","0",0,false,"16","1 K\u00f6y"],"848890090":["ynnahmet","156","0","17.01.'de 16:35'de",false,"0","1 K\u00f6y"],"848906371":["\u00f6zbaylemram","479","104",0,false,"0","1 K\u00f6y"],"848916993":["Torku Elma","798","207",0,false,"561440","1 K\u00f6y"],"848916996":["Maden Suyu","798","186",0,false,"561442","1 K\u00f6y"],"848932701":["rafeturkoglu","572","160",0,false,"0","1 K\u00f6y"],"848934226":["saitsergen","518","160",0,false,"0","1 K\u00f6y"],"848953805":["Notorious Saint","636","229",0,false,"561147","1 K\u00f6y"],"848958640":["fullmetaljacket","120","0",0,false,"0","1 K\u00f6y"],"848965812":["AFK.","349","268",0,false,"0","1 K\u00f6y"],"848971782":["Elaz\u0131\u011flee23","319","186",0,false,"0","1 K\u00f6y"],"848973422":["Nihat16","941","229",0,false,"0","1 K\u00f6y"],"848980436":["serkan37370","547","186",0,false,"0","1 K\u00f6y"],"848984137":["SmH*","273","0",0,false,"560909","1 K\u00f6y"],"848986127":["Birsilifkeli","495","104",0,false,"12","1 K\u00f6y"],"848991358":["ZulalaZ\u0130","102","0",0,false,"0","1 K\u00f6y"],"848991900":["higuain52","346","0",0,false,"0","1 K\u00f6y"],"849002099":["\u0130VSA","231","207",0,false,"0","1 K\u00f6y"],"849003008":["\u00c7akmak\u00e7\u01314877","912","198",0,false,"0","1 K\u00f6y"],"849003430":["*Dobra45*","756","229",0,false,"0","1 K\u00f6y"],"849004997":["Jantiabiniz","706","186",0,false,"0","1 K\u00f6y"],"849006814":["KunaiHun","446","268",0,false,"0","1 K\u00f6y"],"849008833":["Lethean1","739","229",0,false,"0","1 K\u00f6y"],"849013506":["Pokeryman","327","207",0,false,"0","1 K\u00f6y"],"849017157":["Nefretettik","460","186","bug\u00fcn saat 21:59",false,"0","1 K\u00f6y"],"849017191":["bioteklik1","483","183","bug\u00fcn saat 22:05",false,"0","1 K\u00f6y"],"849017192":["Labnee","460","186","bug\u00fcn saat 22:09",false,"0","1 K\u00f6y"],"849017378":["Parkarton","460","338","bug\u00fcn saat 22:12",false,"0","1 K\u00f6y"],"849023350":["mahir27","481","186","16.01.'de 20:22'de",false,"0","1 K\u00f6y"],"849023473":["Kral Bozkurt18","937","229",0,false,"560482","1 K\u00f6y"],"849025286":["alicelik","566","0",0,false,"0","1 K\u00f6y"],"849026291":["onurerkanli","745","229",0,false,"561028","1 K\u00f6y"],"849028126":["gariban03","492","104",0,false,"0","1 K\u00f6y"],"849030080":["Satge","740","39",0,false,"561721","1 K\u00f6y"],"849030326":["Ahtoman","171","0",0,false,"0","1 K\u00f6y"],"849031879":["Aozzz","657","104",0,false,"0","1 K\u00f6y"],"849032136":["Cemcan","85","35","19.01.'de 20:27'de",false,"0","1 K\u00f6y"],"849033420":["azpilavyus","36","0","yar\u0131n \u015fu saatte 04:04",false,"0","1 K\u00f6y"],"849035267":["AikBaskan","653","96",0,false,"0","1 K\u00f6y"],"849040606":["Harun9090","1.145","96",0,false,"0","1 K\u00f6y"],"849041794":["Cemal Pa\u015fa","682","104",0,false,"0","1 K\u00f6y"],"849043570":["Kintus","835","208",0,false,"0","1 K\u00f6y"],"849048748":["MarineEngineer","178","0","16.01.'de 16:05'de",false,"0","1 K\u00f6y"],"849049922":["Jacob","1.043","96",0,false,"560713","1 K\u00f6y"],"849050981":["DesoLate38","540","268",0,false,"0","1 K\u00f6y"],"849051742":["Nasril*","454","268",0,false,"0","1 K\u00f6y"],"849054655":["Silo","474","160",0,false,"0","1 K\u00f6y"],"849054656":["RHunter","494","345",0,false,"1","1 K\u00f6y"],"849055144":["Soldier-01","526","208",0,false,"0","1 K\u00f6y"],"849055328":["dunxmaof","101","0",0,false,"0","1 K\u00f6y"],"849055367":["Penumbra","238","0","yar\u0131n \u015fu saatte 16:59",false,"0","1 K\u00f6y"],"849055500":["Irwwing","787","229",0,false,"560668","1 K\u00f6y"],"849056696":["Karamokabamba","645","198",0,false,"0","1 K\u00f6y"],"849060758":["cirak","936","268",0,false,"0","1 K\u00f6y"],"849062351":["Gargamel.","459","186",0,false,"0","1 K\u00f6y"],"849063918":["KDB17","224","0",0,false,"0","1 K\u00f6y"],"849063957":["KARTALBABA34","1.156","229",0,false,"23","1 K\u00f6y"],"849064029":["MescoCan\u0131m","91","0","19.01.'de 19:52'de",false,"0","1 K\u00f6y"],"849064130":["naimk","706","104",0,false,"0","1 K\u00f6y"],"849064560":["\u015eumenli","560","104",0,false,"0","1 K\u00f6y"],"849065902":["TR.KAOS","704","229",0,false,"11","1 K\u00f6y"],"849065966":["APOLAT","810","104",0,false,"560626","1 K\u00f6y"],"849066160":["Leo4161","499","198",0,false,"0","1 K\u00f6y"],"849066364":["Hacisakir78","36","0",0,false,"0","1 K\u00f6y"],"849067963":["TreXone","329","0",0,false,"0","1 K\u00f6y"],"849068207":["M.T.","605","104",0,false,"0","1 K\u00f6y"],"849068266":["Kar\u0131nca.","235","0",0,false,"0","1 K\u00f6y"],"849068610":["Hhaassaann11","342","0","16.01.'de 14:14'de",false,"0","1 K\u00f6y"],"849068648":["criminalwinds","270","0",0,false,"0","1 K\u00f6y"],"849068787":["CriticalHS","484","345",0,false,"6","1 K\u00f6y"],"849068954":["anl412","471","229",0,false,"0","1 K\u00f6y"],"849069014":["Bin978","409","104",0,false,"0","1 K\u00f6y"],"849069098":["furtuna","783","186",0,false,"0","1 K\u00f6y"],"849069129":["KarahanL\u0131LaR34","415","160",0,false,"23","1 K\u00f6y"],"849069558":["Eyedofthem","492","104",0,false,"0","1 K\u00f6y"],"849069564":["rhm20","590","104",0,false,"12","1 K\u00f6y"],"849069763":["umtacr0202","823","229",0,false,"0","1 K\u00f6y"],"849070173":["Kirkor Terzio\u011flu","353","208",0,false,"561798","1 K\u00f6y"],"849070188":["Memati Ba\u015f","106","0","18.01.'de 09:44'de",false,"0","1 K\u00f6y"],"849070563":["HaroonBro","933","104",0,false,"561406","1 K\u00f6y"],"849070643":["Ati\u0131taly","579","229",0,false,"0","1 K\u00f6y"],"849070856":["f\u0131rt\u0131na","354","275",0,false,"14","1 K\u00f6y"],"849070858":["karma","942","104",0,false,"561536","1 K\u00f6y"],"849070859":["zamazinqo","591","104",0,false,"561623","1 K\u00f6y"],"849070925":["dubams\u0131","134","0",0,false,"0","1 K\u00f6y"],"849070972":["CATALP10","807","208",0,false,"23","1 K\u00f6y"],"849071163":["Kralw","435","198",0,false,"0","1 K\u00f6y"],"849071171":["Bak\u0131rkaktus07","36","0",0,false,"0","1 K\u00f6y"],"849071204":["ATLANT\u0130S","625","104",0,false,"17","1 K\u00f6y"],"849071243":["DivinityVL6134","411","186",0,false,"0","1 K\u00f6y"],"849071245":["masal\u0131m","350","186",0,false,"18","1 K\u00f6y"],"849071257":["ALTA","273","0",0,false,"0","1 K\u00f6y"],"849071263":["skurt34","284","0",0,false,"8","1 K\u00f6y"],"849071290":["aragorn20","308","104","bug\u00fcn saat 22:59",false,"0","1 K\u00f6y"],"849071297":["lolopoz1","36","0","bug\u00fcn saat 23:40",false,"0","1 K\u00f6y"],"849071299":["Bushidoo","323","104","bug\u00fcn saat 23:47",false,"0","1 K\u00f6y"],"849071362":["DRselobant22","391","104","yar\u0131n \u015fu saatte 18:16",false,"15","1 K\u00f6y"],"849071472":["MetsSs","64","0","16.01.'de 20:20'de",false,"0","1 K\u00f6y"],"849071479":["Potter","385","0","16.01.'de 21:56'de",false,"1","1 K\u00f6y"],"849071481":["emine0172","197","0","16.01.'de 22:37'de",false,"18","1 K\u00f6y"],"849071553":["emyy","226","198","18.01.'de 12:49'de",false,"0","1 K\u00f6y"],"849071554":["Speales","252","198","18.01.'de 12:43'de",false,"9","1 K\u00f6y"],"849071571":["MO\u011eOLLAR","61","0","18.01.'de 00:35'de",false,"0","1 K\u00f6y"],"849071607":["berkay1748","137","208","18.01.'de 17:21'de",false,"0","1 K\u00f6y"],"849071643":["N\u0130GHTVEXA","195","0","19.01.'de 00:53'de",false,"0","1 K\u00f6y"],"849071675":["Cht27","201","0","19.01.'de 13:55'de",false,"11","1 K\u00f6y"]},"allies":{"35":["Turan","13.286","Turan","561240"],"39":["BERDU\u015e","17.680","BERDU\u015e","560710"],"70":["KUDRET","29.629","KUDRET","560650"],"96":["METEOR FOREVER","27.281","METEOR","560680"],"104":["SANCAK","22.579","SNCK","561532"],"129":["Pixel Wars","5.563","PxW","0"],"160":["Meteor Forever2","26.405","METEO2","560789"],"173":["SANCAK-F","15.800","SNCK-F","0"],"183":["SNCK-C","24.205","SNCK-C","561531"],"184":["FOFANA\u011e\u011e","26.869","FFN\u011e","0"],"186":["SANCAK-E","20.073","SNCK-E","561602"],"198":["MEHTER","7.411","MHT","561612"],"207":["ELITE TEAM","1.356","E.T","0"],"208":["SANCAK-D","12.446","SNCK-D","0"],"223":["Kara","187","Kara","0"],"229":["KUDR6T","28.775","KUDR6T","560878"],"268":["Meteor Forever3","19.363","METEO3","561045"],"275":["ZIRH2","21.534","ZIRH2","561078"],"338":["SANCAK-B","12.632","SNCK-B","561539"],"342":["Yeni","275","Yeni","0"],"345":["ZIRH3","19.818","ZIRH3","561469"]}}}];


//]]>
</script>



<table cellspacing="0" cellpadding="0">
    <tbody><tr>
	<td id="map_big" class="map_big visible" valign="top">
			<div id="worldmap" class="popup_style ui-draggable ui-draggable-handle" style="">
	<form name="worldmap" action="" method="post">
		<!--  WORLDMAP HEAD -->
		<div id="worldmap_header">
			<div class="close popup_menu">
				<a href="javascript:void(0);" onclick="Worldmap.toggle(); return false;">kapat</a>
			</div>

						<fieldset id="worldmap_settings">
				<input type="checkbox" name="worldmap_barbarian_toggle" id="worldmap_barbarian_toggle" checked="checked" onclick="Worldmap.reload();">
				<label for="worldmap_barbarian_toggle">Barbarlar</label>
				<input type="checkbox" name="worldmap_ally_toggle" id="worldmap_ally_toggle" checked="checked" onclick="Worldmap.reload();">
				<label for="worldmap_ally_toggle">Klanınız</label>
				<input type="checkbox" name="worldmap_partner_toggle" id="worldmap_partner_toggle" checked="checked" onclick="Worldmap.reload();">
				<label for="worldmap_partner_toggle">Müttefikler</label>
				<input type="checkbox" name="worldmap_nap_toggle" id="worldmap_nap_toggle" checked="checked" onclick="Worldmap.reload();">
				<label for="worldmap_nap_toggle">Saldırmazlık anlaşması (SA)</label>
				<input type="checkbox" name="worldmap_enemy_toggle" id="worldmap_enemy_toggle" checked="checked" onclick="Worldmap.reload();">
				<label for="worldmap_enemy_toggle">Düşmanlar</label>

			</fieldset>
			
			<input type="hidden" name="min_x" value="300">
			<input type="hidden" name="min_y" value="300">
		</div>

		<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/throbber.gif" id="worldmap-throbber" alt="Loading..." style="display:none" class="">

		<div id="worldmap_body">
			<div id="worldmap_image">
				<input type="image" src="/graphic/transparent.png">
			</div>
		</div>

		<div id="worldmap_footer">
			<table style="text-align:left;display:inline;">
				<tbody><tr>
					<th>Köyler</th>
					<th>Barbarlar</th>
					<th>%</th>
					<th>Klanınız</th>
					<th>%</th>
					<th>Kendi</th>
					<th>%</th>
				</tr>
				<tr>
					<td>15176</td>
					<td>7816</td>
					<td>51.5</td>
					<td>40</td>
					<td>0.26</td>
					<td>1</td>
					<td>0.01</td>
				</tr>
			</tbody></table>
		</div>
	</form>
</div>

<script type="text/javascript">
//<![CDATA[
	$(document).ready(function() {
		Worldmap.init(0);
	});
//]]>
</script>		<div class="containerBorder narrow" id="map_whole">
	<table cellspacing="0" cellpadding="0" class="map_container" style="border-spacing: 0">
		<tbody><tr>
			<td></td>
			<td align="center" onclick="TWMap.scrollBlock(0, -1); return false;" class="map_navigation">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/map/map_n.webp" alt="map/map_n.png" style="z-index:1; position:relative;" class="">
			</td>
			<td></td>
		</tr>
		<tr>
			<td align="center" onclick="TWMap.scrollBlock(-1, 0); return false;" class="map_navigation">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/map/map_w.webp" alt="map/map_w.png" style="z-index:1; position:relative;" class="">
			</td>

			<td style="padding: 0">
				<div id="map_wrap" style="position:relative;">
				 	<div id="map_coord_y_wrap" style="height:325px;">
						<div id="map_coord_y" style="position: absolute; left: 0px; top: 3320px; height: 38000px; overflow: visible;"><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3928px; left: 0px;">594</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3890px; left: 0px;">595</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3852px; left: 0px;">596</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3814px; left: 0px;">597</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3776px; left: 0px;">598</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3738px; left: 0px;">599</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3700px; left: 0px;">600</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3662px; left: 0px;">601</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3624px; left: 0px;">602</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3586px; left: 0px;">603</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3548px; left: 0px;">604</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3510px; left: 0px;">605</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3472px; left: 0px;">606</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3434px; left: 0px;">607</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3396px; left: 0px;">608</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3358px; left: 0px;">609</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3320px; left: 0px;">610</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3282px; left: 0px;">611</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3244px; left: 0px;">612</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3206px; left: 0px;">613</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3168px; left: 0px;">614</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3130px; left: 0px;">615</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3092px; left: 0px;">616</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3054px; left: 0px;">617</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -3016px; left: 0px;">618</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2978px; left: 0px;">619</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2940px; left: 0px;">620</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2902px; left: 0px;">621</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2864px; left: 0px;">622</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2826px; left: 0px;">623</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2788px; left: 0px;">624</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2750px; left: 0px;">625</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2712px; left: 0px;">626</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2674px; left: 0px;">627</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2636px; left: 0px;">628</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2598px; left: 0px;">629</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2560px; left: 0px;">630</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2522px; left: 0px;">631</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2484px; left: 0px;">632</div><div style="height: 38px; line-height: 38px; vertical-align: middle; position: absolute; top: -2446px; left: 0px;">633</div></div>
					</div>
					<div id="map_coord_x_wrap" style="width:477px; ">
						<div id="map_coord_x" style="position: absolute; left: 1749px; top: 0px; width: 53000px; overflow: visible;"><div style="width: 53px; text-align: center; position: absolute; left: -2597px; top: 0px;">451</div><div style="width: 53px; text-align: center; position: absolute; left: -2544px; top: 0px;">452</div><div style="width: 53px; text-align: center; position: absolute; left: -2491px; top: 0px;">453</div><div style="width: 53px; text-align: center; position: absolute; left: -2438px; top: 0px;">454</div><div style="width: 53px; text-align: center; position: absolute; left: -2385px; top: 0px;">455</div><div style="width: 53px; text-align: center; position: absolute; left: -2332px; top: 0px;">456</div><div style="width: 53px; text-align: center; position: absolute; left: -2279px; top: 0px;">457</div><div style="width: 53px; text-align: center; position: absolute; left: -2226px; top: 0px;">458</div><div style="width: 53px; text-align: center; position: absolute; left: -2173px; top: 0px;">459</div><div style="width: 53px; text-align: center; position: absolute; left: -2120px; top: 0px;">460</div><div style="width: 53px; text-align: center; position: absolute; left: -2067px; top: 0px;">461</div><div style="width: 53px; text-align: center; position: absolute; left: -2014px; top: 0px;">462</div><div style="width: 53px; text-align: center; position: absolute; left: -1961px; top: 0px;">463</div><div style="width: 53px; text-align: center; position: absolute; left: -1908px; top: 0px;">464</div><div style="width: 53px; text-align: center; position: absolute; left: -1855px; top: 0px;">465</div><div style="width: 53px; text-align: center; position: absolute; left: -1802px; top: 0px;">466</div><div style="width: 53px; text-align: center; position: absolute; left: -1749px; top: 0px;">467</div><div style="width: 53px; text-align: center; position: absolute; left: -1696px; top: 0px;">468</div><div style="width: 53px; text-align: center; position: absolute; left: -1643px; top: 0px;">469</div><div style="width: 53px; text-align: center; position: absolute; left: -1590px; top: 0px;">470</div><div style="width: 53px; text-align: center; position: absolute; left: -1537px; top: 0px;">471</div><div style="width: 53px; text-align: center; position: absolute; left: -1484px; top: 0px;">472</div><div style="width: 53px; text-align: center; position: absolute; left: -1431px; top: 0px;">473</div><div style="width: 53px; text-align: center; position: absolute; left: -1378px; top: 0px;">474</div><div style="width: 53px; text-align: center; position: absolute; left: -1325px; top: 0px;">475</div><div style="width: 53px; text-align: center; position: absolute; left: -1272px; top: 0px;">476</div><div style="width: 53px; text-align: center; position: absolute; left: -1219px; top: 0px;">477</div><div style="width: 53px; text-align: center; position: absolute; left: -1166px; top: 0px;">478</div><div style="width: 53px; text-align: center; position: absolute; left: -1113px; top: 0px;">479</div><div style="width: 53px; text-align: center; position: absolute; left: -1060px; top: 0px;">480</div><div style="width: 53px; text-align: center; position: absolute; left: -1007px; top: 0px;">481</div><div style="width: 53px; text-align: center; position: absolute; left: -954px; top: 0px;">482</div><div style="width: 53px; text-align: center; position: absolute; left: -901px; top: 0px;">483</div><div style="width: 53px; text-align: center; position: absolute; left: -848px; top: 0px;">484</div><div style="width: 53px; text-align: center; position: absolute; left: -795px; top: 0px;">485</div><div style="width: 53px; text-align: center; position: absolute; left: -742px; top: 0px;">486</div><div style="width: 53px; text-align: center; position: absolute; left: -689px; top: 0px;">487</div><div style="width: 53px; text-align: center; position: absolute; left: -636px; top: 0px;">488</div><div style="width: 53px; text-align: center; position: absolute; left: -583px; top: 0px;">489</div><div style="width: 53px; text-align: center; position: absolute; left: -530px; top: 0px;">490</div></div>
					</div>
					<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/fullscreen.webp" id="fullscreen" onclick="TWMap.goFullscreen()" alt="" class="" style="display: inline;">
                    <div id="map-ctx-buttons">
                        <a class="mp" id="mp_res" href="/game.php?screen=map" data-title="Hammadde gönder" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_att" href="/game.php?screen=map" data-title="Birlik gönder" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_lock" href="/game.php?screen=map" data-title="Köyü rezerve et" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_unlock" href="/game.php?screen=map" data-title="Rezervasyonu sil" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_fav" href="/game.php?screen=map" data-title="Favorilere ekle" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_unfav" href="/game.php?screen=map" data-title="Favorilerden sil" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_msg" href="/game.php?screen=map" data-title="Mesaj yaz" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_profile" href="/game.php?screen=map" data-title="Oyuncu profilini göster" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_overview" href="/game.php?screen=map" data-title="Köye genel bakış" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_recruit" href="/game.php?screen=map" data-title="Asker toplama" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_tab" href="/game.php?screen=map" data-title="Yeni bir sekmede göster" style="opacity: 0; display: none;"></a>
                        <a class="mp" id="mp_info" href="/game.php?screen=map" data-title="Köy bilgileri" style="opacity: 0; display: none;"></a>
                    </div>
																		<a class="mp farmassistant-tooltip" data-minspeed="0.00075757575757576" id="mp_farm_a" href="/game.php?screen=map" data-tooltip-tpl="&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;15&lt;br /&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;2&lt;br /&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;1&lt;br /&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_knight.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;1&lt;br /&gt;&lt;span class=&quot;icon   header ressources&quot; title=&quot;Hammaddeler&quot;&gt; &lt;/span&gt;515&lt;br /&gt;" data-has-no-units="false" ,="" data-template="{&quot;id&quot;:6324,&quot;name&quot;:&quot;a&quot;,&quot;min_speed&quot;:0.0007575757575757576,&quot;tooltip&quot;:&quot;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_spear.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;15&lt;br \/&gt;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_sword.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;2&lt;br \/&gt;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_axe.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;1&lt;br \/&gt;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_knight.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;1&lt;br \/&gt;&lt;span class=\&quot;icon   header ressources\&quot; title=\&quot;Hammaddeler\&quot;&gt; &lt;\/span&gt;515&lt;br \/&gt;&quot;,&quot;has_no_units&quot;:false,&quot;spear&quot;:15,&quot;sword&quot;:2,&quot;axe&quot;:1,&quot;spy&quot;:0,&quot;light&quot;:0,&quot;heavy&quot;:0,&quot;ram&quot;:0,&quot;catapult&quot;:0,&quot;knight&quot;:1,&quot;snob&quot;:0,&quot;militia&quot;:0}" style="opacity: 0; display: none;"></a>
													<a class="mp farmassistant-tooltip" data-minspeed="0.00075757575757576" id="mp_farm_b" href="/game.php?screen=map" data-tooltip-tpl="&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_spear.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;20&lt;br /&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;5&lt;br /&gt;&lt;img src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_axe.webp&quot; title=&quot;&quot; alt=&quot;&quot; class=&quot;&quot; /&gt;1&lt;br /&gt;&lt;span class=&quot;icon   header ressources&quot; title=&quot;Hammaddeler&quot;&gt; &lt;/span&gt;585&lt;br /&gt;" data-has-no-units="false" ,="" data-template="{&quot;id&quot;:6325,&quot;name&quot;:&quot;b&quot;,&quot;min_speed&quot;:0.0007575757575757576,&quot;tooltip&quot;:&quot;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_spear.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;20&lt;br \/&gt;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_sword.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;5&lt;br \/&gt;&lt;img src=\&quot;https:\/\/dstr.innogamescdn.com\/asset\/c645ceed\/graphic\/unit\/unit_axe.webp\&quot; title=\&quot;\&quot; alt=\&quot;\&quot; class=\&quot;\&quot; \/&gt;1&lt;br \/&gt;&lt;span class=\&quot;icon   header ressources\&quot; title=\&quot;Hammaddeler\&quot;&gt; &lt;\/span&gt;585&lt;br \/&gt;&quot;,&quot;has_no_units&quot;:false,&quot;spear&quot;:20,&quot;sword&quot;:5,&quot;axe&quot;:1,&quot;spy&quot;:0,&quot;light&quot;:0,&quot;heavy&quot;:0,&quot;ram&quot;:0,&quot;catapult&quot;:0,&quot;knight&quot;:0,&quot;snob&quot;:0,&quot;militia&quot;:0}" style="opacity: 0; display: none;"></a>
																<a class="mp" id="mp_invite" href="/game.php?screen=map" data-title="Oyuncu davet et" style="opacity: 0; display: none;"></a>
					<a class="mp" id="mp_invite_hide" href="/game.php?screen=map" data-title="Davet ipucunu gizle" style="opacity: 0; display: none;"></a>

					<a id="map" href="#" style="width:477px; height:342px;overflow:hidden;position:relative;background-image:url('https://dstr.innogamescdn.com/asset/c645ceed/graphic/map_new/gras4.webp');" class="ui-resizable">
						<div id="map_blend" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; background-color: black; z-index: 20; opacity: 0; display: none;"></div>
					<div style="position: absolute; left: 1749px; top: 3320px; z-index: 1; overflow: visible;" id="map_container"><div style="position: absolute; left: -1538.5px; top: -3180px; z-index: 4; width: 56px; height: 62px; background-image: url(&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic//map/home.png&quot;);"></div><div style="width: 265px; height: 190px; position: absolute; left: -1855px; top: -3320px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><canvas width="18" height="18" style="position: absolute; left: 0px; top: 76px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_13354" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; opacity: 0.4; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img id="map_village_12589" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img id="map_village_12277" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><canvas width="18" height="18" style="position: absolute; left: 159px; top: 38px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_3455" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><img id="map_village_12509" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div><div style="width: 265px; height: 190px; position: absolute; left: -1855px; top: -3130px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0111.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0100.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img id="map_village_12849" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div><div style="width: 265px; height: 190px; position: absolute; left: -1590px; top: -3320px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img id="map_village_12267" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/see.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><canvas width="18" height="18" style="position: absolute; left: 53px; top: 152px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_12218" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img id="map_village_undefined" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/ghost.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img id="map_village_11875" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><img id="map_village_12012" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><img id="map_village_12333" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><canvas width="18" height="18" style="position: absolute; left: 212px; top: 38px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_12390" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div><div style="width: 265px; height: 190px; position: absolute; left: -1590px; top: -3130px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0101.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0100.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><canvas width="18" height="18" style="position: absolute; left: 159px; top: 114px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_13800" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; opacity: 0.4; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0100.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img id="map_village_12659" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div><div style="width: 265px; height: 190px; position: absolute; left: -1325px; top: -3320px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img id="map_village_11938" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/see.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0011.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><canvas width="18" height="18" style="position: absolute; left: 159px; top: 76px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_3445" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0101.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><canvas width="18" height="18" style="position: absolute; left: 212px; top: 76px; z-index: 4; margin-top: 0px; margin-left: 0px;"></canvas><img id="map_village_11433" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1101.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1011.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div><div style="width: 265px; height: 190px; position: absolute; left: -1325px; top: -3130px;"><div class="map_border" style="z-index: 3; position: absolute; width: 1px; height: 190px; left: 0px; top: 0px;"></div><div class="map_border" style="z-index: 3; position: absolute; height: 1px; width: 265px; left: 0px; top: 0px;"></div><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1000.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest1011.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0010.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 0px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0100.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 53px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 106px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 0px;"><img id="map_village_12615" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/v1_left.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras4.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras3.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 159px; top: 152px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0111.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 0px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras2.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 38px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0001.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 76px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/gras1.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 114px;"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic///map_new/forest0101.png" style="position: absolute; z-index: 2; width: 53px; height: 38px; left: 212px; top: 152px;"></div></div><div id="map_mover" class="needsclick" style="position: absolute; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 12; background-image: url(&quot;/graphic/map/empty.png&quot;); cursor: move; -moz-user-select: none;"></div><div class="ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se" style="z-index: 13;"></div></a>
					<div id="special_effects_container"></div>
				<div id="map_go_home_boundary"><div id="map_go_home" style="left: 24px; top: 5.68434e-14px; display: none;"><div id="map_go_home_pointer" style="transform: rotate(0rad);"></div><div id="map_go_home_circle"><div id="map_go_home_text">0</div></div></div></div></div>
			</td>

			<td align="center" onclick="TWMap.scrollBlock(1, 0); return false;" class="map_navigation">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/map/map_e.webp" alt="map/map_e.png" style="z-index:1; position:relative;" class="">
			</td>
		</tr>

		<tr>
			<td></td>

			<td align="center" onclick="TWMap.scrollBlock(0, 1); return false;" class="map_navigation">
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/map/map_s.webp" alt="map/map_s.png" style="z-index:1; position:relative;" class="">
			</td>

			<td></td>
		</tr>
	</tbody></table>
	</div>
				<br>
		<div id="map_legend" class="containerBorder map-legend-container">
<table>
	<tbody><tr class="nowrap" data-category="standard">
		<td class="small" valign="top">Standart: </td>

		<td>
			<div class="map_legend" data-id="current" data-active="1">
				<div style="background-color:rgb(255,255,255)"></div> <span>Geçerli köyün</span>
			</div>

			<div class="map_legend" data-id="own" data-active="0">
				<div style="background-color:rgb(240,200,0)"></div> <span>Kendi köylerin</span>
			</div>

			<div class="map_legend" data-id="buddy" data-active="1">
				<div style="background-color:rgb(69,255,146)"></div> <span>Arkadaşlar</span>
			</div>

			<div class="map_legend" data-id="ally" data-active="1">
				<div style="background-color:rgb(0,0,244)"></div> <span>Klanınız</span>
			</div>

			<div class="map_legend" data-id="barbarian" data-active="1">
				<div style="background-color:rgb(150,150,150)"></div> <span>Barbar Köyler</span>
			</div>
			<div class="map_legend" data-id="other" data-active="1">
				<div style="background-color:rgb(130,60,10)"></div> <span>Diğer</span>
			</div>
		</td>
	</tr>

	<tr class="nowrap" data-category="tribal">
		<td class="small" valign="top">Klan:</td>
		<td>
			<div class="map_legend" data-id="partner" data-active="1">
				<div style="background-color:rgb(0,160,244)"></div> <span>Müttefikler</span>
			</div>

			<div class="map_legend" data-id="nap" data-active="1">
				<div style="background-color:rgb(128,0,128)"></div> <span>Ateşkes Anlaşması</span>
			</div>

			<div class="map_legend" data-id="enemy" data-active="0">
				<div style="background-color:rgb(244,0,0)"></div> <span>Düşmanlar</span>
			</div>
		</td>
	</tr>

	<tr class="nowrap" data-category="own">
		<td class="small" valign="top">Kendine ait:</td>
		<td>
				</td>
	</tr>	

	<tr class="nowrap" data-category="other">
		<td class="small" valign="top">Diğerleri:</td>
		<td>
				</td>
	</tr>
</tbody></table>
</div>
<br>
<div style="float: left;">
</div>
	<div style="width:100%; clear:both;">
	<a onclick="$('#village_colors').toggle();" href="javascript:void(0);">» Harita vurguları</a>
	</div>
	<br>
	<div id="village_colors" class="containerBorder" style="display:none; clear:both;">
	<table style="background-color: #f4e4bc; border:solid 1px #8c5f0d;">
	<tbody><tr>
		<td valign="top">
			<h5>Kendi köylerin</h5>
									  <br>
			  <div id="own_villages" style="left:700px;
top:200px">
	<div id="edit_color_popup_menu" class="popup_menu"><a id="tut_min" href="#" onclick="$('#own_villages').hide();return false;">kapat</a></div>

	<div style="padding:10px;background-image:url('https://dstr.innogamescdn.com/asset/c645ceed/graphic//background/content.jpg')">
        <strong>Grup seç</strong><br><br>
        <form method="post" action="/game.php?village=12218&amp;screen=map&amp;action=add_own_group&amp;">
         <select name="add_group">
                                                                                                      <option value="18171">Tam Saldırı</option>

                                                                                                                             <option value="18172">Gelen Saldırı</option>

                                                                                                                             <option value="18173">Misyoner var</option>

                                                          </select>
         <input class="btn" type="submit" value="Ekle">
        <input type="hidden" name="h" value="58fce238"></form>
	</div>
</div>			  <a href="#" onclick="ColorGroups.Own.toggleCreation(event);return false;">» Kendi grubunu ekle</a>
					</td>
		 <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
			<td valign="top">
			<h5>Yabancı köyler</h5>
			<table class="vis" id="for_groups">
				<tbody id="for_color_groups" class="ui-sortable" style="">
									</tbody>
				<tbody><tr id="new_group" style="display:none">
					<td colspan="5">
						<form method="post" action="/game.php?village=12218&amp;screen=map&amp;type=for&amp;action=add_for_group&amp;">
							<input type="text" name="new_group_name" onkeydown="if (event.keyCode == 13) $('#for_new_group').click();">
							<input class="btn" type="submit" name="for_new_group" id="for_new_group" value="Oluştur">
						<input type="hidden" name="h" value="58fce238"></form>
					</td>
				</tr>
			</tbody></table>
			<br>
			<a href="#" onclick="ColorGroups.Other.startCreation(); return false;">» Yeni grup oluştur</a>
		</td>
	</tr>
	</tbody></table>
	</div>
	<script>
		$(function() {
			ColorGroups.init('/game.php?village=12218&screen=map&ajaxaction=load_edit_color&&h=58fce238', '/game.php?village=12218&amp;screen=map&amp;ajaxaction=load_for_multiple_villages&amp;&amp;h=58fce238');

					});
	</script>

		<script type="text/javascript">
		//<![CDATA[
		
				
											
					TWMap.allyRelations[104] = 'partner';
					TWMap.allyRelations[183] = 'partner';
					TWMap.allyRelations[208] = 'partner';
					TWMap.allyRelations[253] = 'nap';
					TWMap.allyRelations[335] = 'nap';
					TWMap.allyRelations[338] = 'partner';
		
                    TWMap.friends[848939758] = true;
        
		
		
		
		//]]>
		</script>
	
	
		</td>

	<td id="map_topo" class="map_topo" valign="top">
		<div class="containerBorder" id="minimap_whole">
		<table cellspacing="0" cellpadding="0" class="map_container minimap_container" style="border-spacing: 0">
			<tbody><tr>
				<td align="center">
					<img alt="Kuzeybatı" class="dir_arrow" onclick="TWMap.scrollBlock(-1, -1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_nw.png?1">
				</td>
				<td align="center">
					<img alt="Kuzey" class="dir_arrow" onclick="TWMap.scrollBlock(0, -1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_n.png?1">
				</td>
				<td align="center">
					<img alt="Kuzeydoğu" class="dir_arrow" onclick="TWMap.scrollBlock(1, -1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_ne.png?1">
				</td>
			</tr>
			<tr>
				<td align="center">
					<img alt="Batı" class="dir_arrow" onclick="TWMap.scrollBlock(-1, 0); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_w.png?1">
				</td>
				<td style="padding: 0" id="minimap_cont">
					<div id="minimap" style="overflow:hidden; position:relative; padding:0px;width:250px; height:250px" class="ui-resizable">
						<div id="minimap_viewport" style="border: 1px solid white; position: absolute; z-index: 10; width: 45px; height: 45px; left: 100px; top: 100px;"></div>
					<div style="position: absolute; left: -2235px; top: -2950px; z-index: 1; overflow: visible;" id="minimap_container"><div style="width: 250px; height: 250px; position: absolute; left: 2000px; top: 2750px;"><img src="/page.php?page=topo_image&amp;player_id=849071243&amp;x=400&amp;y=550&amp;church=0&amp;possible_church=0&amp;attack_planner=0&amp;watchtower=0&amp;key=2882651525&amp;cur=12218&amp;focus=0&amp;local_cache=34&amp;relics=0&amp;village_id=12218" style="position: absolute; z-index: 1; left: 0px; top: 0px;"></div><div style="width: 250px; height: 250px; position: absolute; left: 2000px; top: 3000px;"><img src="/page.php?page=topo_image&amp;player_id=849071243&amp;x=400&amp;y=600&amp;church=0&amp;possible_church=0&amp;attack_planner=0&amp;watchtower=0&amp;key=2882651525&amp;cur=12218&amp;focus=0&amp;local_cache=34&amp;relics=0&amp;village_id=12218" style="position: absolute; z-index: 1; left: 0px; top: 0px;"></div><div style="width: 250px; height: 250px; position: absolute; left: 2250px; top: 2750px;"><img src="/page.php?page=topo_image&amp;player_id=849071243&amp;x=450&amp;y=550&amp;church=0&amp;possible_church=0&amp;attack_planner=0&amp;watchtower=0&amp;key=2882651525&amp;cur=12218&amp;focus=0&amp;local_cache=34&amp;relics=0&amp;village_id=12218" style="position: absolute; z-index: 1; left: 0px; top: 0px;"></div><div style="width: 250px; height: 250px; position: absolute; left: 2250px; top: 3000px;"><img src="/page.php?page=topo_image&amp;player_id=849071243&amp;x=450&amp;y=600&amp;church=0&amp;possible_church=0&amp;attack_planner=0&amp;watchtower=0&amp;key=2882651525&amp;cur=12218&amp;focus=0&amp;local_cache=34&amp;relics=0&amp;village_id=12218" style="position: absolute; z-index: 1; left: 0px; top: 0px;"></div></div><div id="minimap_mover" class="needsclick" style="position: absolute; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 12; background-image: url(&quot;/graphic/map/empty.png&quot;); cursor: move; -moz-user-select: none;"></div><div class="ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se" style="z-index: 13;"></div></div>
				</td>
				<td align="center">
					<img alt="Doğu" class="dir_arrow" onclick="TWMap.scrollBlock(1, 0); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_e.png?1">
				</td>
			</tr>
			<tr>
				<td align="center">
					<img alt="Güneybatı" class="dir_arrow" onclick="TWMap.scrollBlock(-1, 1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_sw.png?1">
				</td>
				<td align="center">
					<img alt="Güney" class="dir_arrow" onclick="TWMap.scrollBlock(0, 1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_s.png?1">
				</td>
				<td align="center">
					<img alt="Güneydoğu" class="dir_arrow" onclick="TWMap.scrollBlock(1, 1); return false;" style="z-index: 1; position: relative;" src="/graphic/map/map_se.png?1">
				</td>
			</tr>
		</tbody></table>
		</div>
		<div id="map_config">
					<div style="margin-top:10px;margin-bottom:10px;">
							<a href="javascript:void(0);" onclick="Worldmap.toggle()">» Dünya Haritasını Göster</a><br>
										<a href="/game.php?village=12218&amp;screen=notes">» Köy Notlarını Gör</a><br>
						</div>
		
						<table id="map_search" class="target-select vis" data-on-choice="TWMap.onSearchChoice" style="width:100%">
    <tbody><tr><th>Ara</th></tr>
    <tr>
        <td>
            <div class="target-types">
                <label><input type="radio" name="target_type" value="player_name" checked=""> Oyuncu İsmi</label>
                <label><input type="radio" name="target_type" value="village_name"> Köy adı</label>
            </div>

            <div class="target-input float_left">
                <input type="text" name="input" class="target-input-field target-input-autocomplete ui-autocomplete-input" data-type="player" value="" autocomplete="off" tabindex="14" data-no-suggestions-hint="Sonuç yok" data-ignore-single-exact-match="1" placeholder="Oyuncu ismini gir">
            </div>
        </td>
    </tr>
</tbody></table>

<script>
    // this will be attached to the search widget
    TWMap.onSearchChoice = function(village) {
        TWMap.focusUserSpecified(village.x, village.y);
        this.removeConfirmedVillage(); // "this" references the search widget
    };

    $(function() {
        var search_widget = new TargetSelection($('#map_search')[0]);
    });
</script>		<br>
								<table class="vis" style="width: 100%">
    <thead>
        <tr><th>Hızlı Komutlar</th></tr>
    </thead>
    <tbody>
        <tr>
            <td>
                <form id="quick_command_inputs">
                    <select id="troop_template_selection">
                        <option value="0">Şablon seçiniz...</option>
                        <option value="all">Tüm birlikler</option>
                                            </select><br>

                    <input type="checkbox" id="attack_checkbox" name="attack" value="1" disabled="">
                    <label for="attack_checkbox" class="" disabled="disabled"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack.webp"> Saldırı</label>
                    <br>

                    <input type="checkbox" id="support_checkbox" name="support" value="1" disabled="">
                    <label for="support_checkbox" class="" disabled="disabled"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/support.webp"> Destekler</label>
                </form>
            </td>
        </tr>
    </tbody>
</table>

<script>
QuickCommands.init();
</script>
		<br>
		
					<table class="vis" style="border-spacing:0px;border-collapse:collapse;" width="100%">
    <tbody><tr>
        <th colspan="3">Görüntüleme seçenekleri</th>
	</tr>

            <tr>
            <td><input type="checkbox" name="non_attackable_hide" onclick="TWMap.non_attackable_hide.toggle();" id="non_attackable_hide" checked="checked"></td>
            <td colspan="2"><label for="non_attackable_hide">Saldırılamayan köyleri sakla</label></td>
        </tr>

                    <tr>
            <td>
                <input type="checkbox" name="belief_radius" onclick="TWMap.church.toggle(false, this);" id="belief_radius">
            </td>
            <td colspan="2">
                <label for="belief_radius">İnanç alanını göster</label>
            </td>
        </tr>
    
	
                    <tr>
            <td><input type="checkbox" name="relics_enabled" onclick="TWMap.relics.toggle();" id="relics_enabled"></td>
            <td colspan="2"><label for="relics_enabled">Kalıntı etki alanını göster</label></td>
        </tr>
    
                    <tr>
            <td><input type="checkbox" name="belief_radius_2" onclick="TWMap.church.toggle(true, this);" id="belief_radius_2"></td>
            <td><label for="belief_radius_2">Olası Tapınak Etkisini Göster</label></td>
            <td width="18"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic//icons/slide_down.png" class="church_options_toggler"></td>
        </tr>
        <tr id="church_options" style="display: none;">
            <td colspan="3" style="padding-left:8px;">
                <label><input type="checkbox" name="church_level[]" value="1" onclick="TWMap.church.toggle(false, this);" id="church_level_1">1nci Seviye Tapınak</label><br>
                <label><input type="checkbox" name="church_level[]" value="2" onclick="TWMap.church.toggle(false, this);" id="church_level_2">2nci Seviye Tapınak</label><br>
                <label><input type="checkbox" name="church_level[]" value="3" onclick="TWMap.church.toggle(false, this);" id="church_level_3">3ncü Seviye Tapınak</label>
            </td>
        </tr>
    
    
    <tr><td colspan="3"><hr></td></tr>
    <tr>
    <td colspan="3">
        <h5 class="popup_options_toggler" style="margin:0" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic//icons/slide_down.png">
            Açılır pencere ayarları
            <img class="popup_options_toggler" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic//icons/slide_down.png" style="float:right;">
        </h5>
    </td>
</tr>

<tr id="popup_options" style="display: none;">
    <td colspan="3" style="padding-left:8px">
        
        <form id="form_map_popup">
            <table>
                <tbody><tr>
                    <td>
                        <input type="checkbox" id="map_popup_attack" name="map_popup_attack" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_attack">Son saldırıyı göster</label>
                    </td>
                </tr>

                                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_attack_intel" name="map_popup_attack_intel" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_attack_intel">İletilen saldırıların bilgisini göster</label>
                    </td>
                </tr>

                                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_moral" name="map_popup_moral" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_moral">Morali göster</label>
                    </td>
                </tr>
                                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_res" name="map_popup_res" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_res">Hammaddeleri göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_pop" name="map_popup_pop" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_pop">Nüfusu göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_trader" name="map_popup_trader" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_trader">Tüccarları göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_reservation" name="map_popup_reservation" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_reservation">Rezervasyonları göster</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_units" name="map_popup_units" onclick="$('#map_popup_units_home').prop('disabled', this.checked ? '' : 'disabled').attr('checked', '')" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_units">Birlikleri göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_units_home" name="map_popup_units_home" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_units_home">Yerel birlikleri göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_units_times" name="map_popup_units_times" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_units_times">Gelişim sürelerini göster</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_buildings" name="map_popup_buildings" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_buildings">Bina seviyelerini göster *</label>
                    </td>
                </tr>

                                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_flag" name="map_popup_flag" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_flag">Bayrak göster *</label>
                    </td>
                </tr>
                
                                    <tr>
                        <td>
                            <input type="checkbox" id="map_popup_relic" name="map_popup_relic" checked="checked">
                        </td>
                        <td>
                            <label for="map_popup_relic">Kalıntıyı Göster *</label>
                        </td>
                    </tr>
                
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_notes" name="map_popup_notes" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_notes">Köy notlarını göster</label>
                                            </td>
                </tr>

                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_incoming" name="map_popup_incoming" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_incoming">Komutları göster</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_mood" name="map_popup_mood" checked="checked">
                    </td>
                    <td>
                        <label for="map_popup_mood">Sadakati göster *</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="map_popup_groups" name="map_popup_groups">
                    </td>
                    <td>
                        <label for="map_popup_groups">Grupları göster *</label>
                    </td>
                </tr>

                <tr><td colspan="3"><i style="font-size: smaller; color:grey; padding:2px 3px;">* kendi köylerin</i></td></tr>
            </tbody></table>
        </form>
    </td>
</tr>
</tbody></table>
</div>
<br>		
				<form action="" method="post">
		    <table class="vis" width="100%" style="border-spacing:0px;border-collapse:collapse;">
			<tbody><tr>
			    <th colspan="3">Haritayı ortala</th>
			</tr>
			<tr>
			    <td class="nowrap">
			    x:&nbsp;<input type="text" name="x" id="mapx" class="centercoord" value="471" style="width: 30px" onkeyup="xProcess('mapx', 'mapy')">
			    y:&nbsp;<input type="text" name="y" id="mapy" class="centercoord" value="614" style="width: 30px">
			    </td>
			    <td>
				<input class="btn float_right" type="submit" onclick="return TWMap.focusSubmit();" value="Merkez">
			    </td>
			</tr>
		    </tbody></table>
		</form>

							<br>
<table class="vis" width="100%">
	<tbody><tr>
		<th colspan="2">Harita boyutunu değiştir:</th>
	</tr>
	<tr>
		<td><table cellspacing="0"><tbody><tr>
		<td width="80">Harita: </td>
		<td>
			<select id="map_chooser_select" onchange="TWMap.resize(parseInt($('#map_chooser_select').val()), true)">
				<option id="current-map-size" value="9x9" style="display:none;">
				9x9</option>
								<option value="4">4x4</option>
								<option value="5">5x5</option>
								<option value="7">7x7</option>
								<option value="9" selected="selected">9x9</option>
								<option value="11">11x11</option>
								<option value="13">13x13</option>
								<option value="15">15x15</option>
								<option value="20">20x20</option>
								<option value="30">30x30</option>
											</select>
			</td>
						<td valign="middle">
				<img class="" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic//questionmark.png" data-title="Haritanın boyutunu fareyle istediğin gibi değiştirebilirsin">
			</td>
						</tr></tbody></table>
			<input type="hidden" value="/game.php?village=12218&amp;screen=settings&amp;ajaxaction=set_map_size&amp;h=58fce238" id="change_map_size_link">
		</td>
	</tr>
	<tr>
		<td><table cellspacing="0"><tbody><tr>
		<td width="80">Küçük harita: </td>
		<td colspan="2">
			<select id="minimap_chooser_select" onchange="TWMap.resizeMinimap(parseInt($('#minimap_chooser_select').val()), true)">
				<option id="current-minimap-size" value="50x50" style="display:none;">
				50x50</option>
								<option value="20">20x20</option>
								<option value="30">30x30</option>
								<option value="40">40x40</option>
								<option value="50" selected="selected">50x50</option>
								<option value="60">60x60</option>
								<option value="70">70x70</option>
								<option value="80">80x80</option>
								<option value="90">90x90</option>
								<option value="100">100x100</option>
								<option value="110">110x110</option>
								<option value="120">120x120</option>
							</select>
			</td>
			</tr></tbody></table>
			<input type="hidden" value="/game.php?village=12218&amp;screen=settings&amp;ajaxaction=set_map_size&amp;h=58fce238" id="change_map_size_link">
		</td>
	</tr>
</tbody></table>

			</td>
    </tr>
</tbody></table>

	<script type="text/javascript">
//<![CDATA[

$(document).ready(function() {
	
		    MapCanvas.church_data = [[471,614,6]];
	
            MapCanvas.villages_with_relics = [[471,614,1,[65,65,65]]];
    
            MapCanvas.init();
    
	
	TWMap.autoPixelSize = $(window).width() - 100;
	TWMap.autoSize = Math.ceil(TWMap.autoPixelSize / TWMap.tileSize[0]);

			TWMap.size = [9, 9];
	
	TWMap.popup.extraInfo = true;

    TWMap.relics.displayed = false;
	TWMap.church.displayed = false;
    TWMap.church.possible_displayed = false;
    TWMap.church.levels = [];
    if(TWMap.church.levels == null) {
        TWMap.church.levels = [];
    }

	TWMap.init();

            TWMap.focus(471, 614);
    
		TWMap.minimap.createResizer([20, 20], [120,120], 5);
	TWMap.map.createResizer([4,4], [30,30]);
	
	
	// Allow resize of map when iPhone/Android phone is flipped.

	if(mobile) {
		var resizeTimer = null;
		var flippingSupported = "onorientationchange" in window,
			flipEvent = flippingSupported ? "orientationchange" : "resize";

		window.addEventListener(flipEvent, function() {
			var autoSelected = (parseInt($('#map_chooser_select').val()) == 0);
			if(autoSelected) {
				if (resizeTimer === null) {
					resizeTimer = setTimeout(function() {
						TWMap.resize(0, false);
						resizeTimer = null;
					}, 500);
				}
			}
		}, false);
	}
	
});
//]]>
</script>


<script type="text/html" id="tpl_popup">

	<table id="info_content" class="vis">
<% if (special == 'ghost') { %>
	<tr>
		<th colspan="2">Davet yeri</th>
	</tr>
	<tr>
		<td colspan="2">Bir arkadaşını yakınına davet et!</td>
	</tr>
<% } else { %>

<% if (bonus) { %>
	<tr id="info_bonus_image_row" >
		<td id="info_bonus_image" rowspan="99"><img src="<%= bonus.img %>" /></td>
	</tr>
<% } /* end bonus */ %>

	<tr>
				<th colspan="2"><%=name%> <%== '(%x%|%y%) K%continent%' %></th>
	</tr>


<% if (bonus) { %>
	<tr id="info_bonus_text_row">
		<td colspan="2"><strong id="info_bonus_text"><%= bonus.text %></strong></td>
	</tr>
<% } /* end bonus */ %>
<% if (points) { %>
	<tr id="info_points_row">
		<td width="100px">Puan:</td>
		<td id="info_points"><%= points %></td>
	</tr>
<% } /* end points */ %>
<% if (owner) { %>
	<tr id="info_owner_row">
		<td>Sahibi:</td>
		<td>
			<% if (owner_image) { %>
			    <img src="<%= owner_image %>" alt="" class="userimage-tiny" />
			<% } %>

            <%== '%name% (%points% Points &#124; %village_count_text%)', owner %>		</td>
	</tr>
<% } else if (points == 0) { %>
	<tr id="info_left_row">
		<td colspan="2">Etkinlik yeri</td>
	</tr>
		<% } else if (extra && extra.type == "standard") { %>
	<tr id="info_left_row">
		<td colspan="2">Terk edilmiş</td>
	</tr>
<% } /* end owner */ %>

<% if (ally) { %>
	<tr id="info_ally_row">
		<td>Klan:</td>
		<td>
			<% if (ally_image) { %>
			<img src="<%= ally_image %>" alt="" class="userimage-tiny" />
			<% } %>
			<%== '%name% (%points% Puan)', ally %>		</td>
	</tr>
<% } /* end ally */ %>



<% if (extra && extra.reservation && $('#map_popup_reservation').is(":checked")) { %>
	<tr><td>Rezervasyon yaptıran:</td><td id="info_reserved_by"><%= extra.reservation.name %> [<%= extra.reservation.ally%>]</td></tr>
	<tr><td>Rezervasyonun bitiş tarihi:</td><td id="info_reserved_till"><%= extra.reservation.expires_at %></td></tr>
<% } %>


<% if (extra && extra.attack && $('#map_popup_attack').is(":checked")) { %>
	<tr>
		<td>Son Saldırı:</td>
		<td id="info_last_attack">
			<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/<%= TWMap.popup.attackDots[extra.attack.dot]%>" title="" alt="" class="" />

						<% if (extra.attack.dot != 4) { %>
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/<%= TWMap.popup.attackMaxLoot[extra.attack.max_loot]%>" title="" alt="" class="" />
			<% } %>

			<%= extra.attack.time %>
		</td>
	</tr>
<% } %>


<% if (extra && extra.attack_intel && $('#map_popup_attack_intel').is(":checked")) { %>
	<tr>
		<td>En son iletilen: </td>
		<td id="info_last_attack_intel">
			<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/<%= TWMap.popup.attackDots[extra.attack_intel.dot]%>" title="" alt="" class="" />

						<% if (extra.attack_intel.dot != 4) { %>
				<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/<%= TWMap.popup.attackMaxLoot[extra.attack_intel.max_loot]%>" title="" alt="" class="" />
			<% } %>

			<%= extra.attack_intel.time %>
			<% if (extra.attack_intel.start_player) { %>
				<%== '%start_player% adlı oyuncudan gelen', extra.attack_intel %>			<% } %>
		</td>
	</tr>
<% } %>


<% if (extra && extra.morale && $('#map_popup_moral').is(":checked") && TWMap.morale) { %>
	<tr id="info_moral_row">
		<td>Moral:</td>
		<td id="info_moral"><%= Math.round(100 * extra.morale) %>%</td>
	</tr>
<% } %>

<% if (extra && extra.valor) { %>
<tr id="info_valor_row">
	<td>Değer:</td>
	<td id="info_valor"><%= Math.round(100 * extra.valor) %>%</td>
</tr>
<% } %>

<% if (extra && extra.groups && extra.groups.length) { %>
	<tr id="info_village_groups_row">
		<td>Gruplar:</td>
		<td id="info_village_groups"><%= escapeHtml(extra.groups.join(', ')) %></td>
	</tr>
<% } %>

<% if (extra && extra.flag && $('#map_popup_flag').is(":checked")) { %>
	<tr id="info_flag">
		<td>Bayrak: </td>
		<td id="info_village_flag"><img src="<%= extra.flag.image_path %>"> <%= extra.flag.short_desc %></td>
	</tr>
<% } %>

<% if (extra && extra.relic && $('#map_popup_relic').is(":checked")) { %>
<tr id="info_relic">
	<td>Kalıntı:</td>
	<td id="info_village_relic" class="<%= extra.relic.quality_class %>"><img class="relic-icon-small" src="<%= extra.relic.image46_path %>"> <%= extra.relic.name %></td>
</tr>
<% } %>

<% if (extra && extra.mood && $('#map_popup_mood').is(':checked')) { %>
	<tr>
		<td> Destek:</td>
		<td><%= extra.mood %></td>
	</tr>
<% } %>

<% if (owner && owner.newbie_time) { %>
	<tr id="info_newbie_protect_row">
		<td colspan="2"><%== 'Hedef çaylak koruması altında olduğundan %newbie_time% tarihinden önce saldıramazsın.', owner %></td>
	</tr>
<% } /* end newbie */ %>

<% if (extra && extra.night_bonus && extra.night_bonus.current_interval && owner != null) { %>
<tr>
	<td>Gece bonusu:</td>
	<td>
		<span>
			<%= extra.night_bonus.current_interval %>
			<% if (extra.night_bonus.switch_interval) { %>
				<br />
				<%= extra.night_bonus.switch_interval %>
			<% } %>
		</span>
	</td>
</tr>
<% } /* night bonus */ %>

<% if (extra && extra.resources && $('#map_popup_res').is(":checked")) { %>
		<tr id="info_resources_row">
		<td colspan="2">
			<table cellpadding="0" class="nowrap">
				<tr>
					<% if (extra.resources.wood) { %>
                        						<td><span class="icon header wood" title="Odun"> </span><%= extra.resources.wood %></td>
					<% } %>
					<% if (extra.resources.stone) { %>
                        						<td><span class="icon header stone" title="Kil"> </span><%= extra.resources.stone %></td>
					<% } %>
					<% if (extra.resources.iron) { %>
                        						<td><span class="icon header iron" title="Demir"> </span><%= extra.resources.iron %></td>
					<% } %>
					<% if (extra.resources.max) { %>
                        						<td><span class="icon   header ressources" title="Hammaddeler"> </span><%= extra.resources.max %></td>
					<% } %>
				</tr>
			</table>
		</td>
	</tr>
<% } %>

<%
  var showPopulation = extra && extra.population && $('#map_popup_pop').is(":checked");
  var showTrader = extra && extra.trader && $('#map_popup_trader').is(":checked");
%>

<% if (showPopulation || showTrader) { %>
	<tr>
		<% if (showPopulation && showTrader) { %>
		<td>
		<% } else { %>
		<td colspan="2">
		<% } %>

		<% if (showPopulation) { %>
			<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/face.webp" title="" alt="" class="" /> <%= extra.population.current %>/<%= extra.population.max %>
		<% } %>

		<% if (showPopulation && showTrader) { %> </td><td> <% } %>

		<% if (showTrader) { %>
			<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/overview/trader.webp" title="" alt="" class="" /> <%= extra.trader.current %>/<%= extra.trader.total %>
		<% } %>
		</td>
	</tr>
<% } %>


<%
  var bg_colors = ['F8F4E8', 'DED3B9'];
  if (units.length > 0) {
%>
	<tr>
		<td colspan="2">
						<table style="border:1px solid #DED3B9" width="100%" cellpadding="0" cellspacing="0">

								<tr class="center">
					<% for (var i = 0; i < units.length; i++) { %>
					<td style="padding:2px;background-color:#<%= bg_colors[i%2] %>">
						<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/<%= units[i].image %>" title="" alt="" class="" />
					</td>
					<% } %>
				</tr>


								<% if (units_display.count) { %>
				<tr class="center">
					<% for (var i = 0; i < units.length; i++) { %>
					<td style="padding:2px;background-color:#<%= bg_colors[i%2] %>">
						<%= units[i].count %>
					</td>
					<% } %>
				</tr>
				<% } /* end unit count */ %>


								<% if (units_display.time) { %>
				<tr class="center">
					<% for (var i = 0; i < units.length; i++) { %>
					<td style="padding:2px;background-color:#<%= bg_colors[i%2] %>">
						<%= units[i].time %>
					</td>
					<% } %>
				</tr>
				<% } /* end unit times */ %>

			</table>
		</td>
	</tr>
<%
  } /* end units */
%>

				<% if (extra && extra.buildings && $('#map_popup_buildings').is(':checked')) { %>
		<tr>
			<td colspan="2">
				<table style="border:1px solid #DED3B9" width="100%" cellpadding="0" cellspacing="0">
					<tr class="center">
						<% var i = 0; %>
						<% for (var building_id in extra.buildings) { %>
						<td style="padding:2px;background-color:#<%= bg_colors[i%2] %>">
							<img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/<%= building_id %>.png" title="" alt="" class="" />
						</td>
						<% i++; %>
						<% } %>
					</tr>
					<tr class="center">
						<% var i = 0; %>
						<% for (var building_id in extra.buildings) { %>
						<td style="padding:2px;background-color:#<%= bg_colors[i%2] %>">
							<%= extra.buildings[building_id] %>
						</td>
						<% i++; %>
						<% } %>
					</tr>
				</table>
			</td>
		</tr>
		<% } /* end buildings */ %>

<% if (extra && (extra.own_note || extra.shared_notes_hint) && $('#map_popup_notes').is(':checked')) { %>
	<tr>
		<td colspan="2">
			<hr />
				<% if (extra.own_note) { %>
				<u>Notlar:</u> <%= extra.own_note %>

				<% if (extra.shared_notes_hint) { %>
					<br/>
				<% } %>
			<% } %>

			<% if (extra.shared_notes_hint) { %>
				<img src="<%= image_base %>/map/village_notes_2.png" style="vertical-align:middle;">
				<%= extra.shared_notes_hint %>
			<% } %>
		</td>
	</tr>
<% } /* end notes */ %>


<% if (extra && extra.incoming_earliest && $('#map_popup_incoming').is(':checked')) { %>
	<tr>
		<td colspan="2"> <%= extra.incoming_html %></td>
	</tr>
<% } %>

<% if (extra === false) { %>
	<tr>
		<td colspan="2"><table><tr><td><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/throbber.gif" title="" alt="" class="" /></td><td>Bilgiler yükleniyor...</td></tr></table></td>
	</tr>
<% } %>

<% } %>

</table>
</script>

<div id="map_popup" class="nowrap" style="position:absolute; top:0px; left:0px; min-width:150px; z-index:12000; direction:ltr;">
</div>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>

## ✅ 12. GELEN SALDIRILAR (INCOMING)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=overview_villages&mode=incomings`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Gelen saldırı listesi var mı?
- [ ] Saldırı detayları görünüyor mu?

**Lütfen ver:**
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            
<!--[if IE]><style type="text/css">
table.vis.vis_menu {
    border-collapse: collapse;
    margin-top: -2px;
    margin-left: -2px;
    margin-right: -2px;

    border-left: none;
    border-right: none;
    border-top: none;

}

table.main {
    border-collapse: collapse;
}

.main td{
    overflow: hidden;
}

</style><![endif]-->

<script type="text/javascript">
//<![CDATA[
	if(window.opera) { $("#content_value").css("overflow", "hidden"); }
	// This not bold thing is some kind of hack, because a tooltip contains a title and a body.
	// If they are not splitted like the most tooltips everything is handeld as title and printed bold
	// when using the bodyHandler function the title is removed, but i just return the normal tooltip text
	// the non-bold class is just copyed from previous solutuon
	$( function() { UI.ToolTip( $( '.village_note' ), { bodyHandler: function() { return this.tooltipText; }, extraClass: "tooltip-style not-bold" } ); } );
//]]>
</script>



<input type="hidden" id="overview" value="incomings">
<table class="vis modemenu" width="100%" id="overview_menu"><tbody><tr>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=combined">Kombine </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod">Üretim </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=trader">Nakliyatlar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=units">Birlikler </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands">Komutlar </a></td>
	<td style="text-align:center" class="selected"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings">Gelen </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=buildings">Binalar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=tech">Araştırma </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=groups">Gruplar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=am">Hesap yöneticisi </a></td>
</tr></tbody></table><br>

						

			
			<div id="paged_view_content">
    	
        <div class="vis_item" align="center">Gruplar: <a class="group-menu-item" data-group-id="18171" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;subtype=all&amp;mode=incomings&amp;group=18171" data-title="">[Tam Saldırı]</a>  <a class="group-menu-item" data-group-id="18172" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;subtype=all&amp;mode=incomings&amp;group=18172" data-title="">[Gelen Saldırı]</a>  <a class="group-menu-item" data-group-id="18173" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;subtype=all&amp;mode=incomings&amp;group=18173" data-title="">[Misyoner var]</a>  <strong class="group-menu-item" data-group-id="0" data-group-type="all" data-title="">&gt;hepsi&lt; </strong> </div><script>$(function() { VillageGroupMenu.Nav.init(); });</script>

   		<table class="vis" width="100%">
			   		</table>
	
	

<script type="text/javascript">
$(function(){
	VillageGroups.initOverviews();
});
</script>


<table class="vis modemenu" style="width:100%; margin-left:auto; margin-right:auto">
<tbody><tr>
	<td style="width:33%; text-align:center" class="selected"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;type=unignored&amp;subtype=all">Hepsi</a></td>
	<td style="width:33%; text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;type=unignored&amp;subtype=attacks">Saldırılar</a></td>
	<td style="width:33%; text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;type=unignored&amp;subtype=supports">Destek</a></td>
</tr>
</tbody></table>
<br>

<div class="overview_filters" style="display: none; margin-bottom: 10px">
    <form method="POST" action="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings&amp;action=save_filters">
        <input type="hidden" name="return" value="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings">
        <table class="vis">
            <tbody><tr>
                <th colspan="2">Gelen komutları filtrele</th>
            </tr>
                                            <tr>
                    <td>Komut etiketleme:</td>
                    <td>
                        <input type="text" name="filters[target_comment]" value="">
                                            </td>
                </tr>
                                            <tr>
                    <td>Hedef köy:</td>
                    <td>
                        <input type="text" name="filters[target_name]" value="">
                                            </td>
                </tr>
                                            <tr>
                    <td>Başlangıç köyü:</td>
                    <td>
                        <input type="text" name="filters[origin_name]" value="">
                                            </td>
                </tr>
                                            <tr>
                    <td>Asıl oyuncu:</td>
                    <td>
                        <input type="text" name="filters[origin_player]" value="" class="autocomplete ui-autocomplete-input" data-type="player" autocomplete="off">
                                            </td>
                </tr>
                                                <!-- will use non-standard input for command icons -->
                                            <tr>
                <td colspan="2" class="center">
                    <input type="submit" value="Kaydet" class="btn">
                </td>
            </tr>
        </tbody></table>
    <input type="hidden" name="h" value="58fce238"></form>
</div>

<a href="#" class="overview_filters_manage">
    <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/search.webp" alt="">            Filtreleri yönet    </a>



<script type="text/javascript">
	$('document').ready(function() {
        CommandsOverview.init('overview_filter_incomings');
		UI.ToolTip('.icon_village_notes');

        $('.quickedit').QuickEdit({
            url: TribalWars.buildURL('POST', 'info_command', {ajaxaction: 'edit_other_comment', id: '__ID__'}),
            save_success_callback: () => Command.styleCommandTags(),
        });
        Command.init();
        Command.initCommandTags(["unit","player","sent","return","duration","distance","arrival","origin","destination"], '#incomings_table');
	});
    Timing.tickHandlers.timers.registerPreInit('watchtower-timer', ($event) => {$($event.target).html('Menzil içinde')}, 'Menzil içinde')
</script>

</div>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>

## ✅ 13. KOMUTLAR (COMMANDS)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=overview_villages&mode=commands`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Giden komutlar görünüyor mu?
- [ ] Komut detayları var mı?

**Lütfen ver:**
```
<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            
<!--[if IE]><style type="text/css">
table.vis.vis_menu {
    border-collapse: collapse;
    margin-top: -2px;
    margin-left: -2px;
    margin-right: -2px;

    border-left: none;
    border-right: none;
    border-top: none;

}

table.main {
    border-collapse: collapse;
}

.main td{
    overflow: hidden;
}

</style><![endif]-->

<script type="text/javascript">
//<![CDATA[
	if(window.opera) { $("#content_value").css("overflow", "hidden"); }
	// This not bold thing is some kind of hack, because a tooltip contains a title and a body.
	// If they are not splitted like the most tooltips everything is handeld as title and printed bold
	// when using the bodyHandler function the title is removed, but i just return the normal tooltip text
	// the non-bold class is just copyed from previous solutuon
	$( function() { UI.ToolTip( $( '.village_note' ), { bodyHandler: function() { return this.tooltipText; }, extraClass: "tooltip-style not-bold" } ); } );
//]]>
</script>



<input type="hidden" id="overview" value="commands">
<table class="vis modemenu" width="100%" id="overview_menu"><tbody><tr>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=combined">Kombine </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod">Üretim </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=trader">Nakliyatlar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=units">Birlikler </a></td>
	<td style="text-align:center" class="selected"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands">Komutlar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings">Gelen </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=buildings">Binalar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=tech">Araştırma </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=groups">Gruplar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=am">Hesap yöneticisi </a></td>
</tr></tbody></table><br>

						

			
			<div id="paged_view_content">
    	
        <div class="vis_item" align="center">Gruplar: <a class="group-menu-item" data-group-id="18171" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;type=all&amp;mode=commands&amp;group=18171" data-title="">[Tam Saldırı]</a>  <a class="group-menu-item" data-group-id="18172" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;type=all&amp;mode=commands&amp;group=18172" data-title="">[Gelen Saldırı]</a>  <a class="group-menu-item" data-group-id="18173" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;type=all&amp;mode=commands&amp;group=18173" data-title="">[Misyoner var]</a>  <strong class="group-menu-item" data-group-id="0" data-group-type="all" data-title="">&gt;hepsi&lt; </strong> </div><script>$(function() { VillageGroupMenu.Nav.init(); });</script>

   		<table class="vis" width="100%">
			   		</table>
	
	

<script type="text/javascript">
$(function(){
	VillageGroups.initOverviews();
});
</script>
﻿<table class="vis modemenu" style="width:100%; margin-left:auto; margin-right:auto">
	<tbody><tr>
	<td style="width:25%; text-align:center" class="selected"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands&amp;type=all">Tüm komutlar</a></td>
	<td style="width:25%; text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands&amp;type=attack">Saldırılar</a></td>
	<td style="width:25%; text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands&amp;type=support">Destekler</a></td>
	<td style="width:25%; text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands&amp;type=return">Geri dönüş</a></td>
	</tr>
</tbody></table>
<br>

<div class="overview_filters filter-box display-none">
    <form method="POST" action="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands&amp;action=save_filters">
        <input type="hidden" name="return" value="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands">
        <table class="vis">
            <tbody><tr>
                <th colspan="2">Giden komutları filtreleme</th>
            </tr>
                                            <tr>
                    <td>Komut etiketleme:</td>
                    <td>
                        <input type="text" name="filters[start_comment]" value="">
                                            </td>
                </tr>
                                            <tr>
                    <td>Başlangıç köyü:</td>
                    <td>
                        <input type="text" name="filters[origin_name]" value="">
                                            </td>
                </tr>
                                                                                                    <!-- watchtower icons -->
                <tr>
                    <td colspan="2">
                        Saldırı boyutu:                        <br>
                        <label><input type="radio" name="filter_icon_radio" value="0" checked=""> Hepsi                        </label><br>
                                                    <label>
                                <input type="radio" name="filter_icon_radio" value="8">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_small.webp" class="" data-title="">                                Küçük saldırı (1-1000 birim)                            </label><br>
                                                    <label>
                                <input type="radio" name="filter_icon_radio" value="16">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_medium.webp" class="" data-title="">                                Orta saldırı (1000-5000 birim)                            </label><br>
                                                    <label>
                                <input type="radio" name="filter_icon_radio" value="32">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/attack_large.webp" class="" data-title="">                                Büyük saldırı (5000+ birim)                             </label><br>
                                                    <label>
                                <input type="radio" name="filter_icon_radio" value="1">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/farm.webp" class="" data-title="">                                Yağma saldırısı                            </label><br>
                                                <div class="operator-block">
                            <input type="radio" value="AND" name="expression" id="and" class="operator" checked="checked">
                            <label for="and">AND</label>
                            <input type="radio" value="OR" name="expression" id="or" class="operator">
                            <label for="or">OR</label>
                        </div>

                                                    <label>
                                <input type="checkbox" name="filter_icon[2]" value="2">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/snob.webp" class="" data-title="">                                Misyoner İçeriyor                            </label><br>
                                                    <label>
                                <input type="checkbox" name="filter_icon[64]" value="64">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/spy.webp" class="" data-title="">                                Casus İçeriyor                            </label><br>
                                                    <label>
                                <input type="checkbox" name="filter_icon[4]" value="4">
                                <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/command/knight.webp" class="" data-title="">                                Şövalye İçeriyor                            </label><br>
                                            </td>
                </tr>
            <tr>
                <td colspan="2" class="center">
                    <input type="submit" value="Kaydet" class="btn">
                </td>
            </tr>
        </tbody></table>
    <input type="hidden" name="h" value="58fce238"></form>
</div>
<a href="#" class="overview_filters_manage">
    <img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/search.webp" alt="">    Filtreleri yönet</a>
<script>
    $(document).ready(() => CommandsOverview.init('overview_filter_outgoing'))
</script><script type="text/javascript">
$(function(){
    JToggler.init('#commands_table input[type="checkbox"]');
});
</script>

<script>
    $(function() {
        $('.quickedit').QuickEdit({url: TribalWars.buildURL('POST', 'info_command', {ajaxaction: 'edit_own_comment', id: '__ID__'})});
    });
</script></div>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>

---

## ✅ 14. KÖY LİSTESİ (OVERVIEW_VILLAGES)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=overview_villages&mode=prod`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Tüm köyler listeleniyor mu?
- [ ] Köy detayları görünüyor mu?

**Lütfen ver:**
```
<table align="center" id="contentContainer" width="100%">
	        <tbody><tr>
	            <td>
					<table class="content-border" width="100%" cellspacing="0">
	                    <tbody><tr>
	                        <td id="inner-border">
								<table class="main" align="left">
	                                <tbody><tr>
										<td id="content_value">
                                            
                                            
<!--[if IE]><style type="text/css">
table.vis.vis_menu {
    border-collapse: collapse;
    margin-top: -2px;
    margin-left: -2px;
    margin-right: -2px;

    border-left: none;
    border-right: none;
    border-top: none;

}

table.main {
    border-collapse: collapse;
}

.main td{
    overflow: hidden;
}

</style><![endif]-->

<script type="text/javascript">
//<![CDATA[
	if(window.opera) { $("#content_value").css("overflow", "hidden"); }
	// This not bold thing is some kind of hack, because a tooltip contains a title and a body.
	// If they are not splitted like the most tooltips everything is handeld as title and printed bold
	// when using the bodyHandler function the title is removed, but i just return the normal tooltip text
	// the non-bold class is just copyed from previous solutuon
	$( function() { UI.ToolTip( $( '.village_note' ), { bodyHandler: function() { return this.tooltipText; }, extraClass: "tooltip-style not-bold" } ); } );
//]]>
</script>



<input type="hidden" id="overview" value="prod">
<table class="vis modemenu" width="100%" id="overview_menu"><tbody><tr>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=combined">Kombine </a></td>
	<td style="text-align:center" class="selected"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod">Üretim </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=trader">Nakliyatlar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=units">Birlikler </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=commands">Komutlar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=incomings">Gelen </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=buildings">Binalar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=tech">Araştırma </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=groups">Gruplar </a></td>
	<td style="text-align:center"><a href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=am">Hesap yöneticisi </a></td>
</tr></tbody></table><br>

						

			
			<div id="paged_view_content">
    	
        <div class="vis_item" align="center">Gruplar: <a class="group-menu-item" data-group-id="18171" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod&amp;group=18171" data-title="">[Tam Saldırı]</a>  <a class="group-menu-item" data-group-id="18172" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod&amp;group=18172" data-title="">[Gelen Saldırı]</a>  <a class="group-menu-item" data-group-id="18173" data-group-type="dynamic" href="/game.php?village=12218&amp;screen=overview_villages&amp;mode=prod&amp;group=18173" data-title="">[Misyoner var]</a>  <strong class="group-menu-item" data-group-id="0" data-group-type="all" data-title="">&gt;hepsi&lt; </strong> </div><script>$(function() { VillageGroupMenu.Nav.init(); });</script>

   		<table class="vis" width="100%">
			   		</table>
	
	

<script type="text/javascript">
$(function(){
	VillageGroups.initOverviews();
});
</script>


<table id="production_table" class="vis overview_table" width="100%">

<thead>
    <tr>
            <th><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/overview/note.webp" alt=""></th>
        <th><a href="/game.php?village=12218&amp;screen=overview_villages&amp;
				page=-1
				&amp;order=name
				&amp;dir=desc&amp;mode=prod&amp;group=0">Köy</a> (1)</th>
    <th><a href="/game.php?village=12218&amp;screen=overview_villages&amp;
				page=-1
				&amp;order=points
				&amp;dir=desc&amp;mode=prod&amp;group=0">Puan</a></th>
    <th>Hammaddeler</th>
    <th><a href="/game.php?village=12218&amp;screen=overview_villages&amp;
				page=-1
				&amp;order=storage_max
				&amp;dir=desc&amp;mode=prod&amp;group=0">Depo</a></th>
            <th><a href="/game.php?village=12218&amp;screen=overview_villages&amp;
				page=-1
				&amp;order=trader_available
				&amp;dir=desc&amp;mode=prod&amp;group=0">Tüccar</a></th>    <th><a href="/game.php?village=12218&amp;screen=overview_villages&amp;
				page=-1
				&amp;order=pop
				&amp;dir=desc&amp;mode=prod&amp;group=0">Çiftlik</a></th>
            <th>İnşaat</th>
        <th>Araştırma</th>
        <th>Asker toplama</th>
        </tr>
</thead>

	<tbody><tr class="nowrap  selected row_a">
						<td></td>
		  	<td>
        <span class="quickedit-vn" data-id="12218" data-length="32">
    <span class="quickedit-content">
        <a href="/game.php?village=12218&amp;screen=overview">
                        <span class="quickedit-label" data-text="Köy 1">
                 Köy 1 (471|614) K64            </span>
                        <img class="relic-icon-small-village-list" src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/relic_system/relics_46/greataxe_shoddy.webp" data-title="&lt;h3&gt;&lt;img class=&quot;relic-icon-small&quot; src=&quot;https://dstr.innogamescdn.com/asset/c645ceed/graphic/relic_system/relics_46/greataxe_shoddy.webp&quot;&gt; Kalitesiz Çift El Balta&lt;/h3&gt; :: &lt;ul&gt;&lt;li&gt;Baltacı: +2% saldırı ve savunma gücü&lt;/li&gt;&lt;li&gt;Mızrakçı: +1% saldırı ve savunma gücü&lt;/li&gt;&lt;li&gt;Ağır atlı: +1% saldırı ve savunma gücü&lt;/li&gt;&lt;/ul&gt;&lt;p&gt;&lt;/p&gt;">
                    </a>
        <a class="rename-icon" href="#" data-title="Adını değiştir"></a>
    </span>
</span>
	</td>
	<td>411</td>
	<td><span class="res wood">353</span> <span class="res stone">3<span class="grey">.</span>863</span> <span class="res iron">1<span class="grey">.</span>475</span> </td>
	<td>6420</td>
            <td><a href="/game.php?village=12218&amp;screen=market">5/5</a></td>        <td class="">624/854</td>
                <td>
                            bugün saat 20:53                <br>
                <ul style="width: 10em;" id="building_order_12218" class="order_queue">			<li id="order_0" class="order ">
				<div class="order-status-light" style="background-color: green;"></div>
				
				<div class="queue_icon"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/buildings/wall.webp" class="" data-title="Sur - bugün saat 20:53"></div>
			</li></ul>
                    </td>
        <td></td>
        <td>
                            <ul style="width: 10em;" id="unit_order_12218" class="order_queue">			<li id="order_0" class="order">
				<div class="order-status-light" style="background-color: green;"></div>
				<div class="queue_icon"><img src="https://dstr.innogamescdn.com/asset/c645ceed/graphic/unit/unit_sword.webp" class="" data-title="6 - Kılıç ustası - bugün saat 21:40"></div>
			</li></ul>
                    </td>
            	</tr>
</tbody></table>

<script>
$(function(){
    $('.quickedit-vn').QuickEdit({
        url: TribalWars.buildURL('POST', 'main', { ajaxaction: 'change_name', village: '__ID__' })
    });
});
</script></div>

	                               		</td>
									</tr>
								</tbody></table>
							</td>
						</tr>
					</tbody></table>
				</td>
			</tr>
		</tbody></table>
```

---

## ✅ 15. AYARLAR (SETTINGS)
**Beklenen URL:** `https://tr99.klanlar.org/game.php?village=12218&screen=settings`

### Kontrol Edilecekler:
- [ ] Sayfa açılıyor mu?
- [ ] Oyuncu bilgileri görünüyor mu?

**Lütfen ver:**
```
<div class="content-display bordered-box pull-left"> <h3>99. Dünya Ayarları</h3> <div class="bordered-box-content"> <table class="data-table"> <tbody><tr> <td>Oyun hızı</td> <td>1</td> </tr> <tr> <td>Birim hızı</td> <td>1</td> </tr> <tr> <td>Hammadde üretim faktörü</td> <td>1</td> </tr> <tr> <td>Barbar köy çıkışı</td> <td>Bir oyuncu dünyaya katıldığında 100% şans</td> </tr> <tr> <td>Bonus köy çıkışı</td> <td>Bir oyuncu dünyaya katıldığında 0% şans</td> </tr> <tr> <td>Binayı yık</td> <td>Etkin</td> </tr> <tr> <td>Moral</td> <td> Puan bazlı </td> </tr> <tr> <td>Milisaniye</td> <td>Etkin</td> </tr> <tr> <td>Aldatma sınırlandırması</td> <td> Köy puanlarının 1%'i </td> </tr> <tr> <td>Araştırma Sistemi</td> <td> Basitleştirilmiş araştırma </td> </tr> <tr> <td>Tapınak</td> <td>Etkin</td> </tr> <tr> <td>Gözetleme Kulesi</td> <td>İnaktif</td> </tr> <tr> <td>Görev Sistemi</td> <td>Etkin</td> </tr> <tr> <td>Başarılar</td> <td>Etkin</td> </tr> <tr> <td>Kendi kendini geliştiren barbar köyleri</td> <td> Etkin 1500 puana kadar </td> </tr> <tr> <td>Bonus köyleri</td> <td> Bonus köyü yok </td> </tr> <tr> <td>İptal edilen saldırılar için zaman çizelgesi</td> <td>10 dakika</td> </tr> <tr> <td>İptal edilen transferler için zaman çizelgesi</td> <td>5 dakika</td> </tr> <tr> <td>Gece bonusu</td> <td> 23:00 - 7:00 arasında aktif, saldırılara karşı +100% savunma. </td> </tr> <tr> <td>Yeni başlayanlar için saldırı koruması</td> <td> 5 gün </td> </tr> <tr> <td> Maks. saldırı oranı: (saldırgan:savunmacı) </td> <td> İlk 30 gün için 20 : 1 </td> </tr> <tr> <td>Bayraklar</td> <td>Etkin</td> </tr> <tr> <td>Temizlik</td> <td>Etkin</td> </tr> <tr> <td>Yağma</td> <td>Etkin</td> </tr> <tr> <td> Kale </td><td>İnaktif </td> </tr> <tr> <td> Kalıntılar </td><td>Etkin</td> </tr> </tbody></table> <hr> <h4>Birimler</h4> <table class="data-table"> <tbody><tr> <td>Okçular</td> <td>İnaktif</td> </tr> <tr> <td>Casus sistemi</td> <td> Casus; birlikleri, binaları, hammaddeleri ve yabancı birlikleri gözleyebilir. </td> </tr> <tr> <td>Şövalye</td> <td> Etkin, eşyalar yok. </td> </tr> <tr> <td>Milis</td> <td>Etkin</td> </tr> </tbody></table> <hr> <h4>Misyoner</h4> <table class="data-table"> <tbody><tr> <td>Satın alma yöntemi</td> <td> Altın para </td> </tr> <tr> <td>Azami misyoner menzili</td> <td>70 alan</td> </tr> <tr> <td>Misyoner saldırısı başına sadakat kaybı</td> <td>20-35</td> </tr> <tr> <td>Saat başına destek artışı</td> <td>1</td> </tr> </tbody></table> <hr> <h4>Yapılandırma</h4> <table class="data-table"> <tbody><tr> <td>Klan başına üye limiti</td> <td>40</td> </tr> <tr> <td>Klan üyelerine saldırabilme</td> <td> Klan üyelerine karşı saldırılar ziyarete dönüşür ve bu nedenle herhangi bir zarar vermez </td> </tr> <tr> <td>Klan seviyesi</td> <td>Etkin</td> </tr> <tr> <td>Hesap bakıcılığı</td> <td>Etkin</td> </tr> <tr> <td>Hesap bakıcılığı kısıtlamaları</td> <td> Son 30 gün içerisinde 15 günden fazla hesap bakıcılığı yapıldığı için bakıcılık engellendi. </td> </tr> <tr> <td>Serbest ticaret</td> <td> Etkinken her bir oyuncu başlangıcı bazında süre kısıtlaması </td> </tr> <tr> <td>Klan dışına destek</td> <td> Oyuncunun klan dışındaki köyleri desteklemesi mümkün değildir. Klan üyeliği varışta kontrol edilir. Klan değişikliğinde destek geri çekilir. </td> </tr> <tr><td>Komut varış zaman dalgalanması</td> <td>Komutların ulaşması için geçen süre -25 ile +25 milisaniye arasında değişir.</td> </tr><tr> <td>Başlangıç için yön seçebilme</td> <td>Aktif, arkadaş yanına taşın etkin</td> </tr> <tr> <td>Kazanma koşulları</td> <td> 180 gün sonra, bir klan oyuncu köylerinin 75% oranını 7 gün boyunca elinde tutmalıdır. </td> </tr> <tr> <td>Başlama tarihi</td> <td>Oca 08,2026 12:30</td> </tr> </tbody></table> </div> </div>
```

---

## 📋 NASIL VERİ TOPLANIR?

### 1. Tarayıcıda Sayfayı Aç
```
https://tr99.klanlar.org/game.php?village=12218&screen=SAYFA_ADI
```

### 2. HTML Kodunu Al
- Sayfada sağ tık → "İncele" (Inspect)
- İlgili elementi bul
- Sağ tık → "Copy" → "Copy outerHTML"

### 3. JavaScript Objelerini Al
- F12 → Console sekmesi
- `game_data.village` yaz ve Enter
- Çıktıyı kopyala

### 4. Attribute Değerlerini Al
- Element'i seç
- Attributes sekmesinde `data-*` değerlerini kontrol et

---

## 📝 ÖRNEK VERİ FORMATI

```
SAYFA: İçtima Meydanı (Place)
URL: https://tr99.klanlar.org/game.php?village=12218&screen=place

HTML:
<input id="unit_input_spear" name="spear" type="text" value="" 
       class="unitsInput" data-all-count="230">

SELECTOR: input[name='spear'][data-all-count]
DEĞER: 230
```

---

**Hazır olduğunda bana şu formatta ver:**

```
SAYFA: [Sayfa Adı]
URL: [Tam URL]
HTML: [HTML Kodu]
NOTLAR: [Varsa özel durumlar]
```

Her sayfa için ayrı ayrı gönderebilirsin veya hepsini toplu olarak gönderebilirsin.
