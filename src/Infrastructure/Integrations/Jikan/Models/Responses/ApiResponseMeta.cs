namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record ResponseMeta(
    bool Cached,
    bool Stale,
    bool RefreshFailed,
    DateTime FetchedAt
);

public record ResponseMetaWithPagination(
    bool Cached,
    bool Stale,
    bool RefreshFailed,
    DateTime FetchedAt,
    ResponsePagination Pagination
);

public record ResponsePagination(
    int Page,
    int Limit,
    int Count,
    int? Total,
    bool HasNextPage
);