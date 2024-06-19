using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Asmin.Packages.JWT.Entities
{
    /// <summary>
    /// Algorithms for signing.
    /// </summary>
    public enum EnumTokenSecurityAlgorithms
    {
        [Description("http://www.w3.org/2001/04/xmlenc#aes128-cbc")]
        Aes128Encryption,
        [Description("http://www.w3.org/2001/04/xmlenc#kw-aes128")]
        Aes128KeyWrap,
        [Description("http://www.w3.org/2001/04/xmlenc#aes192-cbc")]
        Aes192Encryption,
        [Description("http://www.w3.org/2001/04/xmlenc#kw-aes192")]
        Aes192KeyWrap,
        [Description("http://www.w3.org/2001/04/xmlenc#aes256-cbc")]
        Aes256Encryption,
        [Description("http://www.w3.org/2001/04/xmlenc#kw-aes256")]
        Aes256KeyWrap,
        [Description("http://www.w3.org/2001/04/xmlenc#des-cbc")]
        DesEncryption,
        [Description("http://www.w3.org/2001/10/xml-exc-c14n#")]
        ExclusiveC14n,
        [Description("http://www.w3.org/2001/10/xml-exc-c14n#WithComments")]
        ExclusiveC14nWithComments,
        [Description("http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")]
        HmacSha256Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#hmac-sha384")]
        HmacSha384Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#hmac-sha512")]
        HmacSha512Signature,
        [Description("http://www.w3.org/2001/04/xmlenc#ripemd160")]
        Ripemd160Digest,
        [Description("http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p")]
        RsaOaepKeyWrap,
        [Description("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256")]
        RsaSha256Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#rsa-sha384")]
        RsaSha384Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#rsa-sha512")]
        RsaSha512Signature,
        [Description("http://www.w3.org/2001/04/xmlenc#rsa-1_5")]
        RsaV15KeyWrap,
        [Description("http://www.w3.org/2001/04/xmlenc#sha256")]
        Sha256Digest,
        [Description("http://www.w3.org/2001/04/xmldsig-more#sha384")]
        Sha384Digest,
        [Description("http://www.w3.org/2001/04/xmlenc#sha512")]
        Sha512Digest,
        [Description("http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha256")]
        EcdsaSha256Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha384")]
        EcdsaSha384Signature,
        [Description("http://www.w3.org/2001/04/xmldsig-more#ecdsa-sha512")]
        EcdsaSha512Signature,
        [Description("http://www.w3.org/2007/05/xmldsig-more#sha256-rsa-MGF1")]
        RsaSsaPssSha256Signature,
        [Description("http://www.w3.org/2007/05/xmldsig-more#sha384-rsa-MGF1")]
        RsaSsaPssSha384Signature,
        [Description("http://www.w3.org/2007/05/xmldsig-more#sha512-rsa-MGF1")]
        RsaSsaPssSha512Signature,
        /// see: http://tools.ietf.org/html/rfc7518#section-3
        [Description("ES256")]
        EcdsaSha256,
        [Description("ES384")]
        EcdsaSha384,
        [Description("ES512")]
        EcdsaSha512,
        [Description("HS256")]
        HmacSha256,
        [Description("HS384")]
        HmacSha384,
        [Description("HS512")]
        HmacSha512,
        [Description("none")]
        None,
        [Description("RS256")]
        RsaSha256,
        [Description("RS384")]
        RsaSha384,
        [Description("RS512")]
        RsaSha512,
        [Description("PS256")]
        RsaSsaPssSha256,
        [Description("PS384")]
        RsaSsaPssSha384,
        [Description("PS512")]
        RsaSsaPssSha512,
        [Description("SHA256")]
        Sha256,
        [Description("SHA384")]
        Sha384,
        [Description("SHA512")]
        Sha512,
        /// see: https://tools.ietf.org/html/rfc7518#section-4.1
        [Description("RSA1_5")]
        RsaPKCS1,
        [Description("RSA-OAEP")]
        RsaOAEP,
        [Description("A128KW")]
        Aes128KW,
        [Description("A128CBC-HS256")]
        Aes128CbcHmacSha256,
        [Description("A192CBC-HS384")]
        Aes192CbcHmacSha384,
        [Description("A256CBC-HS512")]
        Aes256CbcHmacSha512
    }
}
