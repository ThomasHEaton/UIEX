#pragma warning disable 0649 // UXMLReference variable declared but not assigned to.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
using UnityEditor.UIElements;
#else
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;
#endif

namespace RedOwl.Editor
{
	[UXML]
	public class FontAwesome : Label
	{		
		public new class UxmlFactory : UxmlFactory<FontAwesome, UxmlTraits> {}
		
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
            UxmlStringAttributeDescription _type = new UxmlStringAttributeDescription { name = "type" };
			UxmlStringAttributeDescription _icon = new UxmlStringAttributeDescription { name = "icon" };

			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get { yield break; }
			}

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				var target = (FontAwesome)ve;
				base.Init(ve, bag, cc);
                target.type = _type.GetValueFromBag(bag, cc);
				target.icon = _icon.GetValueFromBag(bag, cc);
			}
		}

        string _type;
		public string type {
            get { return _type;}
            set {
                _type = value;
                UpdateIcon();
            }
        }

        string _icon;
		public string icon {
            get { return _icon;}
            set {
                _icon = value;
                UpdateIcon();
            }
        }
		
		public FontAwesome() : base() {}
        public FontAwesome(string icon)
        {
            _type = "solid";
            _icon = icon;
        }

        public FontAwesome(string type, string icon)
        {
            _type = type;
            _icon = icon;
        }

        [UICallback(1, true)]
        private void UpdateIcon()
        {
            AddToClassList("fa");
            RemoveFromClassList("fa-regular");
            RemoveFromClassList("fa-solid");
            RemoveFromClassList("fa-brands");
            switch (_type)
            {
                case "regular":
                    AddToClassList("fa-regular");
                    break;
                default:
                case "solid":
                    AddToClassList("fa-solid");
                    break;
                case "brands":
                    AddToClassList("fa-brands");
                    break;
            }
            char content = '\0';
            switch(icon)
            {
            case "fa-500px":
                content = '\uf26e';
                break;
            case "fa-accessible-icon":
                content = '\uf368';
                break;
            case "fa-accusoft":
                content = '\uf369';
                break;
            case "fa-acquisitions-incorporated":
                content = '\uf6af';
                break;
            case "fa-ad":
                content = '\uf641';
                break;
            case "fa-address-book":
                content = '\uf2b9';
                break;
            case "fa-address-card":
                content = '\uf2bb';
                break;
            case "fa-adjust":
                content = '\uf042';
                break;
            case "fa-adn":
                content = '\uf170';
                break;
            case "fa-adobe":
                content = '\uf778';
                break;
            case "fa-adversal":
                content = '\uf36a';
                break;
            case "fa-affiliatetheme":
                content = '\uf36b';
                break;
            case "fa-air-freshener":
                content = '\uf5d0';
                break;
            case "fa-algolia":
                content = '\uf36c';
                break;
            case "fa-align-center":
                content = '\uf037';
                break;
            case "fa-align-justify":
                content = '\uf039';
                break;
            case "fa-align-left":
                content = '\uf036';
                break;
            case "fa-align-right":
                content = '\uf038';
                break;
            case "fa-alipay":
                content = '\uf642';
                break;
            case "fa-allergies":
                content = '\uf461';
                break;
            case "fa-amazon":
                content = '\uf270';
                break;
            case "fa-amazon-pay":
                content = '\uf42c';
                break;
            case "fa-ambulance":
                content = '\uf0f9';
                break;
            case "fa-american-sign-language-interpreting":
                content = '\uf2a3';
                break;
            case "fa-amilia":
                content = '\uf36d';
                break;
            case "fa-anchor":
                content = '\uf13d';
                break;
            case "fa-android":
                content = '\uf17b';
                break;
            case "fa-angellist":
                content = '\uf209';
                break;
            case "fa-angle-double-down":
                content = '\uf103';
                break;
            case "fa-angle-double-left":
                content = '\uf100';
                break;
            case "fa-angle-double-right":
                content = '\uf101';
                break;
            case "fa-angle-double-up":
                content = '\uf102';
                break;
            case "fa-angle-down":
                content = '\uf107';
                break;
            case "fa-angle-left":
                content = '\uf104';
                break;
            case "fa-angle-right":
                content = '\uf105';
                break;
            case "fa-angle-up":
                content = '\uf106';
                break;
            case "fa-angry":
                content = '\uf556';
                break;
            case "fa-angrycreative":
                content = '\uf36e';
                break;
            case "fa-angular":
                content = '\uf420';
                break;
            case "fa-ankh":
                content = '\uf644';
                break;
            case "fa-app-store":
                content = '\uf36f';
                break;
            case "fa-app-store-ios":
                content = '\uf370';
                break;
            case "fa-apper":
                content = '\uf371';
                break;
            case "fa-apple":
                content = '\uf179';
                break;
            case "fa-apple-alt":
                content = '\uf5d1';
                break;
            case "fa-apple-pay":
                content = '\uf415';
                break;
            case "fa-archive":
                content = '\uf187';
                break;
            case "fa-archway":
                content = '\uf557';
                break;
            case "fa-arrow-alt-circle-down":
                content = '\uf358';
                break;
            case "fa-arrow-alt-circle-left":
                content = '\uf359';
                break;
            case "fa-arrow-alt-circle-right":
                content = '\uf35a';
                break;
            case "fa-arrow-alt-circle-up":
                content = '\uf35b';
                break;
            case "fa-arrow-circle-down":
                content = '\uf0ab';
                break;
            case "fa-arrow-circle-left":
                content = '\uf0a8';
                break;
            case "fa-arrow-circle-right":
                content = '\uf0a9';
                break;
            case "fa-arrow-circle-up":
                content = '\uf0aa';
                break;
            case "fa-arrow-down":
                content = '\uf063';
                break;
            case "fa-arrow-left":
                content = '\uf060';
                break;
            case "fa-arrow-right":
                content = '\uf061';
                break;
            case "fa-arrow-up":
                content = '\uf062';
                break;
            case "fa-arrows-alt":
                content = '\uf0b2';
                break;
            case "fa-arrows-alt-h":
                content = '\uf337';
                break;
            case "fa-arrows-alt-v":
                content = '\uf338';
                break;
            case "fa-artstation":
                content = '\uf77a';
                break;
            case "fa-assistive-listening-systems":
                content = '\uf2a2';
                break;
            case "fa-asterisk":
                content = '\uf069';
                break;
            case "fa-asymmetrik":
                content = '\uf372';
                break;
            case "fa-at":
                content = '\uf1fa';
                break;
            case "fa-atlas":
                content = '\uf558';
                break;
            case "fa-atlassian":
                content = '\uf77b';
                break;
            case "fa-atom":
                content = '\uf5d2';
                break;
            case "fa-audible":
                content = '\uf373';
                break;
            case "fa-audio-description":
                content = '\uf29e';
                break;
            case "fa-autoprefixer":
                content = '\uf41c';
                break;
            case "fa-avianex":
                content = '\uf374';
                break;
            case "fa-aviato":
                content = '\uf421';
                break;
            case "fa-award":
                content = '\uf559';
                break;
            case "fa-aws":
                content = '\uf375';
                break;
            case "fa-baby":
                content = '\uf77c';
                break;
            case "fa-baby-carriage":
                content = '\uf77d';
                break;
            case "fa-backspace":
                content = '\uf55a';
                break;
            case "fa-backward":
                content = '\uf04a';
                break;
            case "fa-bacon":
                content = '\uf7e5';
                break;
            case "fa-balance-scale":
                content = '\uf24e';
                break;
            case "fa-ban":
                content = '\uf05e';
                break;
            case "fa-band-aid":
                content = '\uf462';
                break;
            case "fa-bandcamp":
                content = '\uf2d5';
                break;
            case "fa-barcode":
                content = '\uf02a';
                break;
            case "fa-bars":
                content = '\uf0c9';
                break;
            case "fa-baseball-ball":
                content = '\uf433';
                break;
            case "fa-basketball-ball":
                content = '\uf434';
                break;
            case "fa-bath":
                content = '\uf2cd';
                break;
            case "fa-battery-empty":
                content = '\uf244';
                break;
            case "fa-battery-full":
                content = '\uf240';
                break;
            case "fa-battery-half":
                content = '\uf242';
                break;
            case "fa-battery-quarter":
                content = '\uf243';
                break;
            case "fa-battery-three-quarters":
                content = '\uf241';
                break;
            case "fa-bed":
                content = '\uf236';
                break;
            case "fa-beer":
                content = '\uf0fc';
                break;
            case "fa-behance":
                content = '\uf1b4';
                break;
            case "fa-behance-square":
                content = '\uf1b5';
                break;
            case "fa-bell":
                content = '\uf0f3';
                break;
            case "fa-bell-slash":
                content = '\uf1f6';
                break;
            case "fa-bezier-curve":
                content = '\uf55b';
                break;
            case "fa-bible":
                content = '\uf647';
                break;
            case "fa-bicycle":
                content = '\uf206';
                break;
            case "fa-bimobject":
                content = '\uf378';
                break;
            case "fa-binoculars":
                content = '\uf1e5';
                break;
            case "fa-biohazard":
                content = '\uf780';
                break;
            case "fa-birthday-cake":
                content = '\uf1fd';
                break;
            case "fa-bitbucket":
                content = '\uf171';
                break;
            case "fa-bitcoin":
                content = '\uf379';
                break;
            case "fa-bity":
                content = '\uf37a';
                break;
            case "fa-black-tie":
                content = '\uf27e';
                break;
            case "fa-blackberry":
                content = '\uf37b';
                break;
            case "fa-blender":
                content = '\uf517';
                break;
            case "fa-blender-phone":
                content = '\uf6b6';
                break;
            case "fa-blind":
                content = '\uf29d';
                break;
            case "fa-blog":
                content = '\uf781';
                break;
            case "fa-blogger":
                content = '\uf37c';
                break;
            case "fa-blogger-b":
                content = '\uf37d';
                break;
            case "fa-bluetooth":
                content = '\uf293';
                break;
            case "fa-bluetooth-b":
                content = '\uf294';
                break;
            case "fa-bold":
                content = '\uf032';
                break;
            case "fa-bolt":
                content = '\uf0e7';
                break;
            case "fa-bomb":
                content = '\uf1e2';
                break;
            case "fa-bone":
                content = '\uf5d7';
                break;
            case "fa-bong":
                content = '\uf55c';
                break;
            case "fa-book":
                content = '\uf02d';
                break;
            case "fa-book-dead":
                content = '\uf6b7';
                break;
            case "fa-book-medical":
                content = '\uf7e6';
                break;
            case "fa-book-open":
                content = '\uf518';
                break;
            case "fa-book-reader":
                content = '\uf5da';
                break;
            case "fa-bookmark":
                content = '\uf02e';
                break;
            case "fa-bowling-ball":
                content = '\uf436';
                break;
            case "fa-box":
                content = '\uf466';
                break;
            case "fa-box-open":
                content = '\uf49e';
                break;
            case "fa-boxes":
                content = '\uf468';
                break;
            case "fa-braille":
                content = '\uf2a1';
                break;
            case "fa-brain":
                content = '\uf5dc';
                break;
            case "fa-bread-slice":
                content = '\uf7ec';
                break;
            case "fa-briefcase":
                content = '\uf0b1';
                break;
            case "fa-briefcase-medical":
                content = '\uf469';
                break;
            case "fa-broadcast-tower":
                content = '\uf519';
                break;
            case "fa-broom":
                content = '\uf51a';
                break;
            case "fa-brush":
                content = '\uf55d';
                break;
            case "fa-btc":
                content = '\uf15a';
                break;
            case "fa-bug":
                content = '\uf188';
                break;
            case "fa-building":
                content = '\uf1ad';
                break;
            case "fa-bullhorn":
                content = '\uf0a1';
                break;
            case "fa-bullseye":
                content = '\uf140';
                break;
            case "fa-burn":
                content = '\uf46a';
                break;
            case "fa-buromobelexperte":
                content = '\uf37f';
                break;
            case "fa-bus":
                content = '\uf207';
                break;
            case "fa-bus-alt":
                content = '\uf55e';
                break;
            case "fa-business-time":
                content = '\uf64a';
                break;
            case "fa-buysellads":
                content = '\uf20d';
                break;
            case "fa-calculator":
                content = '\uf1ec';
                break;
            case "fa-calendar":
                content = '\uf133';
                break;
            case "fa-calendar-alt":
                content = '\uf073';
                break;
            case "fa-calendar-check":
                content = '\uf274';
                break;
            case "fa-calendar-day":
                content = '\uf783';
                break;
            case "fa-calendar-minus":
                content = '\uf272';
                break;
            case "fa-calendar-plus":
                content = '\uf271';
                break;
            case "fa-calendar-times":
                content = '\uf273';
                break;
            case "fa-calendar-week":
                content = '\uf784';
                break;
            case "fa-camera":
                content = '\uf030';
                break;
            case "fa-camera-retro":
                content = '\uf083';
                break;
            case "fa-campground":
                content = '\uf6bb';
                break;
            case "fa-canadian-maple-leaf":
                content = '\uf785';
                break;
            case "fa-candy-cane":
                content = '\uf786';
                break;
            case "fa-cannabis":
                content = '\uf55f';
                break;
            case "fa-capsules":
                content = '\uf46b';
                break;
            case "fa-car":
                content = '\uf1b9';
                break;
            case "fa-car-alt":
                content = '\uf5de';
                break;
            case "fa-car-battery":
                content = '\uf5df';
                break;
            case "fa-car-crash":
                content = '\uf5e1';
                break;
            case "fa-car-side":
                content = '\uf5e4';
                break;
            case "fa-caret-down":
                content = '\uf0d7';
                break;
            case "fa-caret-left":
                content = '\uf0d9';
                break;
            case "fa-caret-right":
                content = '\uf0da';
                break;
            case "fa-caret-square-down":
                content = '\uf150';
                break;
            case "fa-caret-square-left":
                content = '\uf191';
                break;
            case "fa-caret-square-right":
                content = '\uf152';
                break;
            case "fa-caret-square-up":
                content = '\uf151';
                break;
            case "fa-caret-up":
                content = '\uf0d8';
                break;
            case "fa-carrot":
                content = '\uf787';
                break;
            case "fa-cart-arrow-down":
                content = '\uf218';
                break;
            case "fa-cart-plus":
                content = '\uf217';
                break;
            case "fa-cash-register":
                content = '\uf788';
                break;
            case "fa-cat":
                content = '\uf6be';
                break;
            case "fa-cc-amazon-pay":
                content = '\uf42d';
                break;
            case "fa-cc-amex":
                content = '\uf1f3';
                break;
            case "fa-cc-apple-pay":
                content = '\uf416';
                break;
            case "fa-cc-diners-club":
                content = '\uf24c';
                break;
            case "fa-cc-discover":
                content = '\uf1f2';
                break;
            case "fa-cc-jcb":
                content = '\uf24b';
                break;
            case "fa-cc-mastercard":
                content = '\uf1f1';
                break;
            case "fa-cc-paypal":
                content = '\uf1f4';
                break;
            case "fa-cc-stripe":
                content = '\uf1f5';
                break;
            case "fa-cc-visa":
                content = '\uf1f0';
                break;
            case "fa-centercode":
                content = '\uf380';
                break;
            case "fa-centos":
                content = '\uf789';
                break;
            case "fa-certificate":
                content = '\uf0a3';
                break;
            case "fa-chair":
                content = '\uf6c0';
                break;
            case "fa-chalkboard":
                content = '\uf51b';
                break;
            case "fa-chalkboard-teacher":
                content = '\uf51c';
                break;
            case "fa-charging-station":
                content = '\uf5e7';
                break;
            case "fa-chart-area":
                content = '\uf1fe';
                break;
            case "fa-chart-bar":
                content = '\uf080';
                break;
            case "fa-chart-line":
                content = '\uf201';
                break;
            case "fa-chart-pie":
                content = '\uf200';
                break;
            case "fa-check":
                content = '\uf00c';
                break;
            case "fa-check-circle":
                content = '\uf058';
                break;
            case "fa-check-double":
                content = '\uf560';
                break;
            case "fa-check-square":
                content = '\uf14a';
                break;
            case "fa-cheese":
                content = '\uf7ef';
                break;
            case "fa-chess":
                content = '\uf439';
                break;
            case "fa-chess-bishop":
                content = '\uf43a';
                break;
            case "fa-chess-board":
                content = '\uf43c';
                break;
            case "fa-chess-king":
                content = '\uf43f';
                break;
            case "fa-chess-knight":
                content = '\uf441';
                break;
            case "fa-chess-pawn":
                content = '\uf443';
                break;
            case "fa-chess-queen":
                content = '\uf445';
                break;
            case "fa-chess-rook":
                content = '\uf447';
                break;
            case "fa-chevron-circle-down":
                content = '\uf13a';
                break;
            case "fa-chevron-circle-left":
                content = '\uf137';
                break;
            case "fa-chevron-circle-right":
                content = '\uf138';
                break;
            case "fa-chevron-circle-up":
                content = '\uf139';
                break;
            case "fa-chevron-down":
                content = '\uf078';
                break;
            case "fa-chevron-left":
                content = '\uf053';
                break;
            case "fa-chevron-right":
                content = '\uf054';
                break;
            case "fa-chevron-up":
                content = '\uf077';
                break;
            case "fa-child":
                content = '\uf1ae';
                break;
            case "fa-chrome":
                content = '\uf268';
                break;
            case "fa-church":
                content = '\uf51d';
                break;
            case "fa-circle":
                content = '\uf111';
                break;
            case "fa-circle-notch":
                content = '\uf1ce';
                break;
            case "fa-city":
                content = '\uf64f';
                break;
            case "fa-clinic-medical":
                content = '\uf7f2';
                break;
            case "fa-clipboard":
                content = '\uf328';
                break;
            case "fa-clipboard-check":
                content = '\uf46c';
                break;
            case "fa-clipboard-list":
                content = '\uf46d';
                break;
            case "fa-clock":
                content = '\uf017';
                break;
            case "fa-clone":
                content = '\uf24d';
                break;
            case "fa-closed-captioning":
                content = '\uf20a';
                break;
            case "fa-cloud":
                content = '\uf0c2';
                break;
            case "fa-cloud-download-alt":
                content = '\uf381';
                break;
            case "fa-cloud-meatball":
                content = '\uf73b';
                break;
            case "fa-cloud-moon":
                content = '\uf6c3';
                break;
            case "fa-cloud-moon-rain":
                content = '\uf73c';
                break;
            case "fa-cloud-rain":
                content = '\uf73d';
                break;
            case "fa-cloud-showers-heavy":
                content = '\uf740';
                break;
            case "fa-cloud-sun":
                content = '\uf6c4';
                break;
            case "fa-cloud-sun-rain":
                content = '\uf743';
                break;
            case "fa-cloud-upload-alt":
                content = '\uf382';
                break;
            case "fa-cloudscale":
                content = '\uf383';
                break;
            case "fa-cloudsmith":
                content = '\uf384';
                break;
            case "fa-cloudversify":
                content = '\uf385';
                break;
            case "fa-cocktail":
                content = '\uf561';
                break;
            case "fa-code":
                content = '\uf121';
                break;
            case "fa-code-branch":
                content = '\uf126';
                break;
            case "fa-codepen":
                content = '\uf1cb';
                break;
            case "fa-codiepie":
                content = '\uf284';
                break;
            case "fa-coffee":
                content = '\uf0f4';
                break;
            case "fa-cog":
                content = '\uf013';
                break;
            case "fa-cogs":
                content = '\uf085';
                break;
            case "fa-coins":
                content = '\uf51e';
                break;
            case "fa-columns":
                content = '\uf0db';
                break;
            case "fa-comment":
                content = '\uf075';
                break;
            case "fa-comment-alt":
                content = '\uf27a';
                break;
            case "fa-comment-dollar":
                content = '\uf651';
                break;
            case "fa-comment-dots":
                content = '\uf4ad';
                break;
            case "fa-comment-medical":
                content = '\uf7f5';
                break;
            case "fa-comment-slash":
                content = '\uf4b3';
                break;
            case "fa-comments":
                content = '\uf086';
                break;
            case "fa-comments-dollar":
                content = '\uf653';
                break;
            case "fa-compact-disc":
                content = '\uf51f';
                break;
            case "fa-compass":
                content = '\uf14e';
                break;
            case "fa-compress":
                content = '\uf066';
                break;
            case "fa-compress-arrows-alt":
                content = '\uf78c';
                break;
            case "fa-concierge-bell":
                content = '\uf562';
                break;
            case "fa-confluence":
                content = '\uf78d';
                break;
            case "fa-connectdevelop":
                content = '\uf20e';
                break;
            case "fa-contao":
                content = '\uf26d';
                break;
            case "fa-cookie":
                content = '\uf563';
                break;
            case "fa-cookie-bite":
                content = '\uf564';
                break;
            case "fa-copy":
                content = '\uf0c5';
                break;
            case "fa-copyright":
                content = '\uf1f9';
                break;
            case "fa-couch":
                content = '\uf4b8';
                break;
            case "fa-cpanel":
                content = '\uf388';
                break;
            case "fa-creative-commons":
                content = '\uf25e';
                break;
            case "fa-creative-commons-by":
                content = '\uf4e7';
                break;
            case "fa-creative-commons-nc":
                content = '\uf4e8';
                break;
            case "fa-creative-commons-nc-eu":
                content = '\uf4e9';
                break;
            case "fa-creative-commons-nc-jp":
                content = '\uf4ea';
                break;
            case "fa-creative-commons-nd":
                content = '\uf4eb';
                break;
            case "fa-creative-commons-pd":
                content = '\uf4ec';
                break;
            case "fa-creative-commons-pd-alt":
                content = '\uf4ed';
                break;
            case "fa-creative-commons-remix":
                content = '\uf4ee';
                break;
            case "fa-creative-commons-sa":
                content = '\uf4ef';
                break;
            case "fa-creative-commons-sampling":
                content = '\uf4f0';
                break;
            case "fa-creative-commons-sampling-plus":
                content = '\uf4f1';
                break;
            case "fa-creative-commons-share":
                content = '\uf4f2';
                break;
            case "fa-creative-commons-zero":
                content = '\uf4f3';
                break;
            case "fa-credit-card":
                content = '\uf09d';
                break;
            case "fa-critical-role":
                content = '\uf6c9';
                break;
            case "fa-crop":
                content = '\uf125';
                break;
            case "fa-crop-alt":
                content = '\uf565';
                break;
            case "fa-cross":
                content = '\uf654';
                break;
            case "fa-crosshairs":
                content = '\uf05b';
                break;
            case "fa-crow":
                content = '\uf520';
                break;
            case "fa-crown":
                content = '\uf521';
                break;
            case "fa-crutch":
                content = '\uf7f7';
                break;
            case "fa-css3":
                content = '\uf13c';
                break;
            case "fa-css3-alt":
                content = '\uf38b';
                break;
            case "fa-cube":
                content = '\uf1b2';
                break;
            case "fa-cubes":
                content = '\uf1b3';
                break;
            case "fa-cut":
                content = '\uf0c4';
                break;
            case "fa-cuttlefish":
                content = '\uf38c';
                break;
            case "fa-d-and-d":
                content = '\uf38d';
                break;
            case "fa-d-and-d-beyond":
                content = '\uf6ca';
                break;
            case "fa-dashcube":
                content = '\uf210';
                break;
            case "fa-database":
                content = '\uf1c0';
                break;
            case "fa-deaf":
                content = '\uf2a4';
                break;
            case "fa-delicious":
                content = '\uf1a5';
                break;
            case "fa-democrat":
                content = '\uf747';
                break;
            case "fa-deploydog":
                content = '\uf38e';
                break;
            case "fa-deskpro":
                content = '\uf38f';
                break;
            case "fa-desktop":
                content = '\uf108';
                break;
            case "fa-dev":
                content = '\uf6cc';
                break;
            case "fa-deviantart":
                content = '\uf1bd';
                break;
            case "fa-dharmachakra":
                content = '\uf655';
                break;
            case "fa-dhl":
                content = '\uf790';
                break;
            case "fa-diagnoses":
                content = '\uf470';
                break;
            case "fa-diaspora":
                content = '\uf791';
                break;
            case "fa-dice":
                content = '\uf522';
                break;
            case "fa-dice-d20":
                content = '\uf6cf';
                break;
            case "fa-dice-d6":
                content = '\uf6d1';
                break;
            case "fa-dice-five":
                content = '\uf523';
                break;
            case "fa-dice-four":
                content = '\uf524';
                break;
            case "fa-dice-one":
                content = '\uf525';
                break;
            case "fa-dice-six":
                content = '\uf526';
                break;
            case "fa-dice-three":
                content = '\uf527';
                break;
            case "fa-dice-two":
                content = '\uf528';
                break;
            case "fa-digg":
                content = '\uf1a6';
                break;
            case "fa-digital-ocean":
                content = '\uf391';
                break;
            case "fa-digital-tachograph":
                content = '\uf566';
                break;
            case "fa-directions":
                content = '\uf5eb';
                break;
            case "fa-discord":
                content = '\uf392';
                break;
            case "fa-discourse":
                content = '\uf393';
                break;
            case "fa-divide":
                content = '\uf529';
                break;
            case "fa-dizzy":
                content = '\uf567';
                break;
            case "fa-dna":
                content = '\uf471';
                break;
            case "fa-dochub":
                content = '\uf394';
                break;
            case "fa-docker":
                content = '\uf395';
                break;
            case "fa-dog":
                content = '\uf6d3';
                break;
            case "fa-dollar-sign":
                content = '\uf155';
                break;
            case "fa-dolly":
                content = '\uf472';
                break;
            case "fa-dolly-flatbed":
                content = '\uf474';
                break;
            case "fa-donate":
                content = '\uf4b9';
                break;
            case "fa-door-closed":
                content = '\uf52a';
                break;
            case "fa-door-open":
                content = '\uf52b';
                break;
            case "fa-dot-circle":
                content = '\uf192';
                break;
            case "fa-dove":
                content = '\uf4ba';
                break;
            case "fa-download":
                content = '\uf019';
                break;
            case "fa-draft2digital":
                content = '\uf396';
                break;
            case "fa-drafting-compass":
                content = '\uf568';
                break;
            case "fa-dragon":
                content = '\uf6d5';
                break;
            case "fa-draw-polygon":
                content = '\uf5ee';
                break;
            case "fa-dribbble":
                content = '\uf17d';
                break;
            case "fa-dribbble-square":
                content = '\uf397';
                break;
            case "fa-dropbox":
                content = '\uf16b';
                break;
            case "fa-drum":
                content = '\uf569';
                break;
            case "fa-drum-steelpan":
                content = '\uf56a';
                break;
            case "fa-drumstick-bite":
                content = '\uf6d7';
                break;
            case "fa-drupal":
                content = '\uf1a9';
                break;
            case "fa-dumbbell":
                content = '\uf44b';
                break;
            case "fa-dumpster":
                content = '\uf793';
                break;
            case "fa-dumpster-fire":
                content = '\uf794';
                break;
            case "fa-dungeon":
                content = '\uf6d9';
                break;
            case "fa-dyalog":
                content = '\uf399';
                break;
            case "fa-earlybirds":
                content = '\uf39a';
                break;
            case "fa-ebay":
                content = '\uf4f4';
                break;
            case "fa-edge":
                content = '\uf282';
                break;
            case "fa-edit":
                content = '\uf044';
                break;
            case "fa-egg":
                content = '\uf7fb';
                break;
            case "fa-eject":
                content = '\uf052';
                break;
            case "fa-elementor":
                content = '\uf430';
                break;
            case "fa-ellipsis-h":
                content = '\uf141';
                break;
            case "fa-ellipsis-v":
                content = '\uf142';
                break;
            case "fa-ello":
                content = '\uf5f1';
                break;
            case "fa-ember":
                content = '\uf423';
                break;
            case "fa-empire":
                content = '\uf1d1';
                break;
            case "fa-envelope":
                content = '\uf0e0';
                break;
            case "fa-envelope-open":
                content = '\uf2b6';
                break;
            case "fa-envelope-open-text":
                content = '\uf658';
                break;
            case "fa-envelope-square":
                content = '\uf199';
                break;
            case "fa-envira":
                content = '\uf299';
                break;
            case "fa-equals":
                content = '\uf52c';
                break;
            case "fa-eraser":
                content = '\uf12d';
                break;
            case "fa-erlang":
                content = '\uf39d';
                break;
            case "fa-ethereum":
                content = '\uf42e';
                break;
            case "fa-ethernet":
                content = '\uf796';
                break;
            case "fa-etsy":
                content = '\uf2d7';
                break;
            case "fa-euro-sign":
                content = '\uf153';
                break;
            case "fa-exchange-alt":
                content = '\uf362';
                break;
            case "fa-exclamation":
                content = '\uf12a';
                break;
            case "fa-exclamation-circle":
                content = '\uf06a';
                break;
            case "fa-exclamation-triangle":
                content = '\uf071';
                break;
            case "fa-expand":
                content = '\uf065';
                break;
            case "fa-expand-arrows-alt":
                content = '\uf31e';
                break;
            case "fa-expeditedssl":
                content = '\uf23e';
                break;
            case "fa-external-link-alt":
                content = '\uf35d';
                break;
            case "fa-external-link-square-alt":
                content = '\uf360';
                break;
            case "fa-eye":
                content = '\uf06e';
                break;
            case "fa-eye-dropper":
                content = '\uf1fb';
                break;
            case "fa-eye-slash":
                content = '\uf070';
                break;
            case "fa-facebook":
                content = '\uf09a';
                break;
            case "fa-facebook-f":
                content = '\uf39e';
                break;
            case "fa-facebook-messenger":
                content = '\uf39f';
                break;
            case "fa-facebook-square":
                content = '\uf082';
                break;
            case "fa-fantasy-flight-games":
                content = '\uf6dc';
                break;
            case "fa-fast-backward":
                content = '\uf049';
                break;
            case "fa-fast-forward":
                content = '\uf050';
                break;
            case "fa-fax":
                content = '\uf1ac';
                break;
            case "fa-feather":
                content = '\uf52d';
                break;
            case "fa-feather-alt":
                content = '\uf56b';
                break;
            case "fa-fedex":
                content = '\uf797';
                break;
            case "fa-fedora":
                content = '\uf798';
                break;
            case "fa-female":
                content = '\uf182';
                break;
            case "fa-fighter-jet":
                content = '\uf0fb';
                break;
            case "fa-figma":
                content = '\uf799';
                break;
            case "fa-file":
                content = '\uf15b';
                break;
            case "fa-file-alt":
                content = '\uf15c';
                break;
            case "fa-file-archive":
                content = '\uf1c6';
                break;
            case "fa-file-audio":
                content = '\uf1c7';
                break;
            case "fa-file-code":
                content = '\uf1c9';
                break;
            case "fa-file-contract":
                content = '\uf56c';
                break;
            case "fa-file-csv":
                content = '\uf6dd';
                break;
            case "fa-file-download":
                content = '\uf56d';
                break;
            case "fa-file-excel":
                content = '\uf1c3';
                break;
            case "fa-file-export":
                content = '\uf56e';
                break;
            case "fa-file-image":
                content = '\uf1c5';
                break;
            case "fa-file-import":
                content = '\uf56f';
                break;
            case "fa-file-invoice":
                content = '\uf570';
                break;
            case "fa-file-invoice-dollar":
                content = '\uf571';
                break;
            case "fa-file-medical":
                content = '\uf477';
                break;
            case "fa-file-medical-alt":
                content = '\uf478';
                break;
            case "fa-file-pdf":
                content = '\uf1c1';
                break;
            case "fa-file-powerpoint":
                content = '\uf1c4';
                break;
            case "fa-file-prescription":
                content = '\uf572';
                break;
            case "fa-file-signature":
                content = '\uf573';
                break;
            case "fa-file-upload":
                content = '\uf574';
                break;
            case "fa-file-video":
                content = '\uf1c8';
                break;
            case "fa-file-word":
                content = '\uf1c2';
                break;
            case "fa-fill":
                content = '\uf575';
                break;
            case "fa-fill-drip":
                content = '\uf576';
                break;
            case "fa-film":
                content = '\uf008';
                break;
            case "fa-filter":
                content = '\uf0b0';
                break;
            case "fa-fingerprint":
                content = '\uf577';
                break;
            case "fa-fire":
                content = '\uf06d';
                break;
            case "fa-fire-alt":
                content = '\uf7e4';
                break;
            case "fa-fire-extinguisher":
                content = '\uf134';
                break;
            case "fa-firefox":
                content = '\uf269';
                break;
            case "fa-first-aid":
                content = '\uf479';
                break;
            case "fa-first-order":
                content = '\uf2b0';
                break;
            case "fa-first-order-alt":
                content = '\uf50a';
                break;
            case "fa-firstdraft":
                content = '\uf3a1';
                break;
            case "fa-fish":
                content = '\uf578';
                break;
            case "fa-fist-raised":
                content = '\uf6de';
                break;
            case "fa-flag":
                content = '\uf024';
                break;
            case "fa-flag-checkered":
                content = '\uf11e';
                break;
            case "fa-flag-usa":
                content = '\uf74d';
                break;
            case "fa-flask":
                content = '\uf0c3';
                break;
            case "fa-flickr":
                content = '\uf16e';
                break;
            case "fa-flipboard":
                content = '\uf44d';
                break;
            case "fa-flushed":
                content = '\uf579';
                break;
            case "fa-fly":
                content = '\uf417';
                break;
            case "fa-folder":
                content = '\uf07b';
                break;
            case "fa-folder-minus":
                content = '\uf65d';
                break;
            case "fa-folder-open":
                content = '\uf07c';
                break;
            case "fa-folder-plus":
                content = '\uf65e';
                break;
            case "fa-font":
                content = '\uf031';
                break;
            case "fa-font-awesome":
                content = '\uf2b4';
                break;
            case "fa-font-awesome-alt":
                content = '\uf35c';
                break;
            case "fa-font-awesome-flag":
                content = '\uf425';
                break;
            case "fa-font-awesome-logo-full":
                content = '\uf4e6';
                break;
            case "fa-fonticons":
                content = '\uf280';
                break;
            case "fa-fonticons-fi":
                content = '\uf3a2';
                break;
            case "fa-football-ball":
                content = '\uf44e';
                break;
            case "fa-fort-awesome":
                content = '\uf286';
                break;
            case "fa-fort-awesome-alt":
                content = '\uf3a3';
                break;
            case "fa-forumbee":
                content = '\uf211';
                break;
            case "fa-forward":
                content = '\uf04e';
                break;
            case "fa-foursquare":
                content = '\uf180';
                break;
            case "fa-free-code-camp":
                content = '\uf2c5';
                break;
            case "fa-freebsd":
                content = '\uf3a4';
                break;
            case "fa-frog":
                content = '\uf52e';
                break;
            case "fa-frown":
                content = '\uf119';
                break;
            case "fa-frown-open":
                content = '\uf57a';
                break;
            case "fa-fulcrum":
                content = '\uf50b';
                break;
            case "fa-funnel-dollar":
                content = '\uf662';
                break;
            case "fa-futbol":
                content = '\uf1e3';
                break;
            case "fa-galactic-republic":
                content = '\uf50c';
                break;
            case "fa-galactic-senate":
                content = '\uf50d';
                break;
            case "fa-gamepad":
                content = '\uf11b';
                break;
            case "fa-gas-pump":
                content = '\uf52f';
                break;
            case "fa-gavel":
                content = '\uf0e3';
                break;
            case "fa-gem":
                content = '\uf3a5';
                break;
            case "fa-genderless":
                content = '\uf22d';
                break;
            case "fa-get-pocket":
                content = '\uf265';
                break;
            case "fa-gg":
                content = '\uf260';
                break;
            case "fa-gg-circle":
                content = '\uf261';
                break;
            case "fa-ghost":
                content = '\uf6e2';
                break;
            case "fa-gift":
                content = '\uf06b';
                break;
            case "fa-gifts":
                content = '\uf79c';
                break;
            case "fa-git":
                content = '\uf1d3';
                break;
            case "fa-git-square":
                content = '\uf1d2';
                break;
            case "fa-github":
                content = '\uf09b';
                break;
            case "fa-github-alt":
                content = '\uf113';
                break;
            case "fa-github-square":
                content = '\uf092';
                break;
            case "fa-gitkraken":
                content = '\uf3a6';
                break;
            case "fa-gitlab":
                content = '\uf296';
                break;
            case "fa-gitter":
                content = '\uf426';
                break;
            case "fa-glass-cheers":
                content = '\uf79f';
                break;
            case "fa-glass-martini":
                content = '\uf000';
                break;
            case "fa-glass-martini-alt":
                content = '\uf57b';
                break;
            case "fa-glass-whiskey":
                content = '\uf7a0';
                break;
            case "fa-glasses":
                content = '\uf530';
                break;
            case "fa-glide":
                content = '\uf2a5';
                break;
            case "fa-glide-g":
                content = '\uf2a6';
                break;
            case "fa-globe":
                content = '\uf0ac';
                break;
            case "fa-globe-africa":
                content = '\uf57c';
                break;
            case "fa-globe-americas":
                content = '\uf57d';
                break;
            case "fa-globe-asia":
                content = '\uf57e';
                break;
            case "fa-globe-europe":
                content = '\uf7a2';
                break;
            case "fa-gofore":
                content = '\uf3a7';
                break;
            case "fa-golf-ball":
                content = '\uf450';
                break;
            case "fa-goodreads":
                content = '\uf3a8';
                break;
            case "fa-goodreads-g":
                content = '\uf3a9';
                break;
            case "fa-google":
                content = '\uf1a0';
                break;
            case "fa-google-drive":
                content = '\uf3aa';
                break;
            case "fa-google-play":
                content = '\uf3ab';
                break;
            case "fa-google-plus":
                content = '\uf2b3';
                break;
            case "fa-google-plus-g":
                content = '\uf0d5';
                break;
            case "fa-google-plus-square":
                content = '\uf0d4';
                break;
            case "fa-google-wallet":
                content = '\uf1ee';
                break;
            case "fa-gopuram":
                content = '\uf664';
                break;
            case "fa-graduation-cap":
                content = '\uf19d';
                break;
            case "fa-gratipay":
                content = '\uf184';
                break;
            case "fa-grav":
                content = '\uf2d6';
                break;
            case "fa-greater-than":
                content = '\uf531';
                break;
            case "fa-greater-than-equal":
                content = '\uf532';
                break;
            case "fa-grimace":
                content = '\uf57f';
                break;
            case "fa-grin":
                content = '\uf580';
                break;
            case "fa-grin-alt":
                content = '\uf581';
                break;
            case "fa-grin-beam":
                content = '\uf582';
                break;
            case "fa-grin-beam-sweat":
                content = '\uf583';
                break;
            case "fa-grin-hearts":
                content = '\uf584';
                break;
            case "fa-grin-squint":
                content = '\uf585';
                break;
            case "fa-grin-squint-tears":
                content = '\uf586';
                break;
            case "fa-grin-stars":
                content = '\uf587';
                break;
            case "fa-grin-tears":
                content = '\uf588';
                break;
            case "fa-grin-tongue":
                content = '\uf589';
                break;
            case "fa-grin-tongue-squint":
                content = '\uf58a';
                break;
            case "fa-grin-tongue-wink":
                content = '\uf58b';
                break;
            case "fa-grin-wink":
                content = '\uf58c';
                break;
            case "fa-grip-horizontal":
                content = '\uf58d';
                break;
            case "fa-grip-lines":
                content = '\uf7a4';
                break;
            case "fa-grip-lines-vertical":
                content = '\uf7a5';
                break;
            case "fa-grip-vertical":
                content = '\uf58e';
                break;
            case "fa-gripfire":
                content = '\uf3ac';
                break;
            case "fa-grunt":
                content = '\uf3ad';
                break;
            case "fa-guitar":
                content = '\uf7a6';
                break;
            case "fa-gulp":
                content = '\uf3ae';
                break;
            case "fa-h-square":
                content = '\uf0fd';
                break;
            case "fa-hacker-news":
                content = '\uf1d4';
                break;
            case "fa-hacker-news-square":
                content = '\uf3af';
                break;
            case "fa-hackerrank":
                content = '\uf5f7';
                break;
            case "fa-hamburger":
                content = '\uf805';
                break;
            case "fa-hammer":
                content = '\uf6e3';
                break;
            case "fa-hamsa":
                content = '\uf665';
                break;
            case "fa-hand-holding":
                content = '\uf4bd';
                break;
            case "fa-hand-holding-heart":
                content = '\uf4be';
                break;
            case "fa-hand-holding-usd":
                content = '\uf4c0';
                break;
            case "fa-hand-lizard":
                content = '\uf258';
                break;
            case "fa-hand-middle-finger":
                content = '\uf806';
                break;
            case "fa-hand-paper":
                content = '\uf256';
                break;
            case "fa-hand-peace":
                content = '\uf25b';
                break;
            case "fa-hand-point-down":
                content = '\uf0a7';
                break;
            case "fa-hand-point-left":
                content = '\uf0a5';
                break;
            case "fa-hand-point-right":
                content = '\uf0a4';
                break;
            case "fa-hand-point-up":
                content = '\uf0a6';
                break;
            case "fa-hand-pointer":
                content = '\uf25a';
                break;
            case "fa-hand-rock":
                content = '\uf255';
                break;
            case "fa-hand-scissors":
                content = '\uf257';
                break;
            case "fa-hand-spock":
                content = '\uf259';
                break;
            case "fa-hands":
                content = '\uf4c2';
                break;
            case "fa-hands-helping":
                content = '\uf4c4';
                break;
            case "fa-handshake":
                content = '\uf2b5';
                break;
            case "fa-hanukiah":
                content = '\uf6e6';
                break;
            case "fa-hard-hat":
                content = '\uf807';
                break;
            case "fa-hashtag":
                content = '\uf292';
                break;
            case "fa-hat-wizard":
                content = '\uf6e8';
                break;
            case "fa-haykal":
                content = '\uf666';
                break;
            case "fa-hdd":
                content = '\uf0a0';
                break;
            case "fa-heading":
                content = '\uf1dc';
                break;
            case "fa-headphones":
                content = '\uf025';
                break;
            case "fa-headphones-alt":
                content = '\uf58f';
                break;
            case "fa-headset":
                content = '\uf590';
                break;
            case "fa-heart":
                content = '\uf004';
                break;
            case "fa-heart-broken":
                content = '\uf7a9';
                break;
            case "fa-heartbeat":
                content = '\uf21e';
                break;
            case "fa-helicopter":
                content = '\uf533';
                break;
            case "fa-highlighter":
                content = '\uf591';
                break;
            case "fa-hiking":
                content = '\uf6ec';
                break;
            case "fa-hippo":
                content = '\uf6ed';
                break;
            case "fa-hips":
                content = '\uf452';
                break;
            case "fa-hire-a-helper":
                content = '\uf3b0';
                break;
            case "fa-history":
                content = '\uf1da';
                break;
            case "fa-hockey-puck":
                content = '\uf453';
                break;
            case "fa-holly-berry":
                content = '\uf7aa';
                break;
            case "fa-home":
                content = '\uf015';
                break;
            case "fa-hooli":
                content = '\uf427';
                break;
            case "fa-hornbill":
                content = '\uf592';
                break;
            case "fa-horse":
                content = '\uf6f0';
                break;
            case "fa-horse-head":
                content = '\uf7ab';
                break;
            case "fa-hospital":
                content = '\uf0f8';
                break;
            case "fa-hospital-alt":
                content = '\uf47d';
                break;
            case "fa-hospital-symbol":
                content = '\uf47e';
                break;
            case "fa-hot-tub":
                content = '\uf593';
                break;
            case "fa-hotdog":
                content = '\uf80f';
                break;
            case "fa-hotel":
                content = '\uf594';
                break;
            case "fa-hotjar":
                content = '\uf3b1';
                break;
            case "fa-hourglass":
                content = '\uf254';
                break;
            case "fa-hourglass-end":
                content = '\uf253';
                break;
            case "fa-hourglass-half":
                content = '\uf252';
                break;
            case "fa-hourglass-start":
                content = '\uf251';
                break;
            case "fa-house-damage":
                content = '\uf6f1';
                break;
            case "fa-houzz":
                content = '\uf27c';
                break;
            case "fa-hryvnia":
                content = '\uf6f2';
                break;
            case "fa-html5":
                content = '\uf13b';
                break;
            case "fa-hubspot":
                content = '\uf3b2';
                break;
            case "fa-i-cursor":
                content = '\uf246';
                break;
            case "fa-ice-cream":
                content = '\uf810';
                break;
            case "fa-icicles":
                content = '\uf7ad';
                break;
            case "fa-id-badge":
                content = '\uf2c1';
                break;
            case "fa-id-card":
                content = '\uf2c2';
                break;
            case "fa-id-card-alt":
                content = '\uf47f';
                break;
            case "fa-igloo":
                content = '\uf7ae';
                break;
            case "fa-image":
                content = '\uf03e';
                break;
            case "fa-images":
                content = '\uf302';
                break;
            case "fa-imdb":
                content = '\uf2d8';
                break;
            case "fa-inbox":
                content = '\uf01c';
                break;
            case "fa-indent":
                content = '\uf03c';
                break;
            case "fa-industry":
                content = '\uf275';
                break;
            case "fa-infinity":
                content = '\uf534';
                break;
            case "fa-info":
                content = '\uf129';
                break;
            case "fa-info-circle":
                content = '\uf05a';
                break;
            case "fa-instagram":
                content = '\uf16d';
                break;
            case "fa-intercom":
                content = '\uf7af';
                break;
            case "fa-internet-explorer":
                content = '\uf26b';
                break;
            case "fa-invision":
                content = '\uf7b0';
                break;
            case "fa-ioxhost":
                content = '\uf208';
                break;
            case "fa-italic":
                content = '\uf033';
                break;
            case "fa-itunes":
                content = '\uf3b4';
                break;
            case "fa-itunes-note":
                content = '\uf3b5';
                break;
            case "fa-java":
                content = '\uf4e4';
                break;
            case "fa-jedi":
                content = '\uf669';
                break;
            case "fa-jedi-order":
                content = '\uf50e';
                break;
            case "fa-jenkins":
                content = '\uf3b6';
                break;
            case "fa-jira":
                content = '\uf7b1';
                break;
            case "fa-joget":
                content = '\uf3b7';
                break;
            case "fa-joint":
                content = '\uf595';
                break;
            case "fa-joomla":
                content = '\uf1aa';
                break;
            case "fa-journal-whills":
                content = '\uf66a';
                break;
            case "fa-js":
                content = '\uf3b8';
                break;
            case "fa-js-square":
                content = '\uf3b9';
                break;
            case "fa-jsfiddle":
                content = '\uf1cc';
                break;
            case "fa-kaaba":
                content = '\uf66b';
                break;
            case "fa-kaggle":
                content = '\uf5fa';
                break;
            case "fa-key":
                content = '\uf084';
                break;
            case "fa-keybase":
                content = '\uf4f5';
                break;
            case "fa-keyboard":
                content = '\uf11c';
                break;
            case "fa-keycdn":
                content = '\uf3ba';
                break;
            case "fa-khanda":
                content = '\uf66d';
                break;
            case "fa-kickstarter":
                content = '\uf3bb';
                break;
            case "fa-kickstarter-k":
                content = '\uf3bc';
                break;
            case "fa-kiss":
                content = '\uf596';
                break;
            case "fa-kiss-beam":
                content = '\uf597';
                break;
            case "fa-kiss-wink-heart":
                content = '\uf598';
                break;
            case "fa-kiwi-bird":
                content = '\uf535';
                break;
            case "fa-korvue":
                content = '\uf42f';
                break;
            case "fa-landmark":
                content = '\uf66f';
                break;
            case "fa-language":
                content = '\uf1ab';
                break;
            case "fa-laptop":
                content = '\uf109';
                break;
            case "fa-laptop-code":
                content = '\uf5fc';
                break;
            case "fa-laptop-medical":
                content = '\uf812';
                break;
            case "fa-laravel":
                content = '\uf3bd';
                break;
            case "fa-lastfm":
                content = '\uf202';
                break;
            case "fa-lastfm-square":
                content = '\uf203';
                break;
            case "fa-laugh":
                content = '\uf599';
                break;
            case "fa-laugh-beam":
                content = '\uf59a';
                break;
            case "fa-laugh-squint":
                content = '\uf59b';
                break;
            case "fa-laugh-wink":
                content = '\uf59c';
                break;
            case "fa-layer-group":
                content = '\uf5fd';
                break;
            case "fa-leaf":
                content = '\uf06c';
                break;
            case "fa-leanpub":
                content = '\uf212';
                break;
            case "fa-lemon":
                content = '\uf094';
                break;
            case "fa-less":
                content = '\uf41d';
                break;
            case "fa-less-than":
                content = '\uf536';
                break;
            case "fa-less-than-equal":
                content = '\uf537';
                break;
            case "fa-level-down-alt":
                content = '\uf3be';
                break;
            case "fa-level-up-alt":
                content = '\uf3bf';
                break;
            case "fa-life-ring":
                content = '\uf1cd';
                break;
            case "fa-lightbulb":
                content = '\uf0eb';
                break;
            case "fa-line":
                content = '\uf3c0';
                break;
            case "fa-link":
                content = '\uf0c1';
                break;
            case "fa-linkedin":
                content = '\uf08c';
                break;
            case "fa-linkedin-in":
                content = '\uf0e1';
                break;
            case "fa-linode":
                content = '\uf2b8';
                break;
            case "fa-linux":
                content = '\uf17c';
                break;
            case "fa-lira-sign":
                content = '\uf195';
                break;
            case "fa-list":
                content = '\uf03a';
                break;
            case "fa-list-alt":
                content = '\uf022';
                break;
            case "fa-list-ol":
                content = '\uf0cb';
                break;
            case "fa-list-ul":
                content = '\uf0ca';
                break;
            case "fa-location-arrow":
                content = '\uf124';
                break;
            case "fa-lock":
                content = '\uf023';
                break;
            case "fa-lock-open":
                content = '\uf3c1';
                break;
            case "fa-long-arrow-alt-down":
                content = '\uf309';
                break;
            case "fa-long-arrow-alt-left":
                content = '\uf30a';
                break;
            case "fa-long-arrow-alt-right":
                content = '\uf30b';
                break;
            case "fa-long-arrow-alt-up":
                content = '\uf30c';
                break;
            case "fa-low-vision":
                content = '\uf2a8';
                break;
            case "fa-luggage-cart":
                content = '\uf59d';
                break;
            case "fa-lyft":
                content = '\uf3c3';
                break;
            case "fa-magento":
                content = '\uf3c4';
                break;
            case "fa-magic":
                content = '\uf0d0';
                break;
            case "fa-magnet":
                content = '\uf076';
                break;
            case "fa-mail-bulk":
                content = '\uf674';
                break;
            case "fa-mailchimp":
                content = '\uf59e';
                break;
            case "fa-male":
                content = '\uf183';
                break;
            case "fa-mandalorian":
                content = '\uf50f';
                break;
            case "fa-map":
                content = '\uf279';
                break;
            case "fa-map-marked":
                content = '\uf59f';
                break;
            case "fa-map-marked-alt":
                content = '\uf5a0';
                break;
            case "fa-map-marker":
                content = '\uf041';
                break;
            case "fa-map-marker-alt":
                content = '\uf3c5';
                break;
            case "fa-map-pin":
                content = '\uf276';
                break;
            case "fa-map-signs":
                content = '\uf277';
                break;
            case "fa-markdown":
                content = '\uf60f';
                break;
            case "fa-marker":
                content = '\uf5a1';
                break;
            case "fa-mars":
                content = '\uf222';
                break;
            case "fa-mars-double":
                content = '\uf227';
                break;
            case "fa-mars-stroke":
                content = '\uf229';
                break;
            case "fa-mars-stroke-h":
                content = '\uf22b';
                break;
            case "fa-mars-stroke-v":
                content = '\uf22a';
                break;
            case "fa-mask":
                content = '\uf6fa';
                break;
            case "fa-mastodon":
                content = '\uf4f6';
                break;
            case "fa-maxcdn":
                content = '\uf136';
                break;
            case "fa-medal":
                content = '\uf5a2';
                break;
            case "fa-medapps":
                content = '\uf3c6';
                break;
            case "fa-medium":
                content = '\uf23a';
                break;
            case "fa-medium-m":
                content = '\uf3c7';
                break;
            case "fa-medkit":
                content = '\uf0fa';
                break;
            case "fa-medrt":
                content = '\uf3c8';
                break;
            case "fa-meetup":
                content = '\uf2e0';
                break;
            case "fa-megaport":
                content = '\uf5a3';
                break;
            case "fa-meh":
                content = '\uf11a';
                break;
            case "fa-meh-blank":
                content = '\uf5a4';
                break;
            case "fa-meh-rolling-eyes":
                content = '\uf5a5';
                break;
            case "fa-memory":
                content = '\uf538';
                break;
            case "fa-mendeley":
                content = '\uf7b3';
                break;
            case "fa-menorah":
                content = '\uf676';
                break;
            case "fa-mercury":
                content = '\uf223';
                break;
            case "fa-meteor":
                content = '\uf753';
                break;
            case "fa-microchip":
                content = '\uf2db';
                break;
            case "fa-microphone":
                content = '\uf130';
                break;
            case "fa-microphone-alt":
                content = '\uf3c9';
                break;
            case "fa-microphone-alt-slash":
                content = '\uf539';
                break;
            case "fa-microphone-slash":
                content = '\uf131';
                break;
            case "fa-microscope":
                content = '\uf610';
                break;
            case "fa-microsoft":
                content = '\uf3ca';
                break;
            case "fa-minus":
                content = '\uf068';
                break;
            case "fa-minus-circle":
                content = '\uf056';
                break;
            case "fa-minus-square":
                content = '\uf146';
                break;
            case "fa-mitten":
                content = '\uf7b5';
                break;
            case "fa-mix":
                content = '\uf3cb';
                break;
            case "fa-mixcloud":
                content = '\uf289';
                break;
            case "fa-mizuni":
                content = '\uf3cc';
                break;
            case "fa-mobile":
                content = '\uf10b';
                break;
            case "fa-mobile-alt":
                content = '\uf3cd';
                break;
            case "fa-modx":
                content = '\uf285';
                break;
            case "fa-monero":
                content = '\uf3d0';
                break;
            case "fa-money-bill":
                content = '\uf0d6';
                break;
            case "fa-money-bill-alt":
                content = '\uf3d1';
                break;
            case "fa-money-bill-wave":
                content = '\uf53a';
                break;
            case "fa-money-bill-wave-alt":
                content = '\uf53b';
                break;
            case "fa-money-check":
                content = '\uf53c';
                break;
            case "fa-money-check-alt":
                content = '\uf53d';
                break;
            case "fa-monument":
                content = '\uf5a6';
                break;
            case "fa-moon":
                content = '\uf186';
                break;
            case "fa-mortar-pestle":
                content = '\uf5a7';
                break;
            case "fa-mosque":
                content = '\uf678';
                break;
            case "fa-motorcycle":
                content = '\uf21c';
                break;
            case "fa-mountain":
                content = '\uf6fc';
                break;
            case "fa-mouse-pointer":
                content = '\uf245';
                break;
            case "fa-mug-hot":
                content = '\uf7b6';
                break;
            case "fa-music":
                content = '\uf001';
                break;
            case "fa-napster":
                content = '\uf3d2';
                break;
            case "fa-neos":
                content = '\uf612';
                break;
            case "fa-network-wired":
                content = '\uf6ff';
                break;
            case "fa-neuter":
                content = '\uf22c';
                break;
            case "fa-newspaper":
                content = '\uf1ea';
                break;
            case "fa-nimblr":
                content = '\uf5a8';
                break;
            case "fa-nintendo-switch":
                content = '\uf418';
                break;
            case "fa-node":
                content = '\uf419';
                break;
            case "fa-node-js":
                content = '\uf3d3';
                break;
            case "fa-not-equal":
                content = '\uf53e';
                break;
            case "fa-notes-medical":
                content = '\uf481';
                break;
            case "fa-npm":
                content = '\uf3d4';
                break;
            case "fa-ns8":
                content = '\uf3d5';
                break;
            case "fa-nutritionix":
                content = '\uf3d6';
                break;
            case "fa-object-group":
                content = '\uf247';
                break;
            case "fa-object-ungroup":
                content = '\uf248';
                break;
            case "fa-odnoklassniki":
                content = '\uf263';
                break;
            case "fa-odnoklassniki-square":
                content = '\uf264';
                break;
            case "fa-oil-can":
                content = '\uf613';
                break;
            case "fa-old-republic":
                content = '\uf510';
                break;
            case "fa-om":
                content = '\uf679';
                break;
            case "fa-opencart":
                content = '\uf23d';
                break;
            case "fa-openid":
                content = '\uf19b';
                break;
            case "fa-opera":
                content = '\uf26a';
                break;
            case "fa-optin-monster":
                content = '\uf23c';
                break;
            case "fa-osi":
                content = '\uf41a';
                break;
            case "fa-otter":
                content = '\uf700';
                break;
            case "fa-outdent":
                content = '\uf03b';
                break;
            case "fa-page4":
                content = '\uf3d7';
                break;
            case "fa-pagelines":
                content = '\uf18c';
                break;
            case "fa-pager":
                content = '\uf815';
                break;
            case "fa-paint-brush":
                content = '\uf1fc';
                break;
            case "fa-paint-roller":
                content = '\uf5aa';
                break;
            case "fa-palette":
                content = '\uf53f';
                break;
            case "fa-palfed":
                content = '\uf3d8';
                break;
            case "fa-pallet":
                content = '\uf482';
                break;
            case "fa-paper-plane":
                content = '\uf1d8';
                break;
            case "fa-paperclip":
                content = '\uf0c6';
                break;
            case "fa-parachute-box":
                content = '\uf4cd';
                break;
            case "fa-paragraph":
                content = '\uf1dd';
                break;
            case "fa-parking":
                content = '\uf540';
                break;
            case "fa-passport":
                content = '\uf5ab';
                break;
            case "fa-pastafarianism":
                content = '\uf67b';
                break;
            case "fa-paste":
                content = '\uf0ea';
                break;
            case "fa-patreon":
                content = '\uf3d9';
                break;
            case "fa-pause":
                content = '\uf04c';
                break;
            case "fa-pause-circle":
                content = '\uf28b';
                break;
            case "fa-paw":
                content = '\uf1b0';
                break;
            case "fa-paypal":
                content = '\uf1ed';
                break;
            case "fa-peace":
                content = '\uf67c';
                break;
            case "fa-pen":
                content = '\uf304';
                break;
            case "fa-pen-alt":
                content = '\uf305';
                break;
            case "fa-pen-fancy":
                content = '\uf5ac';
                break;
            case "fa-pen-nib":
                content = '\uf5ad';
                break;
            case "fa-pen-square":
                content = '\uf14b';
                break;
            case "fa-pencil-alt":
                content = '\uf303';
                break;
            case "fa-pencil-ruler":
                content = '\uf5ae';
                break;
            case "fa-penny-arcade":
                content = '\uf704';
                break;
            case "fa-people-carry":
                content = '\uf4ce';
                break;
            case "fa-pepper-hot":
                content = '\uf816';
                break;
            case "fa-percent":
                content = '\uf295';
                break;
            case "fa-percentage":
                content = '\uf541';
                break;
            case "fa-periscope":
                content = '\uf3da';
                break;
            case "fa-person-booth":
                content = '\uf756';
                break;
            case "fa-phabricator":
                content = '\uf3db';
                break;
            case "fa-phoenix-framework":
                content = '\uf3dc';
                break;
            case "fa-phoenix-squadron":
                content = '\uf511';
                break;
            case "fa-phone":
                content = '\uf095';
                break;
            case "fa-phone-slash":
                content = '\uf3dd';
                break;
            case "fa-phone-square":
                content = '\uf098';
                break;
            case "fa-phone-volume":
                content = '\uf2a0';
                break;
            case "fa-php":
                content = '\uf457';
                break;
            case "fa-pied-piper":
                content = '\uf2ae';
                break;
            case "fa-pied-piper-alt":
                content = '\uf1a8';
                break;
            case "fa-pied-piper-hat":
                content = '\uf4e5';
                break;
            case "fa-pied-piper-pp":
                content = '\uf1a7';
                break;
            case "fa-piggy-bank":
                content = '\uf4d3';
                break;
            case "fa-pills":
                content = '\uf484';
                break;
            case "fa-pinterest":
                content = '\uf0d2';
                break;
            case "fa-pinterest-p":
                content = '\uf231';
                break;
            case "fa-pinterest-square":
                content = '\uf0d3';
                break;
            case "fa-pizza-slice":
                content = '\uf818';
                break;
            case "fa-place-of-worship":
                content = '\uf67f';
                break;
            case "fa-plane":
                content = '\uf072';
                break;
            case "fa-plane-arrival":
                content = '\uf5af';
                break;
            case "fa-plane-departure":
                content = '\uf5b0';
                break;
            case "fa-play":
                content = '\uf04b';
                break;
            case "fa-play-circle":
                content = '\uf144';
                break;
            case "fa-playstation":
                content = '\uf3df';
                break;
            case "fa-plug":
                content = '\uf1e6';
                break;
            case "fa-plus":
                content = '\uf067';
                break;
            case "fa-plus-circle":
                content = '\uf055';
                break;
            case "fa-plus-square":
                content = '\uf0fe';
                break;
            case "fa-podcast":
                content = '\uf2ce';
                break;
            case "fa-poll":
                content = '\uf681';
                break;
            case "fa-poll-h":
                content = '\uf682';
                break;
            case "fa-poo":
                content = '\uf2fe';
                break;
            case "fa-poo-storm":
                content = '\uf75a';
                break;
            case "fa-poop":
                content = '\uf619';
                break;
            case "fa-portrait":
                content = '\uf3e0';
                break;
            case "fa-pound-sign":
                content = '\uf154';
                break;
            case "fa-power-off":
                content = '\uf011';
                break;
            case "fa-pray":
                content = '\uf683';
                break;
            case "fa-praying-hands":
                content = '\uf684';
                break;
            case "fa-prescription":
                content = '\uf5b1';
                break;
            case "fa-prescription-bottle":
                content = '\uf485';
                break;
            case "fa-prescription-bottle-alt":
                content = '\uf486';
                break;
            case "fa-print":
                content = '\uf02f';
                break;
            case "fa-procedures":
                content = '\uf487';
                break;
            case "fa-product-hunt":
                content = '\uf288';
                break;
            case "fa-project-diagram":
                content = '\uf542';
                break;
            case "fa-pushed":
                content = '\uf3e1';
                break;
            case "fa-puzzle-piece":
                content = '\uf12e';
                break;
            case "fa-python":
                content = '\uf3e2';
                break;
            case "fa-qq":
                content = '\uf1d6';
                break;
            case "fa-qrcode":
                content = '\uf029';
                break;
            case "fa-question":
                content = '\uf128';
                break;
            case "fa-question-circle":
                content = '\uf059';
                break;
            case "fa-quidditch":
                content = '\uf458';
                break;
            case "fa-quinscape":
                content = '\uf459';
                break;
            case "fa-quora":
                content = '\uf2c4';
                break;
            case "fa-quote-left":
                content = '\uf10d';
                break;
            case "fa-quote-right":
                content = '\uf10e';
                break;
            case "fa-quran":
                content = '\uf687';
                break;
            case "fa-r-project":
                content = '\uf4f7';
                break;
            case "fa-radiation":
                content = '\uf7b9';
                break;
            case "fa-radiation-alt":
                content = '\uf7ba';
                break;
            case "fa-rainbow":
                content = '\uf75b';
                break;
            case "fa-random":
                content = '\uf074';
                break;
            case "fa-raspberry-pi":
                content = '\uf7bb';
                break;
            case "fa-ravelry":
                content = '\uf2d9';
                break;
            case "fa-react":
                content = '\uf41b';
                break;
            case "fa-reacteurope":
                content = '\uf75d';
                break;
            case "fa-readme":
                content = '\uf4d5';
                break;
            case "fa-rebel":
                content = '\uf1d0';
                break;
            case "fa-receipt":
                content = '\uf543';
                break;
            case "fa-recycle":
                content = '\uf1b8';
                break;
            case "fa-red-river":
                content = '\uf3e3';
                break;
            case "fa-reddit":
                content = '\uf1a1';
                break;
            case "fa-reddit-alien":
                content = '\uf281';
                break;
            case "fa-reddit-square":
                content = '\uf1a2';
                break;
            case "fa-redhat":
                content = '\uf7bc';
                break;
            case "fa-redo":
                content = '\uf01e';
                break;
            case "fa-redo-alt":
                content = '\uf2f9';
                break;
            case "fa-registered":
                content = '\uf25d';
                break;
            case "fa-renren":
                content = '\uf18b';
                break;
            case "fa-reply":
                content = '\uf3e5';
                break;
            case "fa-reply-all":
                content = '\uf122';
                break;
            case "fa-replyd":
                content = '\uf3e6';
                break;
            case "fa-republican":
                content = '\uf75e';
                break;
            case "fa-researchgate":
                content = '\uf4f8';
                break;
            case "fa-resolving":
                content = '\uf3e7';
                break;
            case "fa-restroom":
                content = '\uf7bd';
                break;
            case "fa-retweet":
                content = '\uf079';
                break;
            case "fa-rev":
                content = '\uf5b2';
                break;
            case "fa-ribbon":
                content = '\uf4d6';
                break;
            case "fa-ring":
                content = '\uf70b';
                break;
            case "fa-road":
                content = '\uf018';
                break;
            case "fa-robot":
                content = '\uf544';
                break;
            case "fa-rocket":
                content = '\uf135';
                break;
            case "fa-rocketchat":
                content = '\uf3e8';
                break;
            case "fa-rockrms":
                content = '\uf3e9';
                break;
            case "fa-route":
                content = '\uf4d7';
                break;
            case "fa-rss":
                content = '\uf09e';
                break;
            case "fa-rss-square":
                content = '\uf143';
                break;
            case "fa-ruble-sign":
                content = '\uf158';
                break;
            case "fa-ruler":
                content = '\uf545';
                break;
            case "fa-ruler-combined":
                content = '\uf546';
                break;
            case "fa-ruler-horizontal":
                content = '\uf547';
                break;
            case "fa-ruler-vertical":
                content = '\uf548';
                break;
            case "fa-running":
                content = '\uf70c';
                break;
            case "fa-rupee-sign":
                content = '\uf156';
                break;
            case "fa-sad-cry":
                content = '\uf5b3';
                break;
            case "fa-sad-tear":
                content = '\uf5b4';
                break;
            case "fa-safari":
                content = '\uf267';
                break;
            case "fa-sass":
                content = '\uf41e';
                break;
            case "fa-satellite":
                content = '\uf7bf';
                break;
            case "fa-satellite-dish":
                content = '\uf7c0';
                break;
            case "fa-save":
                content = '\uf0c7';
                break;
            case "fa-schlix":
                content = '\uf3ea';
                break;
            case "fa-school":
                content = '\uf549';
                break;
            case "fa-screwdriver":
                content = '\uf54a';
                break;
            case "fa-scribd":
                content = '\uf28a';
                break;
            case "fa-scroll":
                content = '\uf70e';
                break;
            case "fa-sd-card":
                content = '\uf7c2';
                break;
            case "fa-search":
                content = '\uf002';
                break;
            case "fa-search-dollar":
                content = '\uf688';
                break;
            case "fa-search-location":
                content = '\uf689';
                break;
            case "fa-search-minus":
                content = '\uf010';
                break;
            case "fa-search-plus":
                content = '\uf00e';
                break;
            case "fa-searchengin":
                content = '\uf3eb';
                break;
            case "fa-seedling":
                content = '\uf4d8';
                break;
            case "fa-sellcast":
                content = '\uf2da';
                break;
            case "fa-sellsy":
                content = '\uf213';
                break;
            case "fa-server":
                content = '\uf233';
                break;
            case "fa-servicestack":
                content = '\uf3ec';
                break;
            case "fa-shapes":
                content = '\uf61f';
                break;
            case "fa-share":
                content = '\uf064';
                break;
            case "fa-share-alt":
                content = '\uf1e0';
                break;
            case "fa-share-alt-square":
                content = '\uf1e1';
                break;
            case "fa-share-square":
                content = '\uf14d';
                break;
            case "fa-shekel-sign":
                content = '\uf20b';
                break;
            case "fa-shield-alt":
                content = '\uf3ed';
                break;
            case "fa-ship":
                content = '\uf21a';
                break;
            case "fa-shipping-fast":
                content = '\uf48b';
                break;
            case "fa-shirtsinbulk":
                content = '\uf214';
                break;
            case "fa-shoe-prints":
                content = '\uf54b';
                break;
            case "fa-shopping-bag":
                content = '\uf290';
                break;
            case "fa-shopping-basket":
                content = '\uf291';
                break;
            case "fa-shopping-cart":
                content = '\uf07a';
                break;
            case "fa-shopware":
                content = '\uf5b5';
                break;
            case "fa-shower":
                content = '\uf2cc';
                break;
            case "fa-shuttle-van":
                content = '\uf5b6';
                break;
            case "fa-sign":
                content = '\uf4d9';
                break;
            case "fa-sign-in-alt":
                content = '\uf2f6';
                break;
            case "fa-sign-language":
                content = '\uf2a7';
                break;
            case "fa-sign-out-alt":
                content = '\uf2f5';
                break;
            case "fa-signal":
                content = '\uf012';
                break;
            case "fa-signature":
                content = '\uf5b7';
                break;
            case "fa-sim-card":
                content = '\uf7c4';
                break;
            case "fa-simplybuilt":
                content = '\uf215';
                break;
            case "fa-sistrix":
                content = '\uf3ee';
                break;
            case "fa-sitemap":
                content = '\uf0e8';
                break;
            case "fa-sith":
                content = '\uf512';
                break;
            case "fa-skating":
                content = '\uf7c5';
                break;
            case "fa-sketch":
                content = '\uf7c6';
                break;
            case "fa-skiing":
                content = '\uf7c9';
                break;
            case "fa-skiing-nordic":
                content = '\uf7ca';
                break;
            case "fa-skull":
                content = '\uf54c';
                break;
            case "fa-skull-crossbones":
                content = '\uf714';
                break;
            case "fa-skyatlas":
                content = '\uf216';
                break;
            case "fa-skype":
                content = '\uf17e';
                break;
            case "fa-slack":
                content = '\uf198';
                break;
            case "fa-slack-hash":
                content = '\uf3ef';
                break;
            case "fa-slash":
                content = '\uf715';
                break;
            case "fa-sleigh":
                content = '\uf7cc';
                break;
            case "fa-sliders-h":
                content = '\uf1de';
                break;
            case "fa-slideshare":
                content = '\uf1e7';
                break;
            case "fa-smile":
                content = '\uf118';
                break;
            case "fa-smile-beam":
                content = '\uf5b8';
                break;
            case "fa-smile-wink":
                content = '\uf4da';
                break;
            case "fa-smog":
                content = '\uf75f';
                break;
            case "fa-smoking":
                content = '\uf48d';
                break;
            case "fa-smoking-ban":
                content = '\uf54d';
                break;
            case "fa-sms":
                content = '\uf7cd';
                break;
            case "fa-snapchat":
                content = '\uf2ab';
                break;
            case "fa-snapchat-ghost":
                content = '\uf2ac';
                break;
            case "fa-snapchat-square":
                content = '\uf2ad';
                break;
            case "fa-snowboarding":
                content = '\uf7ce';
                break;
            case "fa-snowflake":
                content = '\uf2dc';
                break;
            case "fa-snowman":
                content = '\uf7d0';
                break;
            case "fa-snowplow":
                content = '\uf7d2';
                break;
            case "fa-socks":
                content = '\uf696';
                break;
            case "fa-solar-panel":
                content = '\uf5ba';
                break;
            case "fa-sort":
                content = '\uf0dc';
                break;
            case "fa-sort-alpha-down":
                content = '\uf15d';
                break;
            case "fa-sort-alpha-up":
                content = '\uf15e';
                break;
            case "fa-sort-amount-down":
                content = '\uf160';
                break;
            case "fa-sort-amount-up":
                content = '\uf161';
                break;
            case "fa-sort-down":
                content = '\uf0dd';
                break;
            case "fa-sort-numeric-down":
                content = '\uf162';
                break;
            case "fa-sort-numeric-up":
                content = '\uf163';
                break;
            case "fa-sort-up":
                content = '\uf0de';
                break;
            case "fa-soundcloud":
                content = '\uf1be';
                break;
            case "fa-sourcetree":
                content = '\uf7d3';
                break;
            case "fa-spa":
                content = '\uf5bb';
                break;
            case "fa-space-shuttle":
                content = '\uf197';
                break;
            case "fa-speakap":
                content = '\uf3f3';
                break;
            case "fa-spider":
                content = '\uf717';
                break;
            case "fa-spinner":
                content = '\uf110';
                break;
            case "fa-splotch":
                content = '\uf5bc';
                break;
            case "fa-spotify":
                content = '\uf1bc';
                break;
            case "fa-spray-can":
                content = '\uf5bd';
                break;
            case "fa-square":
                content = '\uf0c8';
                break;
            case "fa-square-full":
                content = '\uf45c';
                break;
            case "fa-square-root-alt":
                content = '\uf698';
                break;
            case "fa-squarespace":
                content = '\uf5be';
                break;
            case "fa-stack-exchange":
                content = '\uf18d';
                break;
            case "fa-stack-overflow":
                content = '\uf16c';
                break;
            case "fa-stamp":
                content = '\uf5bf';
                break;
            case "fa-star":
                content = '\uf005';
                break;
            case "fa-star-and-crescent":
                content = '\uf699';
                break;
            case "fa-star-half":
                content = '\uf089';
                break;
            case "fa-star-half-alt":
                content = '\uf5c0';
                break;
            case "fa-star-of-david":
                content = '\uf69a';
                break;
            case "fa-star-of-life":
                content = '\uf621';
                break;
            case "fa-staylinked":
                content = '\uf3f5';
                break;
            case "fa-steam":
                content = '\uf1b6';
                break;
            case "fa-steam-square":
                content = '\uf1b7';
                break;
            case "fa-steam-symbol":
                content = '\uf3f6';
                break;
            case "fa-step-backward":
                content = '\uf048';
                break;
            case "fa-step-forward":
                content = '\uf051';
                break;
            case "fa-stethoscope":
                content = '\uf0f1';
                break;
            case "fa-sticker-mule":
                content = '\uf3f7';
                break;
            case "fa-sticky-note":
                content = '\uf249';
                break;
            case "fa-stop":
                content = '\uf04d';
                break;
            case "fa-stop-circle":
                content = '\uf28d';
                break;
            case "fa-stopwatch":
                content = '\uf2f2';
                break;
            case "fa-store":
                content = '\uf54e';
                break;
            case "fa-store-alt":
                content = '\uf54f';
                break;
            case "fa-strava":
                content = '\uf428';
                break;
            case "fa-stream":
                content = '\uf550';
                break;
            case "fa-street-view":
                content = '\uf21d';
                break;
            case "fa-strikethrough":
                content = '\uf0cc';
                break;
            case "fa-stripe":
                content = '\uf429';
                break;
            case "fa-stripe-s":
                content = '\uf42a';
                break;
            case "fa-stroopwafel":
                content = '\uf551';
                break;
            case "fa-studiovinari":
                content = '\uf3f8';
                break;
            case "fa-stumbleupon":
                content = '\uf1a4';
                break;
            case "fa-stumbleupon-circle":
                content = '\uf1a3';
                break;
            case "fa-subscript":
                content = '\uf12c';
                break;
            case "fa-subway":
                content = '\uf239';
                break;
            case "fa-suitcase":
                content = '\uf0f2';
                break;
            case "fa-suitcase-rolling":
                content = '\uf5c1';
                break;
            case "fa-sun":
                content = '\uf185';
                break;
            case "fa-superpowers":
                content = '\uf2dd';
                break;
            case "fa-superscript":
                content = '\uf12b';
                break;
            case "fa-supple":
                content = '\uf3f9';
                break;
            case "fa-surprise":
                content = '\uf5c2';
                break;
            case "fa-suse":
                content = '\uf7d6';
                break;
            case "fa-swatchbook":
                content = '\uf5c3';
                break;
            case "fa-swimmer":
                content = '\uf5c4';
                break;
            case "fa-swimming-pool":
                content = '\uf5c5';
                break;
            case "fa-synagogue":
                content = '\uf69b';
                break;
            case "fa-sync":
                content = '\uf021';
                break;
            case "fa-sync-alt":
                content = '\uf2f1';
                break;
            case "fa-syringe":
                content = '\uf48e';
                break;
            case "fa-table":
                content = '\uf0ce';
                break;
            case "fa-table-tennis":
                content = '\uf45d';
                break;
            case "fa-tablet":
                content = '\uf10a';
                break;
            case "fa-tablet-alt":
                content = '\uf3fa';
                break;
            case "fa-tablets":
                content = '\uf490';
                break;
            case "fa-tachometer-alt":
                content = '\uf3fd';
                break;
            case "fa-tag":
                content = '\uf02b';
                break;
            case "fa-tags":
                content = '\uf02c';
                break;
            case "fa-tape":
                content = '\uf4db';
                break;
            case "fa-tasks":
                content = '\uf0ae';
                break;
            case "fa-taxi":
                content = '\uf1ba';
                break;
            case "fa-teamspeak":
                content = '\uf4f9';
                break;
            case "fa-teeth":
                content = '\uf62e';
                break;
            case "fa-teeth-open":
                content = '\uf62f';
                break;
            case "fa-telegram":
                content = '\uf2c6';
                break;
            case "fa-telegram-plane":
                content = '\uf3fe';
                break;
            case "fa-temperature-high":
                content = '\uf769';
                break;
            case "fa-temperature-low":
                content = '\uf76b';
                break;
            case "fa-tencent-weibo":
                content = '\uf1d5';
                break;
            case "fa-tenge":
                content = '\uf7d7';
                break;
            case "fa-terminal":
                content = '\uf120';
                break;
            case "fa-text-height":
                content = '\uf034';
                break;
            case "fa-text-width":
                content = '\uf035';
                break;
            case "fa-th":
                content = '\uf00a';
                break;
            case "fa-th-large":
                content = '\uf009';
                break;
            case "fa-th-list":
                content = '\uf00b';
                break;
            case "fa-the-red-yeti":
                content = '\uf69d';
                break;
            case "fa-theater-masks":
                content = '\uf630';
                break;
            case "fa-themeco":
                content = '\uf5c6';
                break;
            case "fa-themeisle":
                content = '\uf2b2';
                break;
            case "fa-thermometer":
                content = '\uf491';
                break;
            case "fa-thermometer-empty":
                content = '\uf2cb';
                break;
            case "fa-thermometer-full":
                content = '\uf2c7';
                break;
            case "fa-thermometer-half":
                content = '\uf2c9';
                break;
            case "fa-thermometer-quarter":
                content = '\uf2ca';
                break;
            case "fa-thermometer-three-quarters":
                content = '\uf2c8';
                break;
            case "fa-think-peaks":
                content = '\uf731';
                break;
            case "fa-thumbs-down":
                content = '\uf165';
                break;
            case "fa-thumbs-up":
                content = '\uf164';
                break;
            case "fa-thumbtack":
                content = '\uf08d';
                break;
            case "fa-ticket-alt":
                content = '\uf3ff';
                break;
            case "fa-times":
                content = '\uf00d';
                break;
            case "fa-times-circle":
                content = '\uf057';
                break;
            case "fa-tint":
                content = '\uf043';
                break;
            case "fa-tint-slash":
                content = '\uf5c7';
                break;
            case "fa-tired":
                content = '\uf5c8';
                break;
            case "fa-toggle-off":
                content = '\uf204';
                break;
            case "fa-toggle-on":
                content = '\uf205';
                break;
            case "fa-toilet":
                content = '\uf7d8';
                break;
            case "fa-toilet-paper":
                content = '\uf71e';
                break;
            case "fa-toolbox":
                content = '\uf552';
                break;
            case "fa-tools":
                content = '\uf7d9';
                break;
            case "fa-tooth":
                content = '\uf5c9';
                break;
            case "fa-torah":
                content = '\uf6a0';
                break;
            case "fa-torii-gate":
                content = '\uf6a1';
                break;
            case "fa-tractor":
                content = '\uf722';
                break;
            case "fa-trade-federation":
                content = '\uf513';
                break;
            case "fa-trademark":
                content = '\uf25c';
                break;
            case "fa-traffic-light":
                content = '\uf637';
                break;
            case "fa-train":
                content = '\uf238';
                break;
            case "fa-tram":
                content = '\uf7da';
                break;
            case "fa-transgender":
                content = '\uf224';
                break;
            case "fa-transgender-alt":
                content = '\uf225';
                break;
            case "fa-trash":
                content = '\uf1f8';
                break;
            case "fa-trash-alt":
                content = '\uf2ed';
                break;
            case "fa-trash-restore":
                content = '\uf829';
                break;
            case "fa-trash-restore-alt":
                content = '\uf82a';
                break;
            case "fa-tree":
                content = '\uf1bb';
                break;
            case "fa-trello":
                content = '\uf181';
                break;
            case "fa-tripadvisor":
                content = '\uf262';
                break;
            case "fa-trophy":
                content = '\uf091';
                break;
            case "fa-truck":
                content = '\uf0d1';
                break;
            case "fa-truck-loading":
                content = '\uf4de';
                break;
            case "fa-truck-monster":
                content = '\uf63b';
                break;
            case "fa-truck-moving":
                content = '\uf4df';
                break;
            case "fa-truck-pickup":
                content = '\uf63c';
                break;
            case "fa-tshirt":
                content = '\uf553';
                break;
            case "fa-tty":
                content = '\uf1e4';
                break;
            case "fa-tumblr":
                content = '\uf173';
                break;
            case "fa-tumblr-square":
                content = '\uf174';
                break;
            case "fa-tv":
                content = '\uf26c';
                break;
            case "fa-twitch":
                content = '\uf1e8';
                break;
            case "fa-twitter":
                content = '\uf099';
                break;
            case "fa-twitter-square":
                content = '\uf081';
                break;
            case "fa-typo3":
                content = '\uf42b';
                break;
            case "fa-uber":
                content = '\uf402';
                break;
            case "fa-ubuntu":
                content = '\uf7df';
                break;
            case "fa-uikit":
                content = '\uf403';
                break;
            case "fa-umbrella":
                content = '\uf0e9';
                break;
            case "fa-umbrella-beach":
                content = '\uf5ca';
                break;
            case "fa-underline":
                content = '\uf0cd';
                break;
            case "fa-undo":
                content = '\uf0e2';
                break;
            case "fa-undo-alt":
                content = '\uf2ea';
                break;
            case "fa-uniregistry":
                content = '\uf404';
                break;
            case "fa-universal-access":
                content = '\uf29a';
                break;
            case "fa-university":
                content = '\uf19c';
                break;
            case "fa-unlink":
                content = '\uf127';
                break;
            case "fa-unlock":
                content = '\uf09c';
                break;
            case "fa-unlock-alt":
                content = '\uf13e';
                break;
            case "fa-untappd":
                content = '\uf405';
                break;
            case "fa-upload":
                content = '\uf093';
                break;
            case "fa-ups":
                content = '\uf7e0';
                break;
            case "fa-usb":
                content = '\uf287';
                break;
            case "fa-user":
                content = '\uf007';
                break;
            case "fa-user-alt":
                content = '\uf406';
                break;
            case "fa-user-alt-slash":
                content = '\uf4fa';
                break;
            case "fa-user-astronaut":
                content = '\uf4fb';
                break;
            case "fa-user-check":
                content = '\uf4fc';
                break;
            case "fa-user-circle":
                content = '\uf2bd';
                break;
            case "fa-user-clock":
                content = '\uf4fd';
                break;
            case "fa-user-cog":
                content = '\uf4fe';
                break;
            case "fa-user-edit":
                content = '\uf4ff';
                break;
            case "fa-user-friends":
                content = '\uf500';
                break;
            case "fa-user-graduate":
                content = '\uf501';
                break;
            case "fa-user-injured":
                content = '\uf728';
                break;
            case "fa-user-lock":
                content = '\uf502';
                break;
            case "fa-user-md":
                content = '\uf0f0';
                break;
            case "fa-user-minus":
                content = '\uf503';
                break;
            case "fa-user-ninja":
                content = '\uf504';
                break;
            case "fa-user-nurse":
                content = '\uf82f';
                break;
            case "fa-user-plus":
                content = '\uf234';
                break;
            case "fa-user-secret":
                content = '\uf21b';
                break;
            case "fa-user-shield":
                content = '\uf505';
                break;
            case "fa-user-slash":
                content = '\uf506';
                break;
            case "fa-user-tag":
                content = '\uf507';
                break;
            case "fa-user-tie":
                content = '\uf508';
                break;
            case "fa-user-times":
                content = '\uf235';
                break;
            case "fa-users":
                content = '\uf0c0';
                break;
            case "fa-users-cog":
                content = '\uf509';
                break;
            case "fa-usps":
                content = '\uf7e1';
                break;
            case "fa-ussunnah":
                content = '\uf407';
                break;
            case "fa-utensil-spoon":
                content = '\uf2e5';
                break;
            case "fa-utensils":
                content = '\uf2e7';
                break;
            case "fa-vaadin":
                content = '\uf408';
                break;
            case "fa-vector-square":
                content = '\uf5cb';
                break;
            case "fa-venus":
                content = '\uf221';
                break;
            case "fa-venus-double":
                content = '\uf226';
                break;
            case "fa-venus-mars":
                content = '\uf228';
                break;
            case "fa-viacoin":
                content = '\uf237';
                break;
            case "fa-viadeo":
                content = '\uf2a9';
                break;
            case "fa-viadeo-square":
                content = '\uf2aa';
                break;
            case "fa-vial":
                content = '\uf492';
                break;
            case "fa-vials":
                content = '\uf493';
                break;
            case "fa-viber":
                content = '\uf409';
                break;
            case "fa-video":
                content = '\uf03d';
                break;
            case "fa-video-slash":
                content = '\uf4e2';
                break;
            case "fa-vihara":
                content = '\uf6a7';
                break;
            case "fa-vimeo":
                content = '\uf40a';
                break;
            case "fa-vimeo-square":
                content = '\uf194';
                break;
            case "fa-vimeo-v":
                content = '\uf27d';
                break;
            case "fa-vine":
                content = '\uf1ca';
                break;
            case "fa-vk":
                content = '\uf189';
                break;
            case "fa-vnv":
                content = '\uf40b';
                break;
            case "fa-volleyball-ball":
                content = '\uf45f';
                break;
            case "fa-volume-down":
                content = '\uf027';
                break;
            case "fa-volume-mute":
                content = '\uf6a9';
                break;
            case "fa-volume-off":
                content = '\uf026';
                break;
            case "fa-volume-up":
                content = '\uf028';
                break;
            case "fa-vote-yea":
                content = '\uf772';
                break;
            case "fa-vr-cardboard":
                content = '\uf729';
                break;
            case "fa-vuejs":
                content = '\uf41f';
                break;
            case "fa-walking":
                content = '\uf554';
                break;
            case "fa-wallet":
                content = '\uf555';
                break;
            case "fa-warehouse":
                content = '\uf494';
                break;
            case "fa-water":
                content = '\uf773';
                break;
            case "fa-weebly":
                content = '\uf5cc';
                break;
            case "fa-weibo":
                content = '\uf18a';
                break;
            case "fa-weight":
                content = '\uf496';
                break;
            case "fa-weight-hanging":
                content = '\uf5cd';
                break;
            case "fa-weixin":
                content = '\uf1d7';
                break;
            case "fa-whatsapp":
                content = '\uf232';
                break;
            case "fa-whatsapp-square":
                content = '\uf40c';
                break;
            case "fa-wheelchair":
                content = '\uf193';
                break;
            case "fa-whmcs":
                content = '\uf40d';
                break;
            case "fa-wifi":
                content = '\uf1eb';
                break;
            case "fa-wikipedia-w":
                content = '\uf266';
                break;
            case "fa-wind":
                content = '\uf72e';
                break;
            case "fa-window-close":
                content = '\uf410';
                break;
            case "fa-window-maximize":
                content = '\uf2d0';
                break;
            case "fa-window-minimize":
                content = '\uf2d1';
                break;
            case "fa-window-restore":
                content = '\uf2d2';
                break;
            case "fa-windows":
                content = '\uf17a';
                break;
            case "fa-wine-bottle":
                content = '\uf72f';
                break;
            case "fa-wine-glass":
                content = '\uf4e3';
                break;
            case "fa-wine-glass-alt":
                content = '\uf5ce';
                break;
            case "fa-wix":
                content = '\uf5cf';
                break;
            case "fa-wizards-of-the-coast":
                content = '\uf730';
                break;
            case "fa-wolf-pack-battalion":
                content = '\uf514';
                break;
            case "fa-won-sign":
                content = '\uf159';
                break;
            case "fa-wordpress":
                content = '\uf19a';
                break;
            case "fa-wordpress-simple":
                content = '\uf411';
                break;
            case "fa-wpbeginner":
                content = '\uf297';
                break;
            case "fa-wpexplorer":
                content = '\uf2de';
                break;
            case "fa-wpforms":
                content = '\uf298';
                break;
            case "fa-wpressr":
                content = '\uf3e4';
                break;
            case "fa-wrench":
                content = '\uf0ad';
                break;
            case "fa-x-ray":
                content = '\uf497';
                break;
            case "fa-xbox":
                content = '\uf412';
                break;
            case "fa-xing":
                content = '\uf168';
                break;
            case "fa-xing-square":
                content = '\uf169';
                break;
            case "fa-y-combinator":
                content = '\uf23b';
                break;
            case "fa-yahoo":
                content = '\uf19e';
                break;
            case "fa-yandex":
                content = '\uf413';
                break;
            case "fa-yandex-international":
                content = '\uf414';
                break;
            case "fa-yarn":
                content = '\uf7e3';
                break;
            case "fa-yelp":
                content = '\uf1e9';
                break;
            case "fa-yen-sign":
                content = '\uf157';
                break;
            case "fa-yin-yang":
                content = '\uf6ad';
                break;
            case "fa-yoast":
                content = '\uf2b1';
                break;
            case "fa-youtube":
                content = '\uf167';
                break;
            case "fa-youtube-square":
                content = '\uf431';
                break;
            case "fa-zhihu":
                content = '\uf63f';
                break;
            }
            text = content.ToString();
        }
	}
}
