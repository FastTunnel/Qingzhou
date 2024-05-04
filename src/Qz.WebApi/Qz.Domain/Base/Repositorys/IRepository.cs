using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Base.Repositorys
{
    public interface IRepository<Domain>
    //where ID : IIdentifier
    {
        /// <summary>
        /// 将一个Aggregate附属到一个Repository，让它变为可追踪。
        /// Change-Tracking在下文会讲，非必须
        /// </summary>
        /// <param name="aggregate"></param>
        void Attach(Domain aggregate);

        /// <summary>
        /// 解除一个Aggregate的追踪
        /// Change-Tracking在下文会讲，非必须
        /// </summary>
        /// <param name="aggregate"></param>
        void Detach(Domain aggregate);

        /// <summary>
        /// 通过ID寻找Aggregate。
        /// 找到的Aggregate自动是可追踪的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Domain? Find(long id);

        /// <summary>
        /// 将一个Aggregate从Repository移除
        /// 操作后的aggregate对象自动取消追踪
        /// </summary>
        /// <param name="aggregate"></param>
        void Remove(Domain aggregate);

        /// <summary>
        /// 保存一个Aggregate
        /// 保存后自动重置追踪条件
        /// </summary>
        /// <param name="aggregate"></param>
        long Save(Domain aggregate);
    }

    // 聚合根的Marker接口
    public interface Aggregate<ID> : Entity<ID>
    //where ID : IIdentifier
    {

    }

    // 实体类的Marker接口
    public interface Entity<ID> : Identifiable<ID>
    //where ID : IIdentifier
    {

    }

    public interface Identifiable<ID>
    //where ID : IIdentifier
    {
        //ID GetId();
    }

    // ID类型DP的Marker接口
    //public interface IIdentifier
    //{

    //}
}
