<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="TEST_MultiSelect_Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <meta charset="utf-8"/>
  <meta http-equiv="Content-Type" content="text/html"/>
  <title>Customized Input Select Menus - Demo</title>
  <meta name="author" content="Jake Rocheleau"/>
  <link rel="shortcut icon" href="http://designm.ag/favicon.ico"/>
  <link rel="icon" href="http://designm.ag/favicon.ico"/>
  <link rel="stylesheet" type="text/css" media="all" href="css/style.css"/>
  <link rel="stylesheet" type="text/css" media="all" href="css/selectize.css"/>
  <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
  <script type="text/javascript" src="js/selectize.min.js"></script>
    <script src="js/selectize.js"></script>
 
</head>
<body>
    <div class="wrapper">
			<h1><a href="https://selectize.github.io/selectize.js/" id="logo">Selectize.js</a></h1>

			<p class="feature">
				Selectize is the hybrid of a textbox and &lt;select&gt; box. It's jQuery-based and it's useful for tagging, contact lists, country selectors, and so on.
			</p>

			<p class="widgets">
				<!-- github star -->
				<iframe class="github-btn" src="https://ghbtns.com/github-btn.html?user=selectize&amp;repo=selectize.js&amp;type=watch&amp;count=true" allowtransparency="true" scrolling="0" frameborder="0" height="20px" width="100px"></iframe>

				<!-- github clone -->
				<iframe class="github-btn" src="https://ghbtns.com/github-btn.html?user=selectize&amp;repo=selectize.js&amp;type=fork&amp;count=true" allowtransparency="true" scrolling="0" frameborder="0" height="20px" width="92px"></iframe>

				<iframe src="http://platform.twitter.com/widgets/tweet_button.a9003d9964444592507bbb36b98c709b.en.html#dnt=false&amp;id=twitter-widget-0&amp;lang=en&amp;original_referer=http%3A%2F%2Fselectize.github.io%2Fselectize.js%2F&amp;related=brianreavis&amp;size=m&amp;text=Selectize.js%3A%20the%20hybrid%20of%20a%20textbox%20and%20%3Cselect%3E%20box%20%E2%80%94&amp;time=1469523493874&amp;type=share&amp;url=http%3A%2F%2Fselectize.github.io%2Fselectize.js%2F" title="Twitter Tweet Button" style="position: static; visibility: visible; width: 61px; height: 20px;" class="twitter-share-button twitter-share-button-rendered twitter-tweet-button" allowtransparency="true" scrolling="no" id="twitter-widget-0" frameborder="0"></iframe>
				<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
			</p>

			<p>
				It clocks in at around ~7kb (gzipped). The goal is to provide a solid &amp; usable user-experience with a clean and powerful API.
			</p>
			<p>
				It's a lot like <a href="http://harvesthq.github.io/chosen/">Chosen</a>, <a href="https://select2.github.io/">Select2</a>, and <a href="http://xoxco.com/projects/code/tagsinput/">Tags Input</a> but
				with a few advantages. Developed by <a href="https://twitter.com/brianreavis">@brianreavis</a> (partly at <a href="https://diy.org">DIY</a>).
				Licensed under the Apache License, Version 2.0… so do whatever you want with it!
			</p>

			<h2>Features</h2>

			<ul>
				<li><strong>Skinnable</strong> — Comes with LESS stylesheets and shims for <a href="https://github.com/brianreavis/selectize.js/blob/master/dist/less/selectize.bootstrap2.less">Bootstrap 2</a> and <a href="https://github.com/brianreavis/selectize.js/blob/master/dist/less/selectize.bootstrap3.less">Bootstrap 3</a> (+ precompiled CSS).</li>
				<li><strong>Clean API &amp; Code + Extensible</strong> — Interface &amp; make addons like a boss with the <a href="https://github.com/brianreavis/microplugin.js">plugin system</a>. Fully documented on GitHub &amp; inline.</li>
				<li><strong>Smart Ranking / Multi-Property Searching &amp; Sorting</strong> — Want to search an item's title <em>and</em> description? No problem. You can even override the scoring function used for sorting if you want to get crazy. Uses <a href="https://github.com/brianreavis/sifter.js">sifter.js</a>.</li>
				<li><strong>Caret Between Items</strong> — Order matters sometimes. Use the <kbd>left</kbd> and <kbd>right</kbd> arrow keys to move between items.</li>
				<li><strong>Select &amp; Delete multiple items at once</strong> — Hold down <kbd>option</kbd> on Mac or <kbd>ctrl</kbd> on Windows to select more than one item to delete.</li>
				<li><strong><abbr title="Right to Left">RTL</abbr> + Díåcritîçs supported</strong> — Great for international environments.</li>
				<li><strong>Item Creation</strong> — Allow users to create items on the fly (and it's async friendly; the control locks until you invoke a callback).</li>
				<li><strong>Remote Data Loading</strong> — For when you have thousands of options and want them provided by the server as the user types.</li>
			</ul>
		</div>
 <div class="inset" id="content">
			<div class="wrapper" id="tabs">
				<ul class="tabs">
					<li class="active"><a href="#demos" data-section="#demos">Demos</a></li>
					<li><a href="#demos" data-section="#plugins">Plugins</a></li>
				</ul>
			</div>
			<div class="wrapper tab-content" id="demos">

				<!-- ************** Tagging Demo ************** -->
				<section class="demo" id="demo-tagging">
					<div class="header">
						Tagging
					</div>
					<div class="sandbox">
						<label for="input-tags">Tags:</label>
						<input style="display: none;" tabindex="-1" id="input-tags" class="demo-default selectized" value="awesome,neat" type="text"><div class="selectize-control demo-default multi"><div class="selectize-input items not-full has-options has-items"><div data-value="awesome" class="item">awesome</div><div data-value="neat" class="item">neat</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none;" class="selectize-dropdown multi demo-default"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"awesome,neat"</span></div>
					</div>
					<div class="description">
						Add and remove items in any order without touching your mouse.
						Use your left/right arrow keys to move the caret (ibeam) between items. This
						example is instantiated from a <code>&lt;input type="text"&gt;</code> element (note
						that the value is represented as a string).
					</div>
					<script class="show">
					    $('#input-tags').selectize({
					        delimiter: ',',
					        persist: false,
					        create: function (input) {
					            return {
					                value: input,
					                text: input
					            }
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#input-tags'</span>).selectize({
    delimiter: <span class="string">','</span>,
    persist: <span class="literal">false</span>,
    create: <span class="keyword">function</span>(input) {
        <span class="keyword">return</span> {
            value: input,
            text: input
        }
    }
});</code></pre>
				</section>

				<!-- ************** Email Contacts Demo ************** -->
				<section class="demo" id="demo-email-contacts">
					<div class="header">
						Email Contacts
					</div>
					<div class="sandbox">
						<label for="select-to">Email:</label>
						<select style="display: none;" tabindex="-1" multiple="multiple" id="select-to" class="contacts selectized" placeholder="Pick some people..."></select><div class="selectize-control contacts multi"><div class="selectize-input items not-full has-options"><input style="width: 117px;" placeholder="Pick some people..." tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown multi contacts"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>null</span></div>
					</div>
					<div class="description">
						This demonstrates two main things: (1) custom item and option rendering, and (2) item creation on-the-fly.
						Try typing a valid and invalid email address.
					</div>
					<script class="show">
					    var REGEX_EMAIL = '([a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@' +
                                          '(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)';

					    $('#select-to').selectize({
					        persist: false,
					        maxItems: null,
					        valueField: 'email',
					        labelField: 'name',
					        searchField: ['name', 'email'],
					        options: [
                                { email: 'brian@thirdroute.com', name: 'Brian Reavis' },
                                { email: 'nikola@tesla.com', name: 'Nikola Tesla' },
                                { email: 'someone@gmail.com' }
					        ],
					        render: {
					            item: function (item, escape) {
					                return '<div>' +
                                        (item.name ? '<span class="name">' + escape(item.name) + '</span>' : '') +
                                        (item.email ? '<span class="email">' + escape(item.email) + '</span>' : '') +
                                    '</div>';
					            },
					            option: function (item, escape) {
					                var label = item.name || item.email;
					                var caption = item.name ? item.email : null;
					                return '<div>' +
                                        '<span class="label">' + escape(label) + '</span>' +
                                        (caption ? '<span class="caption">' + escape(caption) + '</span>' : '') +
                                    '</div>';
					            }
					        },
					        createFilter: function (input) {
					            var match, regex;

					            // email@address.com
					            regex = new RegExp('^' + REGEX_EMAIL + '$', 'i');
					            match = input.match(regex);
					            if (match) return !this.options.hasOwnProperty(match[0]);

					            // name <email@address.com>
					            regex = new RegExp('^([^<]*)\<' + REGEX_EMAIL + '\>$', 'i');
					            match = input.match(regex);
					            if (match) return !this.options.hasOwnProperty(match[2]);

					            return false;
					        },
					        create: function (input) {
					            if ((new RegExp('^' + REGEX_EMAIL + '$', 'i')).test(input)) {
					                return { email: input };
					            }
					            var match = input.match(new RegExp('^([^<]*)\<' + REGEX_EMAIL + '\>$', 'i'));
					            if (match) {
					                return {
					                    email: match[2],
					                    name: $.trim(match[1])
					                };
					            }
					            alert('Invalid email address.');
					            return false;
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript"><span class="keyword">var</span> REGEX_EMAIL = <span class="string">'([a-z0-9!#$%&amp;\'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;\'*+/=?^_`{|}~-]+)*@'</span> +
                  <span class="string">'(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)'</span>;

$(<span class="string">'#select-to'</span>).selectize({
    persist: <span class="literal">false</span>,
    maxItems: <span class="literal">null</span>,
    valueField: <span class="string">'email'</span>,
    labelField: <span class="string">'name'</span>,
    searchField: [<span class="string">'name'</span>, <span class="string">'email'</span>],
    options: [
        {email: <span class="string">'brian@thirdroute.com'</span>, name: <span class="string">'Brian Reavis'</span>},
        {email: <span class="string">'nikola@tesla.com'</span>, name: <span class="string">'Nikola Tesla'</span>},
        {email: <span class="string">'someone@gmail.com'</span>}
    ],
    render: {
        item: <span class="keyword">function</span>(item, escape) {
            <span class="keyword">return</span> <span class="string">'&lt;div&gt;'</span> +
                (item.name ? <span class="string">'&lt;span class="name"&gt;'</span> + escape(item.name) + <span class="string">'&lt;/span&gt;'</span> : <span class="string">''</span>) +
                (item.email ? <span class="string">'&lt;span class="email"&gt;'</span> + escape(item.email) + <span class="string">'&lt;/span&gt;'</span> : <span class="string">''</span>) +
            <span class="string">'&lt;/div&gt;'</span>;
        },
        option: <span class="keyword">function</span>(item, escape) {
            <span class="keyword">var</span> label = item.name || item.email;
            <span class="keyword">var</span> caption = item.name ? item.email : <span class="literal">null</span>;
            <span class="keyword">return</span> <span class="string">'&lt;div&gt;'</span> +
                <span class="string">'&lt;span class="label"&gt;'</span> + escape(label) + <span class="string">'&lt;/span&gt;'</span> +
                (caption ? <span class="string">'&lt;span class="caption"&gt;'</span> + escape(caption) + <span class="string">'&lt;/span&gt;'</span> : <span class="string">''</span>) +
            <span class="string">'&lt;/div&gt;'</span>;
        }
    },
    createFilter: <span class="keyword">function</span>(input) {
        <span class="keyword">var</span> match, regex;

        <span class="comment">// email@address.com</span>
        regex = <span class="keyword">new</span> RegExp(<span class="string">'^'</span> + REGEX_EMAIL + <span class="string">'$'</span>, <span class="string">'i'</span>);
        match = input.match(regex);
        <span class="keyword">if</span> (match) <span class="keyword">return</span> !<span class="keyword">this</span>.options.hasOwnProperty(match[<span class="number">0</span>]);

        <span class="comment">// name &lt;email@address.com&gt;</span>
        regex = <span class="keyword">new</span> RegExp(<span class="string">'^([^&lt;]*)\&lt;'</span> + REGEX_EMAIL + <span class="string">'\&gt;$'</span>, <span class="string">'i'</span>);
        match = input.match(regex);
        <span class="keyword">if</span> (match) <span class="keyword">return</span> !<span class="keyword">this</span>.options.hasOwnProperty(match[<span class="number">2</span>]);

        <span class="keyword">return</span> <span class="literal">false</span>;
    },
    create: <span class="keyword">function</span>(input) {
        <span class="keyword">if</span> ((<span class="keyword">new</span> RegExp(<span class="string">'^'</span> + REGEX_EMAIL + <span class="string">'$'</span>, <span class="string">'i'</span>)).test(input)) {
            <span class="keyword">return</span> {email: input};
        }
        <span class="keyword">var</span> match = input.match(<span class="keyword">new</span> RegExp(<span class="string">'^([^&lt;]*)\&lt;'</span> + REGEX_EMAIL + <span class="string">'\&gt;$'</span>, <span class="string">'i'</span>));
        <span class="keyword">if</span> (match) {
            <span class="keyword">return</span> {
                email : match[<span class="number">2</span>],
                name  : $.trim(match[<span class="number">1</span>])
            };
        }
        alert(<span class="string">'Invalid email address.'</span>);
        <span class="keyword">return</span> <span class="literal">false</span>;
    }
});</code></pre>
				</section>

				<!-- ************** Single Item Select Demo ************** -->
				<section class="demo" id="demo-single-item-select">
					<div class="header">
						Single Item Select
					</div>
					<div class="sandbox">
						<label for="select-beast">Beast:</label>
						<select style="display: none;" tabindex="-1" id="select-beast" class="demo-default selectized" placeholder="Select a person..."><option value="1" selected="selected">Chuck Testa</option></select><div class="selectize-control demo-default single"><div class="selectize-input items full has-options has-items"><div data-value="1" class="item">Chuck Testa</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single demo-default"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"1"</span></div>
					</div>
					<div class="description">
						The most vanilla of examples.
					</div>
					<script class="show">
					    $('#select-beast').selectize({
					        create: true,
					        sortField: 'text'
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-beast'</span>).selectize({
    create: <span class="literal">true</span>,
    sortField: <span class="string">'text'</span>
});</code></pre>
				</section>

				<!-- ************** Optgroup Demo ************** -->
				<section class="demo" id="demo-optgroup">
					<div class="header">
						Option Groups
					</div>
					<div class="sandbox">
						<label for="select-gear">Gear:</label>
						<select style="display: none;" tabindex="-1" id="select-gear" class="demo-default selectized" placeholder="Select gear..."><option value="" selected="selected"></option></select><div class="selectize-control demo-default single"><div class="selectize-input items not-full has-options"><input style="width: 77px;" placeholder="Select gear..." tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single demo-default"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>""</span></div>
					</div>
					<div class="description">
						Selectize supports &lt;optgroup&gt; rendering (as of v0.5.0).
					</div>
					<script class="show">
					    $('#select-gear').selectize({
					        sortField: 'text'
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-gear'</span>).selectize({
    sortField: <span class="string">'text'</span>
});</code></pre>
				</section>

				<!-- ************** Max Items Demo ************** -->
				<section class="demo" id="demo-max-items">
					<div class="header">
						Max Items
					</div>
					<div class="sandbox">
						<label for="select-state">States:</label>
						<select tabindex="-1" id="select-state" name="state[]" multiple="multiple" class="demo-default selectized" style="width: 70%; display: none;" placeholder="Select a state..."><option value="CA" selected="selected">California</option></select><div style="width: 70%;" class="selectize-control demo-default multi"><div class="selectize-input items not-full has-options has-items"><div data-value="CA" class="item">California</div><input style="width: 4px; opacity: 1; position: relative; left: 0px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 364px; top: 42px; left: 0px; visibility: visible;" class="selectize-dropdown multi demo-default"><div class="selectize-dropdown-content"><div data-value="AL" data-selectable="" class="option">Alabama</div><div data-value="AK" data-selectable="" class="option">Alaska</div><div data-value="AZ" data-selectable="" class="option">Arizona</div><div data-value="AR" data-selectable="" class="option">Arkansas</div><div data-value="CO" data-selectable="" class="option">Colorado</div><div data-value="CT" data-selectable="" class="option">Connecticut</div><div data-value="DE" data-selectable="" class="option">Delaware</div><div data-value="DC" data-selectable="" class="option">District of Columbia</div><div data-value="FL" data-selectable="" class="option">Florida</div><div data-value="GA" data-selectable="" class="option">Georgia</div><div data-value="HI" data-selectable="" class="option">Hawaii</div><div data-value="ID" data-selectable="" class="option">Idaho</div><div data-value="IL" data-selectable="" class="option">Illinois</div><div data-value="IN" data-selectable="" class="option">Indiana</div><div data-value="IA" data-selectable="" class="option">Iowa</div><div data-value="KS" data-selectable="" class="option">Kansas</div><div data-value="KY" data-selectable="" class="option">Kentucky</div><div data-value="LA" data-selectable="" class="option">Louisiana</div><div data-value="ME" data-selectable="" class="option">Maine</div><div data-value="MD" data-selectable="" class="option">Maryland</div><div data-value="MA" data-selectable="" class="option">Massachusetts</div><div data-value="MI" data-selectable="" class="option">Michigan</div><div data-value="MN" data-selectable="" class="option">Minnesota</div><div data-value="MS" data-selectable="" class="option">Mississippi</div><div data-value="MO" data-selectable="" class="option">Missouri</div><div data-value="MT" data-selectable="" class="option">Montana</div><div data-value="NE" data-selectable="" class="option">Nebraska</div><div data-value="NV" data-selectable="" class="option">Nevada</div><div data-value="NH" data-selectable="" class="option">New Hampshire</div><div data-value="NJ" data-selectable="" class="option">New Jersey</div><div data-value="NM" data-selectable="" class="option">New Mexico</div><div data-value="NY" data-selectable="" class="option">New York</div><div data-value="NC" data-selectable="" class="option">North Carolina</div><div data-value="ND" data-selectable="" class="option">North Dakota</div><div data-value="OH" data-selectable="" class="option">Ohio</div><div data-value="OK" data-selectable="" class="option">Oklahoma</div><div data-value="OR" data-selectable="" class="option">Oregon</div><div data-value="PA" data-selectable="" class="option">Pennsylvania</div><div data-value="RI" data-selectable="" class="option">Rhode Island</div><div data-value="SC" data-selectable="" class="option">South Carolina</div><div data-value="SD" data-selectable="" class="option">South Dakota</div><div data-value="TN" data-selectable="" class="option">Tennessee</div><div data-value="TX" data-selectable="" class="option">Texas</div><div data-value="UT" data-selectable="" class="option">Utah</div><div data-value="VT" data-selectable="" class="option">Vermont</div><div data-value="VA" data-selectable="" class="option">Virginia</div><div data-value="WA" data-selectable="" class="option">Washington</div><div data-value="WV" data-selectable="" class="option">West Virginia</div><div data-value="WI" data-selectable="" class="option">Wisconsin</div><div data-value="WY" data-selectable="" class="option">Wyoming</div></div></div></div><div class="value">Current Value: <span>["CA"]</span></div>
					</div>
					<div class="description">
						This example only allows 3 items. Select one more item and the control will be disabled
						until one or more are deleted.
					</div>
					<script class="show">
					    $('#select-state').selectize({
					        maxItems: 3
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-state'</span>).selectize({
    maxItems: <span class="number">3</span>
});</code></pre>
				</section>

				<!-- ************** Country Selector Demo ************** -->
				<section class="demo" id="demo-country-select">
					<div class="header">
						Country Selector
					</div>
					<div class="sandbox">
						<label for="select-country">Country:</label>
						<select style="display: none;" tabindex="-1" id="select-country" class="demo-default selectized" placeholder="Select a country..."><option value="AS" selected="selected">American Samoa</option></select><div class="selectize-control demo-default single"><div class="selectize-input items full has-options has-items"><div data-value="AS" class="item">American Samoa</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single demo-default"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"AS"</span></div>
					</div>
					<div class="description">
						A good example of (1) support for international characters (diacritics) and (2) how items are scored and sorted.
						Try typing "islands", for instance.
					</div>
					<script class="show">
					    $('#select-country').selectize();
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-country'</span>).selectize();</code></pre>
				</section>

				<!-- ************** Github Demo ************** -->
				<section class="demo" id="demo-github">
					<div class="header">
						Remote Source — Github
					</div>
					<div class="sandbox">
						<label for="select-repo">Repository:</label>
						<select style="display: none;" tabindex="-1" id="select-repo" class="repositories selectized" placeholder="Pick a repository..."><option value="https://github.com/brianreavis/selectize.js" selected="selected">selectize.js</option></select><div class="selectize-control repositories single"><div class="selectize-input items full has-options has-items"><div data-value="https://github.com/brianreavis/selectize.js" class="item">selectize.js</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single repositories"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"https://github.com/brianreavis/selectize.js"</span></div>
					</div>
					<div class="description">
						This demo shows how to integrate third-party data from the GitHub API.
					</div>
					<script class="show">
					    $('#select-repo').selectize({
					        valueField: 'url',
					        labelField: 'name',
					        searchField: 'name',
					        create: false,
					        render: {
					            option: function (item, escape) {
					                return '<div>' +
                                        '<span class="title">' +
                                            '<span class="name"><i class="icon ' + (item.fork ? 'fork' : 'source') + '"></i>' + escape(item.name) + '</span>' +
                                            '<span class="by">' + escape(item.username) + '</span>' +
                                        '</span>' +
                                        '<span class="description">' + escape(item.description) + '</span>' +
                                        '<ul class="meta">' +
                                            (item.language ? '<li class="language">' + escape(item.language) + '</li>' : '') +
                                            '<li class="watchers"><span>' + escape(item.watchers) + '</span> watchers</li>' +
                                            '<li class="forks"><span>' + escape(item.forks) + '</span> forks</li>' +
                                        '</ul>' +
                                    '</div>';
					            }
					        },
					        score: function (search) {
					            var score = this.getScoreFunction(search);
					            return function (item) {
					                return score(item) * (1 + Math.min(item.watchers / 100, 1));
					            };
					        },
					        load: function (query, callback) {
					            if (!query.length) return callback();
					            $.ajax({
					                url: 'https://api.github.com/legacy/repos/search/' + encodeURIComponent(query),
					                type: 'GET',
					                error: function () {
					                    callback();
					                },
					                success: function (res) {
					                    callback(res.repositories.slice(0, 10));
					                }
					            });
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-repo'</span>).selectize({
    valueField: <span class="string">'url'</span>,
    labelField: <span class="string">'name'</span>,
    searchField: <span class="string">'name'</span>,
    create: <span class="literal">false</span>,
    render: {
        option: <span class="keyword">function</span>(item, escape) {
            <span class="keyword">return</span> <span class="string">'&lt;div&gt;'</span> +
                <span class="string">'&lt;span class="title"&gt;'</span> +
                    <span class="string">'&lt;span class="name"&gt;&lt;i class="icon '</span> + (item.fork ? <span class="string">'fork'</span> : <span class="string">'source'</span>) + <span class="string">'"&gt;&lt;/i&gt;'</span> + escape(item.name) + <span class="string">'&lt;/span&gt;'</span> +
                    <span class="string">'&lt;span class="by"&gt;'</span> + escape(item.username) + <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;span class="description"&gt;'</span> + escape(item.description) + <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;ul class="meta"&gt;'</span> +
                    (item.language ? <span class="string">'&lt;li class="language"&gt;'</span> + escape(item.language) + <span class="string">'&lt;/li&gt;'</span> : <span class="string">''</span>) +
                    <span class="string">'&lt;li class="watchers"&gt;&lt;span&gt;'</span> + escape(item.watchers) + <span class="string">'&lt;/span&gt; watchers&lt;/li&gt;'</span> +
                    <span class="string">'&lt;li class="forks"&gt;&lt;span&gt;'</span> + escape(item.forks) + <span class="string">'&lt;/span&gt; forks&lt;/li&gt;'</span> +
                <span class="string">'&lt;/ul&gt;'</span> +
            <span class="string">'&lt;/div&gt;'</span>;
        }
    },
    score: <span class="keyword">function</span>(search) {
        <span class="keyword">var</span> score = <span class="keyword">this</span>.getScoreFunction(search);
        <span class="keyword">return</span> <span class="keyword">function</span>(item) {
            <span class="keyword">return</span> score(item) * (<span class="number">1</span> + Math.min(item.watchers / <span class="number">100</span>, <span class="number">1</span>));
        };
    },
    load: <span class="keyword">function</span>(query, callback) {
        <span class="keyword">if</span> (!query.length) <span class="keyword">return</span> callback();
        $.ajax({
            url: <span class="string">'https://api.github.com/legacy/repos/search/'</span> + encodeURIComponent(query),
            type: <span class="string">'GET'</span>,
            error: <span class="keyword">function</span>() {
                callback();
            },
            success: <span class="keyword">function</span>(res) {
                callback(res.repositories.slice(<span class="number">0</span>, <span class="number">10</span>));
            }
        });
    }
});</code></pre>
				</section>

				<!-- ************** Rotten Tomatoes Demo ************** -->
				<section class="demo" id="demo-rotten-tomatoes">
					<div class="header">
						Remote Source — Rotten Tomatoes
					</div>
					<div class="sandbox">
						<label for="select-movie">Movie:</label>
						<select style="display: none;" tabindex="-1" id="select-movie" class="movies selectized" placeholder="Find a movie..."><option value="" selected="selected"></option></select><div class="selectize-control movies single"><div class="selectize-input items not-full"><input style="width: 89px;" placeholder="Find a movie..." tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single movies"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>""</span></div>
					</div>
					<div class="description">
						This demo shows how to integrate third-party data from the Rotten Tomatoes API. Try searching for "Iron Man".
						<strong>Note:</strong> if this doesn't work, it's because the API limit has been reached... try again later :)
					</div>
					<script class="show">
					    $('#select-movie').selectize({
					        valueField: 'title',
					        labelField: 'title',
					        searchField: 'title',
					        options: [],
					        create: false,
					        render: {
					            option: function (item, escape) {
					                var actors = [];
					                for (var i = 0, n = item.abridged_cast.length; i < n; i++) {
					                    actors.push('<span>' + escape(item.abridged_cast[i].name) + '</span>');
					                }

					                return '<div>' +
                                        '<img src="' + escape(item.posters.thumbnail) + '" alt="">' +
                                        '<span class="title">' +
                                            '<span class="name">' + escape(item.title) + '</span>' +
                                        '</span>' +
                                        '<span class="description">' + escape(item.synopsis || 'No synopsis available at this time.') + '</span>' +
                                        '<span class="actors">' + (actors.length ? 'Starring ' + actors.join(', ') : 'Actors unavailable') + '</span>' +
                                    '</div>';
					            }
					        },
					        load: function (query, callback) {
					            if (!query.length) return callback();
					            $.ajax({
					                url: 'http://api.rottentomatoes.com/api/public/v1.0/movies.json',
					                type: 'GET',
					                dataType: 'jsonp',
					                data: {
					                    q: query,
					                    page_limit: 10,
					                    apikey: 'w82gs68n8m2gur98m6du5ugc'
					                },
					                error: function () {
					                    callback();
					                },
					                success: function (res) {
					                    callback(res.movies);
					                }
					            });
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#select-movie'</span>).selectize({
    valueField: <span class="string">'title'</span>,
    labelField: <span class="string">'title'</span>,
    searchField: <span class="string">'title'</span>,
    options: [],
    create: <span class="literal">false</span>,
    render: {
        option: <span class="keyword">function</span>(item, escape) {
            <span class="keyword">var</span> actors = [];
            <span class="keyword">for</span> (<span class="keyword">var</span> i = <span class="number">0</span>, n = item.abridged_cast.length; i &lt; n; i++) {
                actors.push(<span class="string">'&lt;span&gt;'</span> + escape(item.abridged_cast[i].name) + <span class="string">'&lt;/span&gt;'</span>);
            }

            <span class="keyword">return</span> <span class="string">'&lt;div&gt;'</span> +
                <span class="string">'&lt;img src="'</span> + escape(item.posters.thumbnail) + <span class="string">'" alt=""&gt;'</span> +
                <span class="string">'&lt;span class="title"&gt;'</span> +
                    <span class="string">'&lt;span class="name"&gt;'</span> + escape(item.title) + <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;span class="description"&gt;'</span> + escape(item.synopsis || <span class="string">'No synopsis available at this time.'</span>) + <span class="string">'&lt;/span&gt;'</span> +
                <span class="string">'&lt;span class="actors"&gt;'</span> + (actors.length ? <span class="string">'Starring '</span> + actors.join(<span class="string">', '</span>) : <span class="string">'Actors unavailable'</span>) + <span class="string">'&lt;/span&gt;'</span> +
            <span class="string">'&lt;/div&gt;'</span>;
        }
    },
    load: <span class="keyword">function</span>(query, callback) {
        <span class="keyword">if</span> (!query.length) <span class="keyword">return</span> callback();
        $.ajax({
            url: <span class="string">'http://api.rottentomatoes.com/api/public/v1.0/movies.json'</span>,
            type: <span class="string">'GET'</span>,
            dataType: <span class="string">'jsonp'</span>,
            data: {
                q: query,
                page_limit: <span class="number">10</span>,
                apikey: <span class="string">'w82gs68n8m2gur98m6du5ugc'</span>
            },
            error: <span class="keyword">function</span>() {
                callback();
            },
            success: <span class="keyword">function</span>(res) {
                callback(res.movies);
            }
        });
    }
});</code></pre>
				</section>

				<!-- ************** Cities Demo ************** -->
				<section class="demo" id="demo-cities">
					<div class="header">
						City / State Selection
					</div>
					<div class="sandbox">
						<label for="select-cities-state">State:</label>
						<select class="selectized" style="display: none;" tabindex="-1" id="select-cities-state" placeholder="Pick a state..."><option value="AL" selected="selected">Alabama</option></select><div class="selectize-control single"><div class="selectize-input items full has-options has-items"><div data-value="AL" class="item">Alabama</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"AL"</span></div>
						<label for="select-cities-city" style="margin-top:20px">City:</label>
						<select class="selectized" style="display: none;" tabindex="-1" disabled="" id="select-cities-city" placeholder="Pick a city..."><option value="" selected="selected"></option></select><div class="selectize-control single"><div class="selectize-input items not-full disabled locked"><input disabled="" style="width: 71px;" placeholder="Pick a city..." tabindex="-1" autocomplete="off" type="text"></div><div style="display: none; width: 520px; top: 42px; left: 0px;" class="selectize-dropdown single"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>""</span></div>
					</div>
					<div class="description">
						A demonstration showing how to use the API to cascade controls for a classic state / city selector.
						<strong>Note:</strong> The API for fetching cities is a little spotty, so if it fails to list cities, that's what's going on (try another state).
					</div>
					<script class="show">
					    var xhr;
					    var select_state, $select_state;
					    var select_city, $select_city;

					    $select_state = $('#select-cities-state').selectize({
					        onChange: function (value) {
					            if (!value.length) return;
					            select_city.disable();
					            select_city.clearOptions();
					            select_city.load(function (callback) {
					                xhr && xhr.abort();
					                xhr = $.ajax({
					                    url: 'https://jsonp.afeld.me/?url=http://api.sba.gov/geodata/primary_city_links_for_state_of/' + value + '.json',
					                    success: function (results) {
					                        select_city.enable();
					                        callback(results);
					                    },
					                    error: function () {
					                        callback();
					                    }
					                })
					            });
					        }
					    });

					    $select_city = $('#select-cities-city').selectize({
					        valueField: 'name',
					        labelField: 'name',
					        searchField: ['name']
					    });

					    select_city = $select_city[0].selectize;
					    select_state = $select_state[0].selectize;

					    select_city.disable();
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript"><span class="keyword">var</span> xhr;
<span class="keyword">var</span> select_state, $select_state;
<span class="keyword">var</span> select_city, $select_city;

$select_state = $(<span class="string">'#select-cities-state'</span>).selectize({
    onChange: <span class="keyword">function</span>(value) {
        <span class="keyword">if</span> (!value.length) <span class="keyword">return</span>;
        select_city.disable();
        select_city.clearOptions();
        select_city.load(<span class="keyword">function</span>(callback) {
            xhr &amp;&amp; xhr.abort();
            xhr = $.ajax({
                url: <span class="string">'https://jsonp.afeld.me/?url=http://api.sba.gov/geodata/primary_city_links_for_state_of/'</span> + value + <span class="string">'.json'</span>,
                success: <span class="keyword">function</span>(results) {
                    select_city.enable();
                    callback(results);
                },
                error: <span class="keyword">function</span>() {
                    callback();
                }
            })
        });
    }
});

$select_city = $(<span class="string">'#select-cities-city'</span>).selectize({
    valueField: <span class="string">'name'</span>,
    labelField: <span class="string">'name'</span>,
    searchField: [<span class="string">'name'</span>]
});

select_city  = $select_city[<span class="number">0</span>].selectize;
select_state = $select_state[<span class="number">0</span>].selectize;

select_city.disable();</code></pre>
				</section>

			</div>
			<div class="wrapper tab-content" id="plugins" style="display:none">

				<!-- ************** "restore_on_backspace" Plugin Demo ************** -->
				<section class="demo plugin">
					<div class="header">
						"restore_on_backspace"
					</div>
					<div class="sandbox">
						<label for="input-tags2">Tags:</label>
						<input style="display: none;" tabindex="-1" id="input-tags2" class="demo-default selectized" value="web development,design" type="text"><div class="selectize-control demo-default multi plugin-restore_on_backspace"><div class="selectize-input items not-full has-options has-items"><div data-value="web development" class="item">web development</div><div data-value="design" class="item">design</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none;" class="selectize-dropdown multi demo-default plugin-restore_on_backspace"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"web development,design"</span></div>
					</div>
					<div class="description">
						Press the [backspace] key and go back to editing the item without it being fully removed.
					</div>
					<script class="show">
					    $('#input-tags2').selectize({
					        plugins: ['restore_on_backspace'],
					        delimiter: ',',
					        persist: false,
					        create: function (input) {
					            return {
					                value: input,
					                text: input
					            }
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#input-tags2'</span>).selectize({
    plugins: [<span class="string">'restore_on_backspace'</span>],
    delimiter: <span class="string">','</span>,
    persist: <span class="literal">false</span>,
    create: <span class="keyword">function</span>(input) {
        <span class="keyword">return</span> {
            value: input,
            text: input
        }
    }
});</code></pre>
				</section>


				<!-- ************** "remove_button" Plugin Demo ************** -->
				<section class="demo plugin">
					<div class="header">
						"remove_button"
					</div>
					<div class="sandbox">
						<label for="input-tags3">Tags:</label>
						<input style="display: none;" tabindex="-1" id="input-tags3" class="demo-default selectized" value="science,biology,chemistry,physics" type="text"><div class="selectize-control demo-default multi plugin-remove_button"><div class="selectize-input items not-full has-options has-items"><div data-value="science" class="item">science<a href="javascript:void(0)" class="remove" tabindex="-1" title="Remove">×</a></div><div data-value="biology" class="item">biology<a href="javascript:void(0)" class="remove" tabindex="-1" title="Remove">×</a></div><div data-value="chemistry" class="item">chemistry<a href="javascript:void(0)" class="remove" tabindex="-1" title="Remove">×</a></div><div data-value="physics" class="item">physics<a href="javascript:void(0)" class="remove" tabindex="-1" title="Remove">×</a></div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none;" class="selectize-dropdown multi demo-default plugin-remove_button"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"science,biology,chemistry,physics"</span></div>
					</div>
					<div class="description">
						This plugin adds classic a classic remove button to each item for behavior that mimics Select2 and Chosen.
					</div>
					<script class="show">
					    $('#input-tags3').selectize({
					        plugins: ['remove_button'],
					        delimiter: ',',
					        persist: false,
					        create: function (input) {
					            return {
					                value: input,
					                text: input
					            }
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#input-tags3'</span>).selectize({
    plugins: [<span class="string">'remove_button'</span>],
    delimiter: <span class="string">','</span>,
    persist: <span class="literal">false</span>,
    create: <span class="keyword">function</span>(input) {
        <span class="keyword">return</span> {
            value: input,
            text: input
        }
    }
});</code></pre>
				</section>


				<!-- ************** "drag_drop" Plugin Demo ************** -->
				<section class="demo plugin">
					<div class="header">
						"drag_drop"
					</div>
					<div class="sandbox">
						<label for="input-draggable">Tags:</label>
						<input style="display: none;" tabindex="-1" id="input-draggable" class="demo-default selectized" value="drag,these,items,around,with,your,mouse" type="text"><div class="selectize-control demo-default multi plugin-drag_drop"><div class="selectize-input items not-full has-options has-items ui-sortable"><div data-value="drag" class="item">drag</div><div data-value="these" class="item">these</div><div data-value="items" class="item">items</div><div data-value="around" class="item">around</div><div data-value="with" class="item">with</div><div data-value="your" class="item">your</div><div data-value="mouse" class="item">mouse</div><input style="width: 4px;" tabindex="" autocomplete="off" type="text"></div><div style="display: none;" class="selectize-dropdown multi demo-default plugin-drag_drop"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>"drag,these,items,around,with,your,mouse"</span></div>
					</div>
					<div class="description">
						Adds drag-and-drop support for easily rearranging selected items. Requires jQuery UI (sortable).
					</div>
					<script class="show">
					    $('#input-draggable').selectize({
					        plugins: ['drag_drop'],
					        delimiter: ',',
					        persist: false,
					        create: function (input) {
					            return {
					                value: input,
					                text: input
					            }
					        }
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">'#input-draggable'</span>).selectize({
    plugins: [<span class="string">'drag_drop'</span>],
    delimiter: <span class="string">','</span>,
    persist: <span class="literal">false</span>,
    create: <span class="keyword">function</span>(input) {
        <span class="keyword">return</span> {
            value: input,
            text: input
        }
    }
});</code></pre>
				</section>

				<!-- ************** "optgroup_columns" Plugin Demo ************** -->
				<section class="demo plugin">
					<div class="header">
						"optgroup_columns"
					</div>
					<div class="sandbox">
						<label for="select-car">Car:</label>
						<select class="selectized" style="display: none;" tabindex="-1" id="select-car" placeholder="Select a car..."><option value="" selected="selected"></option></select><div class="selectize-control single plugin-optgroup_columns"><div class="selectize-input items not-full has-options"><input style="width: 79px;" placeholder="Select a car..." tabindex="" autocomplete="off" type="text"></div><div style="display: none; width: 100px; top: 2817px; left: 0px;" class="selectize-dropdown single plugin-optgroup_columns"><div class="selectize-dropdown-content"></div></div></div><div class="value">Current Value: <span>""</span></div>
					</div>
					<div class="description">
						A plugin by <a href="https://github.com/sjhewitt" target="_blank">Simon Hewitt</a> that
						renders optgroups horizontally with convenient left/right keyboard navigation.
					</div>
					<script class="show">
					    $("#select-car").selectize({
					        options: [
                                { id: 'avenger', make: 'dodge', model: 'Avenger' },
                                { id: 'caliber', make: 'dodge', model: 'Caliber' },
                                { id: 'caravan-grand-passenger', make: 'dodge', model: 'Caravan Grand Passenger' },
                                { id: 'challenger', make: 'dodge', model: 'Challenger' },
                                { id: 'ram-1500', make: 'dodge', model: 'Ram 1500' },
                                { id: 'viper', make: 'dodge', model: 'Viper' },
                                { id: 'a3', make: 'audi', model: 'A3' },
                                { id: 'a6', make: 'audi', model: 'A6' },
                                { id: 'r8', make: 'audi', model: 'R8' },
                                { id: 'rs-4', make: 'audi', model: 'RS 4' },
                                { id: 's4', make: 'audi', model: 'S4' },
                                { id: 's8', make: 'audi', model: 'S8' },
                                { id: 'tt', make: 'audi', model: 'TT' },
                                { id: 'avalanche', make: 'chevrolet', model: 'Avalanche' },
                                { id: 'aveo', make: 'chevrolet', model: 'Aveo' },
                                { id: 'cobalt', make: 'chevrolet', model: 'Cobalt' },
                                { id: 'silverado', make: 'chevrolet', model: 'Silverado' },
                                { id: 'suburban', make: 'chevrolet', model: 'Suburban' },
                                { id: 'tahoe', make: 'chevrolet', model: 'Tahoe' },
                                { id: 'trail-blazer', make: 'chevrolet', model: 'TrailBlazer' },
					        ],
					        optgroups: [
                                { id: 'dodge', name: 'Dodge' },
                                { id: 'audi', name: 'Audi' },
                                { id: 'chevrolet', name: 'Chevrolet' }
					        ],
					        labelField: 'model',
					        valueField: 'id',
					        optgroupField: 'make',
					        optgroupLabelField: 'name',
					        optgroupValueField: 'id',
					        optgroupOrder: ['chevrolet', 'dodge', 'audi'],
					        searchField: ['model'],
					        plugins: ['optgroup_columns']
					    });
					</script><a href="javascript:void(0)" class="toggle-code closed">Show Code</a><pre style="display: none;"><code class="javascript">$(<span class="string">"#select-car"</span>).selectize({
    options: [
        {id: <span class="string">'avenger'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Avenger'</span>},
        {id: <span class="string">'caliber'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Caliber'</span>},
        {id: <span class="string">'caravan-grand-passenger'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Caravan Grand Passenger'</span>},
        {id: <span class="string">'challenger'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Challenger'</span>},
        {id: <span class="string">'ram-1500'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Ram 1500'</span>},
        {id: <span class="string">'viper'</span>, make: <span class="string">'dodge'</span>, model: <span class="string">'Viper'</span>},
        {id: <span class="string">'a3'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'A3'</span>},
        {id: <span class="string">'a6'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'A6'</span>},
        {id: <span class="string">'r8'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'R8'</span>},
        {id: <span class="string">'rs-4'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'RS 4'</span>},
        {id: <span class="string">'s4'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'S4'</span>},
        {id: <span class="string">'s8'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'S8'</span>},
        {id: <span class="string">'tt'</span>, make: <span class="string">'audi'</span>, model: <span class="string">'TT'</span>},
        {id: <span class="string">'avalanche'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Avalanche'</span>},
        {id: <span class="string">'aveo'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Aveo'</span>},
        {id: <span class="string">'cobalt'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Cobalt'</span>},
        {id: <span class="string">'silverado'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Silverado'</span>},
        {id: <span class="string">'suburban'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Suburban'</span>},
        {id: <span class="string">'tahoe'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'Tahoe'</span>},
        {id: <span class="string">'trail-blazer'</span>, make: <span class="string">'chevrolet'</span>, model: <span class="string">'TrailBlazer'</span>},
    ],
    optgroups: [
        {id: <span class="string">'dodge'</span>, name: <span class="string">'Dodge'</span>},
        {id: <span class="string">'audi'</span>, name: <span class="string">'Audi'</span>},
        {id: <span class="string">'chevrolet'</span>, name: <span class="string">'Chevrolet'</span>}
    ],
    labelField: <span class="string">'model'</span>,
    valueField: <span class="string">'id'</span>,
    optgroupField: <span class="string">'make'</span>,
    optgroupLabelField: <span class="string">'name'</span>,
    optgroupValueField: <span class="string">'id'</span>,
    optgroupOrder: [<span class="string">'chevrolet'</span>, <span class="string">'dodge'</span>, <span class="string">'audi'</span>],
    searchField: [<span class="string">'model'</span>],
    plugins: [<span class="string">'optgroup_columns'</span>]
});</code></pre>
				</section>

			</div>
		</div>
    <div class="wrapper">
			<h2>Find out more…</h2>
			<ul id="links">
				<li><a href="https://github.com/selectize/selectize.js" target="_blank">GitHub Repository</a></li>
				<li><a href="https://github.com/selectize/selectize.js/tree/master/examples" target="_blank">Examples</a></li>
				<li><a href="https://github.com/selectize/selectize.js/blob/master/docs/usage.md" target="_blank">Usage Documentation</a></li>
				<li><a href="https://github.com/selectize/selectize.js/blob/master/docs/api.md" target="_blank">API Documentation</a></li>
				<li><a href="https://github.com/selectize/selectize.js/blob/master/docs/plugins.md" target="_blank">Plugin Documentation</a></li>
			</ul>
			<footer>Copyright © 2016 — Brian Reavis &amp; contributors.</footer>
		</div>
    <div class="wrapper">
			<h1><a href="https://selectize.github.io/selectize.js/" id="A1">Selectize.js</a></h1>

			<p class="feature">
				Selectize is the hybrid of a textbox and &lt;select&gt; box. It's jQuery-based and it's useful for tagging, contact lists, country selectors, and so on.
			</p>

			<p class="widgets">
				<!-- github star -->
				<iframe class="github-btn" src="https://ghbtns.com/github-btn.html?user=selectize&amp;repo=selectize.js&amp;type=watch&amp;count=true" allowtransparency="true" scrolling="0" frameborder="0" height="20px" width="100px"></iframe>

				<!-- github clone -->
				<iframe class="github-btn" src="https://ghbtns.com/github-btn.html?user=selectize&amp;repo=selectize.js&amp;type=fork&amp;count=true" allowtransparency="true" scrolling="0" frameborder="0" height="20px" width="92px"></iframe>

				<iframe src="http://platform.twitter.com/widgets/tweet_button.a9003d9964444592507bbb36b98c709b.en.html#dnt=false&amp;id=twitter-widget-0&amp;lang=en&amp;original_referer=http%3A%2F%2Fselectize.github.io%2Fselectize.js%2F&amp;related=brianreavis&amp;size=m&amp;text=Selectize.js%3A%20the%20hybrid%20of%20a%20textbox%20and%20%3Cselect%3E%20box%20%E2%80%94&amp;time=1469523493874&amp;type=share&amp;url=http%3A%2F%2Fselectize.github.io%2Fselectize.js%2F" title="Twitter Tweet Button" style="position: static; visibility: visible; width: 61px; height: 20px;" class="twitter-share-button twitter-share-button-rendered twitter-tweet-button" allowtransparency="true" scrolling="no" id="Iframe1" frameborder="0"></iframe>
				<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
			</p>

			<p>
				It clocks in at around ~7kb (gzipped). The goal is to provide a solid &amp; usable user-experience with a clean and powerful API.
			</p>
			<p>
				It's a lot like <a href="http://harvesthq.github.io/chosen/">Chosen</a>, <a href="https://select2.github.io/">Select2</a>, and <a href="http://xoxco.com/projects/code/tagsinput/">Tags Input</a> but
				with a few advantages. Developed by <a href="https://twitter.com/brianreavis">@brianreavis</a> (partly at <a href="https://diy.org">DIY</a>).
				Licensed under the Apache License, Version 2.0… so do whatever you want with it!
			</p>

			<h2>Features</h2>

			<ul>
				<li><strong>Skinnable</strong> — Comes with LESS stylesheets and shims for <a href="https://github.com/brianreavis/selectize.js/blob/master/dist/less/selectize.bootstrap2.less">Bootstrap 2</a> and <a href="https://github.com/brianreavis/selectize.js/blob/master/dist/less/selectize.bootstrap3.less">Bootstrap 3</a> (+ precompiled CSS).</li>
				<li><strong>Clean API &amp; Code + Extensible</strong> — Interface &amp; make addons like a boss with the <a href="https://github.com/brianreavis/microplugin.js">plugin system</a>. Fully documented on GitHub &amp; inline.</li>
				<li><strong>Smart Ranking / Multi-Property Searching &amp; Sorting</strong> — Want to search an item's title <em>and</em> description? No problem. You can even override the scoring function used for sorting if you want to get crazy. Uses <a href="https://github.com/brianreavis/sifter.js">sifter.js</a>.</li>
				<li><strong>Caret Between Items</strong> — Order matters sometimes. Use the <kbd>left</kbd> and <kbd>right</kbd> arrow keys to move between items.</li>
				<li><strong>Select &amp; Delete multiple items at once</strong> — Hold down <kbd>option</kbd> on Mac or <kbd>ctrl</kbd> on Windows to select more than one item to delete.</li>
				<li><strong><abbr title="Right to Left">RTL</abbr> + Díåcritîçs supported</strong> — Great for international environments.</li>
				<li><strong>Item Creation</strong> — Allow users to create items on the fly (and it's async friendly; the control locks until you invoke a callback).</li>
				<li><strong>Remote Data Loading</strong> — For when you have thousands of options and want them provided by the server as the user types.</li>
			</ul>
		</div>
</body>
</html>
