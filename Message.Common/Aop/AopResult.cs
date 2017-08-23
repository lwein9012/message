using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Common.Aop
{
    public class AopResult<T>
    {
        internal AopResult() { }

        /// <summary>
        /// 返回值 0：成功
        /// 返回值 -1：失败
        /// 其他值 查看具体约定
        /// </summary>
        public int ResultNo { get; set; }

        /// <summary>
        /// 返回类型
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
    }

    public static class AopResult
    {

        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="total"></param>
        /// <param name="resultNo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AopResult<T> Success<T>(T t, int total = 0, int resultNo = 0, string message = null)
        {
            return new AopResult<T> { Result = t, Total = total, ResultNo = resultNo, Message = message };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="resultNo"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static AopResult<T> Fail<T>(string message, int resultNo = -1, T t = default(T))
        {
            return new AopResult<T> { ResultNo = resultNo, Message = message, Result = t };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="resultNo"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static AopResult<int> Fail(string message, int resultNo = -1, int t = 0)
        {
            return new AopResult<int> { ResultNo = resultNo, Message = message, Result = t };
        }

        /// <summary>
        /// 是否是成功的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aopResult"></param>
        /// <returns></returns>
        public static bool IsSuccess<T>(this AopResult<T> aopResult)
        {
            return aopResult.ResultNo == 0;
        }
    }
}
