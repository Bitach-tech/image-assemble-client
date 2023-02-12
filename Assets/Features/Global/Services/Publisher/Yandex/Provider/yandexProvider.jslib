mergeInto(LibraryManager.library,
    {

        Review: function ()
        {
            ysdk.feedback.canReview()
                .then(({value, reason}) =>
                {
                    if (value)
                    {
                        ysdk.feedback.requestReview()
                            .then(({feedbackSent}) =>
                            {
                                console.log(feedbackSent);
                                SendCallback("OnReview");
                            })
                    } else
                    {
                        console.log(reason)
                        SendCallback("OnReview");
                    }
                }).catch(error =>
            {
                SendCallback("OnReview");
            })
        },

        SaveUserData: function (data)
        {
            var dateString = UTF8ToString(data);
            var myobj = JSON.parse(dateString);
            player.setData(myobj);
        },

        GetUserData: function ()
        {
            player.getData().then(data =>
            {
                const myJSON = JSON.stringify(data);
                SendDataCallback("OnInterstitialShown", myJSON);
            });
        },

        SetToLeaderboard: function (target, value)
        {
            ysdk.getLeaderboards()
                .then(lb =>
                {
                    lb.setLeaderboardScore(target, value);
                });
        },

        GetLang: function ()
        {
            const lang = ysdk.environment.i18n.lang;
            const bufferSize = lengthBytesUTF8(lang) + 1;
            const buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            return buffer;
        },

        ShowFullscreenAd: function ()
        {
            ysdk.adv.showFullscreenAdv({
                callbacks: {
                    onClose: function (wasShown)
                    {
                        SendCallback("OnInterstitialShown");
                    },
                    onError: function (error)
                    {
                        SendDataCallback("OnInterstitialShown", error);
                    }
                }
            })
        },

        ShowRewardedAd: function ()
        {
            ysdk.adv.showRewardedVideo({
                callbacks: {
                    onOpen: () =>
                    {
                        console.log('Video ad open.');
                    },
                    onRewarded: () =>
                    {
                        console.log('Rewarded!');
                        SendCallback("OnRewarded");
                    },
                    onClose: () =>
                    {
                        console.log('Video ad closed.');
                        SendCallback("OnRewardedClose");
                    },
                    onError: (e) =>
                    {
                        console.log('Error while open video ad:', e);
                        SendDataCallback("OnRewardedError", e);
                    }
                }
            })
        },

        Purchase: function (purchaseId)
        {
            payments.purchase({id: purchaseId}).then(purchase =>
            {
                SendDataCallback("OnPurchaseSuccess", purchaseId)
            }).catch(err =>
            {
                SendDataCallback("OnPurchaseFailed", err)
            })
        },

        SendCallback: function (target)
        {
            myGameInstance.SendMessage("YandexCallbacks", target);
        },

        SendDataCallback: function (target, data)
        {
            myGameInstance.SendMessage("YandexCallbacks", target, data);
        }
    });