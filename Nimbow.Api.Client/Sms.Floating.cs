﻿using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Nimbow.Api.Client
{
    partial class Sms
    {
        public static TextSms CreateText()
        {
            Contract.Ensures(Contract.Result<TextSms>() != null);

            return new TextSms();
        }

        public static BinarySms CreateBinary()
        {
            Contract.Ensures(Contract.Result<BinarySms>() != null);

            return new BinarySms();
        }
    }

    public static class SmsExtensions
    {
        private static readonly Lazy<NimbowApiClientAsync> ApiClientAsync = new Lazy<NimbowApiClientAsync>(() => new NimbowApiClientAsync());

        private static readonly Lazy<NimbowApiClient> ApiClient = new Lazy<NimbowApiClient>(() => new NimbowApiClient());

        private static TSms Assign<TSms>(this TSms sms, Action<TSms> assigner)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Requires(assigner != null);
            Contract.Ensures(Contract.Result<TSms>() != null);

            assigner.Invoke(sms);
            return sms;
        }

        public static Task<SendSmsResult> SendAsync<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<Task<SendSmsResult>>() != null);

            return ApiClientAsync.Value.SendSmsAsync(sms);
        }

        public static SendSmsResult Send<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<SendSmsResult>() != null);

            return ApiClient.Value.SendSms(sms);
        }

        public static TSms From<TSms>(this TSms sms, string from)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.From = from);
        }

        public static TSms To<TSms>(this TSms sms, string to)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.To = to);
        }

        public static TextSms Text(this TextSms textSms, string text)
        {
            Contract.Requires(textSms != null);
            Contract.Ensures(Contract.Result<TextSms>() == textSms);

            return textSms.Assign(s => s.Text = text);
        }

        public static TextSms AsUnicode(this TextSms textSms)
        {
            Contract.Requires(textSms != null);
            Contract.Ensures(Contract.Result<TextSms>() == textSms);

            return textSms.Assign(s => s.IsUnicode = true);
        }

        public static TextSms WithAutomaticUnicodeRecognition(this TextSms textSms)
        {
            Contract.Requires(textSms != null);
            Contract.Ensures(Contract.Result<TextSms>() == textSms);

            return textSms.Assign(s => s.AutomaticUnicodeRecognition = true);
        }

        public static BinarySms Data(this BinarySms binarySms, byte[] data)
        {
            Contract.Requires(binarySms != null);
            Contract.Ensures(Contract.Result<BinarySms>() == binarySms);

            return binarySms.Assign(s => s.Data = data);
        }

        public static TSms AsFlash<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.IsFlash = true);
        }

        public static TSms WithMessageIdInResult<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetMessageId = true);
        }

        public static TSms WithMessagePartsInResult<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetMessageParts = true);
        }

        public static TSms WithFromInResult<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetFrom = true);
        }

        public static TSms WithToInResult<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetTo = true);
        }

        public static TSms WithNetCostInResult<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetNetCost = true);
        }

        public static TSms WithoutDeliveryReport<TSms>(this TSms sms)
            where TSms : Sms
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<TSms>() == sms);

            return sms.Assign(s => s.GetDeliveryReport = false);
        }
    }
}