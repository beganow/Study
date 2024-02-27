(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [
		{name:"КМС_4_1_HTML5 Canvas_atlas_1", frames: [[1182,548,177,97],[492,364,210,97],[973,548,207,97],[1812,284,202,242],[978,324,216,222],[260,364,230,202],[1288,0,582,282],[704,0,582,322],[492,505,244,189],[704,324,272,179],[0,364,258,184],[1812,528,120,256],[1872,0,116,279],[855,505,116,278],[1288,284,522,262],[738,505,115,290],[0,0,702,362]]}
];


(lib.AnMovieClip = function(){
	this.currentSoundStreamInMovieclip;
	this.actionFrames = [];
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(positionOrLabel);
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		var keys = this.soundStreamDuration.keys();
		for(var i = 0;i<this.soundStreamDuration.size; i++){
			var key = keys.next().value;
			key.instance.stop();
		}
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var keys = this.soundStreamDuration.keys();
			for(var i = 0; i< this.soundStreamDuration.size ; i++){
				var key = keys.next().value; 
				var value = this.soundStreamDuration.get(key);
				if((value.end) == currentFrame){
					key.instance.stop();
					if(this.currentSoundStreamInMovieclip == key) { this.currentSoundStreamInMovieclip = undefined; }
					this.soundStreamDuration.delete(key);
				}
			}
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			if(this.soundStreamDuration.size > 0){
				var keys = this.soundStreamDuration.keys();
				var maxDuration = 0;
				for(var i=0;i<this.soundStreamDuration.size;i++){
					var key = keys.next().value;
					var value = this.soundStreamDuration.get(key);
					if(value.end > maxDuration){
						maxDuration = value.end;
						this.currentSoundStreamInMovieclip = key;
					}
				}
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:



(lib.CachedBmp_17 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(0);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_13 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(1);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_15 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(2);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_10 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(3);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_9 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(4);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_8 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(5);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_12 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(6);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_14 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(7);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_7 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(8);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_5 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(9);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_6 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(10);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_4 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(11);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_2 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(12);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_3 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(13);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_16 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(14);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_1 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(15);
}).prototype = p = new cjs.Sprite();



(lib.CachedBmp_11 = function() {
	this.initialize(ss["КМС_4_1_HTML5 Canvas_atlas_1"]);
	this.gotoAndStop(16);
}).prototype = p = new cjs.Sprite();



(lib.Stop = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_17();
	this.instance.setTransform(-154.35,-254.15,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_16();
	this.instance_1.setTransform(-270.5,-290.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-270.5,-290.5,261,131);


(lib.Start = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_15();
	this.instance.setTransform(-111.8,-274.15,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_14();
	this.instance_1.setTransform(-150.5,-320.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-150.5,-320.5,291,161);


(lib.Reverse = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_13();
	this.instance.setTransform(-52.35,-214.15,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_12();
	this.instance_1.setTransform(-140.5,-260.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-140.5,-260.5,291,141);


(lib.тело = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_11();
	this.instance.setTransform(-280.5,-240.5,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-280.5,-240.5,351,181);


(lib.лапа = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.CachedBmp_1();
	this.instance.setTransform(-405.05,-218.2,0.5,0.5);

	this.instance_1 = new lib.CachedBmp_2();
	this.instance_1.setTransform(-403.65,-217.25,0.5,0.5);

	this.instance_2 = new lib.CachedBmp_3();
	this.instance_2.setTransform(-403.6,-217.2,0.5,0.5);

	this.instance_3 = new lib.CachedBmp_4();
	this.instance_3.setTransform(-397.75,-213.2,0.5,0.5);

	this.instance_4 = new lib.CachedBmp_5();
	this.instance_4.setTransform(-374.55,-197.4,0.5,0.5);

	this.instance_5 = new lib.CachedBmp_6();
	this.instance_5.setTransform(-381.75,-194.2,0.5,0.5);

	this.instance_6 = new lib.CachedBmp_7();
	this.instance_6.setTransform(-388.95,-191,0.5,0.5);

	this.instance_7 = new lib.CachedBmp_8();
	this.instance_7.setTransform(-396.1,-192.15,0.5,0.5);

	this.instance_8 = new lib.CachedBmp_9();
	this.instance_8.setTransform(-403.3,-196.75,0.5,0.5);

	this.instance_9 = new lib.CachedBmp_10();
	this.instance_9.setTransform(-410.5,-201.35,0.5,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},1).to({state:[{t:this.instance_2}]},1).to({state:[{t:this.instance_3}]},1).to({state:[{t:this.instance_4}]},1).to({state:[{t:this.instance_5}]},1).to({state:[{t:this.instance_6}]},1).to({state:[{t:this.instance_7}]},1).to({state:[{t:this.instance_8}]},1).to({state:[{t:this.instance_9}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-410.5,-218.2,172,145);


(lib.жук = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(-4.4,-7.6,0.4946,0.5492,0,0,0,-104.9,-150);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(69.9,54.55,0.4984,0.5457,0,-166.439,16.5627,-325.5,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(-23.95,44.5,0.5143,0.5307,0,-146.569,39.1437,-325.4,-140.3);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(30.35,54.85,0.5088,0.536,0,-152.5115,32.6826,-325.8,-140.2);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(74.85,-38.85,0.4946,0.5492,0,0,0,-325.8,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(34.55,-55.1,0.5033,0.5412,0,-20.9111,-25.2265,-325.7,-140.5);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(-9.25,-33.3,0.4984,0.5457,0,-13.561,-16.5627,-325.6,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6,p:{startPosition:9}},{t:this.instance_5,p:{startPosition:9}},{t:this.instance_4,p:{startPosition:9}},{t:this.instance_3,p:{startPosition:9}},{t:this.instance_2,p:{startPosition:9}},{t:this.instance_1,p:{startPosition:9}},{t:this.instance}]}).to({state:[{t:this.instance_6,p:{startPosition:0}},{t:this.instance_5,p:{startPosition:7}},{t:this.instance_4,p:{startPosition:4}},{t:this.instance_3,p:{startPosition:0}},{t:this.instance_2,p:{startPosition:7}},{t:this.instance_1,p:{startPosition:7}},{t:this.instance}]},59).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-91.2,-102.5,209.2,208.5);


(lib.Символ35 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(101.95,361.15,0.4946,0.5492,0,0,180,-105,-150);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(27.6,423.3,0.4984,0.5457,0,166.439,163.4373,-325.5,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(121.45,413.25,0.5143,0.5307,0,146.569,140.8563,-325.4,-140.3);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(67.15,423.6,0.5088,0.536,0,152.5115,147.3174,-325.8,-140.2);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(22.65,329.9,0.4946,0.5492,0,0,180,-325.8,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(62.95,313.65,0.5033,0.5412,0,20.9111,-154.7735,-325.7,-140.5);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(106.75,335.45,0.4984,0.5457,0,13.561,-163.4373,-325.6,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(12.2,279.5,176.5,178.3);


(lib.Символ34 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(768.3,330.1,0.4945,0.5491,0,-1.8694,178.131,-105,-149.5);

	this.instance_1 = new lib.лапа("synched",4);
	this.instance_1.setTransform(696.35,394.35,0.4983,0.5456,0,164.5758,161.5739,-326,-140.8);

	this.instance_2 = new lib.лапа("synched",4);
	this.instance_2.setTransform(789.6,381.5,0.5142,0.5306,0,144.6993,138.9873,-325.3,-140.8);

	this.instance_3 = new lib.лапа("synched",4);
	this.instance_3.setTransform(735.45,393.6,0.5087,0.5359,0,150.6432,145.4509,-325.7,-140.6);

	this.instance_4 = new lib.лапа("synched",4);
	this.instance_4.setTransform(688.15,301.3,0.4945,0.5491,0,-1.8694,178.131,-326.1,-139.8);

	this.instance_5 = new lib.лапа("synched",4);
	this.instance_5.setTransform(727.6,284.1,0.5032,0.5411,0,19.0368,-156.6481,-325.6,-140);

	this.instance_6 = new lib.лапа("synched",4);
	this.instance_6.setTransform(772.35,304.2,0.4983,0.5456,0,11.6848,-165.3157,-325.8,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(643.9,237.4,212.80000000000007,207.9);


(lib.Символ33 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(1224.85,356.75,0.4946,0.5492,0,0,180,-105,-150);

	this.instance_1 = new lib.лапа("synched",4);
	this.instance_1.setTransform(1150.5,418.9,0.4984,0.5457,0,166.439,163.4373,-325.5,-140.6);

	this.instance_2 = new lib.лапа("synched",4);
	this.instance_2.setTransform(1244.35,408.85,0.5143,0.5307,0,146.569,140.8563,-325.4,-140.3);

	this.instance_3 = new lib.лапа("synched",4);
	this.instance_3.setTransform(1190.05,419.2,0.5088,0.536,0,152.5115,147.3174,-325.8,-140.2);

	this.instance_4 = new lib.лапа("synched",4);
	this.instance_4.setTransform(1145.55,325.5,0.4946,0.5492,0,0,180,-325.8,-140);

	this.instance_5 = new lib.лапа("synched",4);
	this.instance_5.setTransform(1185.85,309.25,0.5033,0.5412,0,20.9111,-154.7735,-325.7,-140.5);

	this.instance_6 = new lib.лапа("synched",4);
	this.instance_6.setTransform(1229.65,331.05,0.4984,0.5457,0,13.561,-163.4373,-325.6,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(1102.4,261.8,209.19999999999982,208.59999999999997);


(lib.Символ32 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(142.65,113.35,0.2987,0.3376,0,20.9934,-159.0072,-105,-150.1);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(87.05,132.9,0.3015,0.3351,0,-172.3411,-175.8439,-324.9,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(142.25,147.5,0.3128,0.3245,0,168.0296,161.3653,-325.7,-140.5);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(109.3,141.7,0.3089,0.3283,0,173.9245,167.8635,-325.9,-140.5);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(104.85,78.25,0.2987,0.3376,0,20.9934,-159.0072,-325.4,-139.7);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(131.15,77.6,0.3049,0.3319,0,41.5727,-133.3902,-325.9,-140.7);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(151,99.65,0.3015,0.3351,0,34.3262,-142.1713,-325.7,-140.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(79.7,57.1,122.8,111.30000000000001);


(lib.Символ31 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(227.3,147.3,0.2987,0.3376,0,21.1839,-158.8154,-105.4,-150.1);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(171.55,166.65,0.3015,0.3351,0,-172.1511,-175.6549,-325.6,-140.7);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(226.55,181.5,0.3128,0.3245,0,168.2187,161.5571,-325.1,-140.7);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(193.7,175.5,0.3089,0.3283,0,174.1142,168.0517,-325.7,-140.2);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(189.45,112.1,0.2987,0.3376,0,21.1839,-158.8154,-325.8,-139.7);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(215.8,111.7,0.3049,0.3319,0,41.7646,-133.1993,-326.2,-140.2);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(235.6,133.55,0.3014,0.3351,0,34.5158,-141.982,-325.8,-140.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(163.9,90.9,123.20000000000002,111.4);


(lib.Символ30 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(718.55,265.2,0.2987,0.3376,0,-23.0082,156.9936,-104.7,-149.2);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(692.15,317.8,0.3015,0.3351,0,143.6655,140.1562,-325.4,-141.2);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(741.9,289.95,0.3128,0.3245,0,124.0181,117.3512,-325.1,-140.8);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(714.3,308.65,0.3089,0.3282,0,129.9157,123.8494,-325.9,-140.8);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(667,266.1,0.2987,0.3376,0,-23.0082,156.9936,-326,-139.7);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(685.45,247.4,0.305,0.3319,0,-2.4265,-177.4019,-325.7,-140.2);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(715.05,249.4,0.3015,0.3351,0,-9.6703,173.8315,-325.6,-140.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(654.3,216.3,124.40000000000009,120.80000000000001);


(lib.Символ29 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(817.95,252.45,0.2987,0.3376,0,157.1823,-22.8151,-104.4,-150.5);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(844.5,199.7,0.3014,0.3351,0,-36.1492,-39.6518,-325.6,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(794.65,227.45,0.3128,0.3245,0,-55.7943,-62.4538,-325.4,-140.2);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(822.4,208.85,0.3089,0.3282,0,-49.8953,-55.959,-325.9,-140.2);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(869.55,251.5,0.2987,0.3376,0,157.1823,-22.8151,-325.6,-140.1);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(850.95,270.2,0.305,0.3319,0,177.7657,2.7848,-325.1,-141.2);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(821.45,268,0.3015,0.3351,0,170.5218,-5.979,-324.6,-140.8);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(757.5,180.2,124.5,120.60000000000002);


(lib.Символ28 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(899.4,188.2,0.2987,0.3375,0,-18.779,161.2207,-104.8,-149.3);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(869.15,238.8,0.3014,0.335,0,147.8856,144.3861,-325.7,-140.7);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(920.95,214.85,0.3128,0.3244,0,128.2449,121.5802,-325.1,-141.1);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(891.85,231.3,0.3088,0.3282,0,134.1373,128.0776,-325.6,-140.7);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(847.85,185.35,0.2987,0.3375,0,-18.779,161.2207,-325.9,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(867.65,168.15,0.3049,0.3319,0,1.7862,-173.1776,-325.8,-140.3);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(897.05,172.2,0.3015,0.3351,0,-5.4486,178.0596,-325.8,-140.4);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(836.6,142.2,122.19999999999993,116.60000000000002);


(lib.Символ27 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(1130.65,455.15,0.2474,0.303,0,0,0,-104.9,-149.2);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(1167.75,489.35,0.2515,0.2996,0,-167.6735,18.1524,-324.9,-140.5);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(1120.85,483.85,0.2681,0.2847,0,-149.101,41.9106,-325.1,-140.8);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(1148.05,489.6,0.2623,0.29,0,-154.7522,35.2801,-325.4,-140.8);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(1170.3,437.85,0.2474,0.303,0,0,0,-325.1,-139.3);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(1150.15,428.9,0.2566,0.2951,0,-19.0991,-27.4473,-325.8,-140.5);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(1128.2,440.9,0.2515,0.2996,0,-12.3265,-18.1524,-324.9,-140.1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(1087.2,410,88.09999999999991,98.39999999999998);


(lib.Символ26 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(67.05,489.95,0.2474,0.303,0,0,0,-104.1,-149.3);

	this.instance_1 = new lib.лапа("synched",8);
	this.instance_1.setTransform(104.2,524.15,0.2515,0.2996,0,-167.6735,18.1524,-324.9,-140.3);

	this.instance_2 = new lib.лапа("synched",8);
	this.instance_2.setTransform(57.25,518.6,0.2681,0.2847,0,-149.101,41.9106,-324.9,-139.8);

	this.instance_3 = new lib.лапа("synched",8);
	this.instance_3.setTransform(84.45,524.4,0.2623,0.29,0,-154.7522,35.2801,-325.4,-140.7);

	this.instance_4 = new lib.лапа("synched",8);
	this.instance_4.setTransform(106.7,472.65,0.2474,0.303,0,0,0,-325.1,-139.6);

	this.instance_5 = new lib.лапа("synched",8);
	this.instance_5.setTransform(86.5,463.7,0.2566,0.2951,0,-19.0991,-27.4473,-325.1,-140.2);

	this.instance_6 = new lib.лапа("synched",8);
	this.instance_6.setTransform(64.6,475.7,0.2515,0.2996,0,-12.3265,-18.1524,-324.9,-140.1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(23.4,444.4,91.4,99.30000000000007);


(lib.Символ25 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(128.55,554.75,0.3725,0.3033,0,50.5546,-129.4489,-104.9,-149.8);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(66.55,533.25,0.3683,0.3084,0,-147.6506,-141.7498,-325.1,-141.3);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(115.75,584.35,0.3499,0.3291,0,-171.4526,-160.2848,-325.6,-140.5);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(85.35,556.5,0.3565,0.322,0,-164.808,-154.6394,-325.6,-140.8);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(103.9,497.65,0.3725,0.3033,0,50.5546,-129.4489,-325.3,-139.2);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(130.2,515.45,0.3628,0.3148,0,78.0784,-110.3922,-325.8,-140.7);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(142,548.65,0.3683,0.3084,0,68.7677,-117.1478,-326.2,-140.7);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(52.1,481.1,139.20000000000002,141.5);


(lib.Символ24 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(629.5,188.6,0.4946,0.5492,90,0,0,-105,-150);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(567.35,262.95,0.4984,0.5457,0,-76.439,106.5627,-325.5,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(577.4,169.1,0.5143,0.5307,0,-56.569,129.1437,-325.4,-140.3);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(567.05,223.4,0.5088,0.536,0,-62.5115,122.6826,-325.8,-140.2);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(660.75,267.9,0.4946,0.5492,90,0,0,-325.8,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(677,227.6,0.5033,0.5412,0,69.0889,64.7735,-325.7,-140.5);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(655.2,183.8,0.4984,0.5457,0,76.439,73.4373,-325.6,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(532.9,101.8,178.30000000000007,176.5);


(lib.Символ23 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(804.4,26.1,0.4946,0.5492,180,0,0,-105,-150);

	this.instance_1 = new lib.лапа("synched",8);
	this.instance_1.setTransform(730.05,-36.05,0.4984,0.5457,0,13.561,-163.4373,-325.5,-140.6);

	this.instance_2 = new lib.лапа("synched",8);
	this.instance_2.setTransform(823.9,-26,0.5143,0.5307,0,33.431,-140.8563,-325.4,-140.3);

	this.instance_3 = new lib.лапа("synched",8);
	this.instance_3.setTransform(769.6,-36.35,0.5088,0.536,0,27.4885,-147.3174,-325.8,-140.2);

	this.instance_4 = new lib.лапа("synched",8);
	this.instance_4.setTransform(725.1,57.35,0.4946,0.5492,180,0,0,-325.8,-140);

	this.instance_5 = new lib.лапа("synched",8);
	this.instance_5.setTransform(765.4,73.6,0.5033,0.5412,0,159.0889,154.7735,-325.7,-140.5);

	this.instance_6 = new lib.лапа("synched",8);
	this.instance_6.setTransform(809.2,51.8,0.4984,0.5457,0,166.439,163.4373,-325.6,-140.3);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(708.6,-71.6,182.60000000000002,180.1);


(lib.Символ22 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(518.4,564.85,0.2192,0.2971,180,0,0,-105.2,-150.3);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(485.45,531.25,0.2253,0.2925,0,11.171,-160.064,-325.9,-140.6);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(527.1,536.65,0.2492,0.2724,0,28.4027,-135.1935,-325.8,-140.5);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(503,531.05,0.241,0.2796,0,23.084,-141.944,-326.2,-140.4);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(483.25,581.75,0.2192,0.2971,180,0,0,-326.2,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(501.1,590.55,0.2328,0.2866,0,162.6225,150.114,-325.6,-141.2);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(520.55,578.75,0.2253,0.2925,0,168.829,160.064,-325.6,-141);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(478.6,512.5,78.19999999999993,96.39999999999998);


(lib.Символ21 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой_1
	this.instance = new lib.тело("synched",0);
	this.instance.setTransform(1190.15,705.5,0.3373,0.3017,59.9974,0,0,-104.2,-149.6);

	this.instance_1 = new lib.лапа("synched",9);
	this.instance_1.setTransform(1185.9,766.4,0.3351,0.3042,0,-103.3343,73.469,-324.8,-140.8);

	this.instance_2 = new lib.лапа("synched",9);
	this.instance_2.setTransform(1158.6,708.15,0.3253,0.3146,0,-80.6743,93.2401,-324.8,-140.3);

	this.instance_3 = new lib.лапа("synched",9);
	this.instance_3.setTransform(1172.25,743.15,0.3288,0.311,0,-87.1509,87.3345,-325,-140.3);

	this.instance_4 = new lib.лапа("synched",9);
	this.instance_4.setTransform(1232.05,743.6,0.3373,0.3017,59.9974,0,0,-325.4,-140);

	this.instance_5 = new lib.лапа("synched",9);
	this.instance_5.setTransform(1226,715.35,0.3321,0.3074,0,34.6201,39.212,-325.2,-140.5);

	this.instance_6 = new lib.лапа("synched",9);
	this.instance_6.setTransform(1200.7,695.5,0.335,0.3042,0,43.3314,46.5262,-324.9,-140.1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(1136.8,640.3,114,135.30000000000007);


// stage content:
(lib.КМС41_HTML5Canvas = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	this.actionFrames = [0,5,35];
	// timeline functions:
	this.frame_0 = function() {
		this.clearAllSoundStreams();
		 
		this.stop();
		this.start.addEventListener("click", f1.bind(this));
		function f1(args)
		{this.play();}
		this.stoop.addEventListener("click", f2.bind(this));
		function f2(args)
		{this.stop();}
		this.back.addEventListener("click", f3.bind(this));
		function f3(args)
		{this.gotoAndStop(1);}
		playSound("zhuzhzhaniezhuka");
	}
	this.frame_5 = function() {
		playSound("audio_20230226_165556onlineaudioconvertercom");
	}
	this.frame_35 = function() {
		playSound("ВидеобезназваниясделановClipchamp1onlineaudioconvertercom");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(5).call(this.frame_5).wait(30).call(this.frame_35).wait(25));

	// Слой_3
	this.stoop = new lib.Stop();
	this.stoop.name = "stoop";
	this.stoop.setTransform(636.85,789.2,0.6846,0.6138);
	new cjs.ButtonHelper(this.stoop, 0, 1, 1);

	this.back = new lib.Reverse();
	this.back.name = "back";
	this.back.setTransform(727.25,757.7,0.5518,0.5557);
	new cjs.ButtonHelper(this.back, 0, 1, 1);

	this.start = new lib.Start();
	this.start.name = "start";
	this.start.setTransform(372.55,805.55,0.5103,0.6481);
	new cjs.ButtonHelper(this.start, 0, 1, 1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.start},{t:this.back},{t:this.stoop}]}).wait(60));

	// Слой_16
	this.instance = new lib.Символ21("synched",0);
	this.instance.setTransform(1193.85,707.85,0.6822,0.5495,59.997,0,0,1.4,-11.2);

	this.instance_1 = new lib.жук();
	this.instance_1.setTransform(918.8,699.95,0.6822,0.5495,-90.0032,0,0,-3,-0.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance}]}).to({state:[{t:this.instance_1}]},59).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance).to({_off:true,regX:-3,regY:-0.2,rotation:-90.0032,guide:{path:[1194.7,707.6,1182.3,678.8,1170,650,1145,610,1120,570,1070,555,1020,540,975,540,930,540,925,545,920,550,920,625,920,700], orient:'fixed'},mode:"independent"},59).wait(1));

	// Слой_14
	this.instance_2 = new lib.Символ22("synched",0);
	this.instance_2.setTransform(517.7,560.7,0.4434,0.5411,180,0,0,-2.8,0.1);

	this.instance_3 = new lib.жук();
	this.instance_3.setTransform(865.7,710,0.4434,0.5411,-90,0,0,-3.1,-0.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_2}]}).to({state:[{t:this.instance_3}]},59).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_2).to({_off:true,regX:-3.1,regY:-0.2,rotation:270,guide:{path:[517.7,560,643.9,560,770,560,773.5,555,770,550,774.2,553.8,780,550,800,550,820,550,820,555,820,560,835,580,850,600,857.9,655,865.7,710]},mode:"independent"},59).wait(1));

	// Слой_12
	this.instance_4 = new lib.Символ24("synched",0);
	this.instance_4.setTransform(622,189.95,1,1,90,0,0,-3.1,-0.1);

	this.instance_5 = new lib.Символ23("synched",0);
	this.instance_5.setTransform(786.05,16.8,1,1,180,0,0,13.9,1.7);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_4}]}).to({state:[{t:this.instance_5}]},59).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_4).to({_off:true,regX:13.9,regY:1.7,rotation:180,x:786.05,y:16.8},59).wait(1));

	// Слой_10
	this.instance_6 = new lib.Символ25("synched",0);
	this.instance_6.setTransform(121.7,551.85,0.7534,0.5524,0,50.5531,-129.4469,4.3,-1.3);

	this.instance_7 = new lib.жук();
	this.instance_7.setTransform(260,740,0.7534,0.5524,0,50.5531,-129.4469,-3.1,-0.1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6}]}).to({state:[{t:this.instance_7}]},59).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_6).to({_off:true,regX:-3.1,regY:-0.1,guide:{path:[119.9,553.3,184.9,641.6,250,730,255,735,260,740], orient:'fixed'},mode:"independent"},59).wait(1));

	// Слой_8
	this.instance_8 = new lib.Символ27("synched",0);
	this.instance_8.setTransform(1131.25,459.2,0.5003,0.5518,0,0,0,-3.2,-0.2);

	this.instance_9 = new lib.Символ26("synched",0);
	this.instance_9.setTransform(76,494.85,0.5003,0.5518,0,0,0,13.5,1.4);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_8}]}).to({state:[{t:this.instance_9}]},59).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_8).to({_off:true,regX:13.5,regY:1.4,guide:{path:[1131.2,460,875.6,460,620,460,615,455,610,450,606,454,610,460,465.1,460,320.1,460,265.1,465,210.1,470,185.1,480,160.1,490,135.1,490,110.1,490,93.1,492.4,76.1,494.9], orient:'fixed'}},59).wait(1));

	// Слой_4
	this.instance_10 = new lib.Символ32("synched",0);
	this.instance_10.setTransform(141.1,112.75,0.6042,0.6148,0,20.9944,-159.0058,-1.7,-7.6);

	this.instance_11 = new lib.Символ31("synched",0);
	this.instance_11.setTransform(225.55,146.6,0.6042,0.6148,0,21.1845,-158.8156,-1.4,-7.6);
	this.instance_11._off = true;

	this.instance_12 = new lib.Символ30("synched",0);
	this.instance_12.setTransform(716.45,276.65,0.6042,0.6148,0,-23.0078,156.9928,6.2,8.4);
	this.instance_12._off = true;

	this.instance_13 = new lib.Символ29("synched",0);
	this.instance_13.setTransform(819.8,240.5,0.6041,0.6148,0,157.1823,-22.8151,6,9.1);
	this.instance_13._off = true;

	this.instance_14 = new lib.Символ28("synched",0);
	this.instance_14.setTransform(897.7,200.5,0.6041,0.6148,0,-18.7826,161.2195,4.8,10.5);
	this.instance_14._off = true;

	this.instance_15 = new lib.жук();
	this.instance_15.setTransform(1160.05,76.6,0.6042,0.6148,0,-16.9926,163.008,-3.2,-0.1);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_10}]}).to({state:[{t:this.instance_11}]},5).to({state:[{t:this.instance_12}]},29).to({state:[{t:this.instance_13}]},5).to({state:[{t:this.instance_14}]},5).to({state:[{t:this.instance_15}]},15).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_10).to({_off:true,regX:-1.4,skewX:21.1845,skewY:-158.8156,guide:{path:[140.6,114.2,182.8,131.1,225,148], orient:'fixed'}},5).wait(55));
	this.timeline.addTween(cjs.Tween.get(this.instance_11).to({_off:false},5).to({_off:true,regX:6.2,regY:8.4,skewX:-23.0078,skewY:-203.0072,x:716.45,y:276.65},29).wait(26));
	this.timeline.addTween(cjs.Tween.get(this.instance_12).wait(5).to({_off:false},29).to({_off:true,regX:6,regY:9.1,scaleX:0.6041,skewX:-202.8177,skewY:-382.8151,x:819.8,y:240.5},5).wait(21));
	this.timeline.addTween(cjs.Tween.get(this.instance_13).wait(34).to({_off:false},5).to({_off:true,regX:4.8,regY:10.5,skewX:-378.7826,skewY:-558.7805,guide:{path:[818.1,236.9,849.1,223.4,880,210,889.4,206.7,898.7,203.4], orient:'fixed'}},5).wait(16));
	this.timeline.addTween(cjs.Tween.get(this.instance_14).wait(39).to({_off:false},5).to({_off:true,regX:-3.2,regY:-0.1,scaleX:0.6042,skewX:-376.9926,skewY:-556.992,guide:{path:[898.7,203.3,959.4,181.6,1020,160,1070,135,1120,110,1125,105,1130,100.1,1140,95.1,1150,90.1,1146.9,85.2,1150,80.1,1155,78.4,1160,76.8], orient:'fixed'},mode:"independent"},15).wait(1));

	// Слой_1
	this.instance_16 = new lib.Символ35("synched",0);
	this.instance_16.setTransform(100.5,368.65,1,1,0,0,180,-3,-0.1);

	this.instance_17 = new lib.Символ34("synched",0);
	this.instance_17.setTransform(750.25,341.2,1,1,0,-1.8695,178.1305,13.8,3.2);
	this.instance_17._off = true;

	this.instance_18 = new lib.Символ33("synched",0);
	this.instance_18.setTransform(1206.5,366.05,1,1,0,0,180,13.9,1.7);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_16}]}).to({state:[{t:this.instance_17}]},35).to({state:[{t:this.instance_18}]},24).wait(1));
	this.timeline.addTween(cjs.Tween.get(this.instance_16).to({_off:true,regX:13.8,regY:3.2,skewX:-1.8695,skewY:178.1305,guide:{path:[100.5,371.1,190.3,375.5,280.1,380,435,360,590,340,590,335,590,330,606.9,332.8,620,340,632.5,339.8,640,340,656.5,347.4,670,350,673.5,348.1,680,350,681.5,348.1,690,350,692.3,345.8,700,350,722.1,345.8,740,340,745.3,340.5,750.4,340.8], orient:'fixed'}},35).wait(25));
	this.timeline.addTween(cjs.Tween.get(this.instance_17).to({_off:false},35).to({_off:true,regX:13.9,regY:1.7,skewX:0,skewY:180,guide:{path:[750.3,340.8,778.4,342.5,800,340,803.5,335.6,800,330,950,340,1100,350,1115,350,1130,350,1145,355,1160,360,1183.2,362.9,1206.5,365.9], orient:'fixed'}},24).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(421,45.7,1473,1606.3);
// library properties:
lib.properties = {
	id: '52D503F99C4620438A86C279CB3205CF',
	width: 1280,
	height: 720,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"images/КМС_4_1_HTML5 Canvas_atlas_1.png?1678194203459", id:"КМС_4_1_HTML5 Canvas_atlas_1"},
		{src:"sounds/ВидеобезназваниясделановClipchamp1onlineaudioconvertercom.mp3?1678194203568", id:"ВидеобезназваниясделановClipchamp1onlineaudioconvertercom"},
		{src:"sounds/audio_20230226_165556onlineaudioconvertercom.mp3?1678194203568", id:"audio_20230226_165556onlineaudioconvertercom"},
		{src:"sounds/zhuzhzhaniezhuka.mp3?1678194203568", id:"zhuzhzhaniezhuka"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['52D503F99C4620438A86C279CB3205CF'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}			
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;			
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});			
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;			
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused){
			stageChild.syncStreamSounds();
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;